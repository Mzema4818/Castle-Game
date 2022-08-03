using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;
using UnityEngine.UI;

public class Resident : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    public bool isWandering = false;
    public bool isRotationLeft = false;
    public bool isRotationRight = false;
    public bool isWalking = false;
    public bool findHome = true;

    public CharacterController controller;
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float x;
    public float z;

    public bool shouldWander;
    public bool shouldPathFind;
    public bool landed;
    public bool spawnedIn;
    public GameObject dayCycle;

    Animator animator;

    public Transform movePositionTransform;
    public NavMeshAgent navMeshAgent;
    public GameObject realResidents;

    //Job Stuff
    public bool hasJob;
    public bool shouldWork;
    public GameObject jobHome;
    public GameObject JobDoor;
    public bool startResident;
    public bool startJob;
    public bool mightGetFired;
    public bool gettingFired;

    public Button noClicked;
    public Button noClicked2;
    public Button fire;
    public Button sentHome;
    public bool talking;
    public GameObject player;

    public bool mightGetSentHome;
    public bool backHome;
    public GameObject boatInsant;
    public Vector3 returnHome;
    public bool walkHome;
    public GameObject boat;

    private void Awake()
    {
        spawnedIn = false;
    }

    private void Start()
    {
        hasJob = false;
        backHome = false;
        mightGetSentHome = false;
        startJob = true;
        findHome = true;
        landed = false;
        isWandering = false;
        shouldWander = false;
        shouldPathFind = false;
        startResident = false;
        gettingFired = false;
        mightGetFired = false;
        talking = false;
        walkHome = false;
        boat = null;
        animator = GetComponent<Animator>();
        animator.SetBool("isSitting", true);

        noClicked.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        noClicked2.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        sentHome.GetComponent<Button>().onClick.AddListener(sendBackHome);
        fire.GetComponent<Button>().onClick.AddListener(fireResident);
    }

    [Obsolete]
    private void Update()
    {
        //Happens once at beginning 
        if (!startResident)
        {
            if (spawnedIn)
            {
                animator.SetBool("isSitting", false);
                shouldWander = true;
                findHome = false;

                if (jobHome != null)
                {
                    hasJob = true;
                }

                if(hasJob && jobHome.name == "mine")
                {
                    jobHome.GetComponent<Mine>().workers++;
                }

                if (hasJob && jobHome.name == "farm")
                {
                    jobHome.GetComponent<Farm>().workers++;
                }

                if (hasJob && jobHome.name == "lumberMill")
                {
                    jobHome.GetComponent<lumberMill>().workers++;
                }

                StartCoroutine(ExampleCoroutine2());
                spawnedIn = false;
            }

            if (landed)
            {
                animator.SetBool("isSitting", false);
                StartCoroutine(ExampleCoroutine());
                landed = false;
            }

            if (!animator.GetBool("isSitting"))
            {
                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -5;
                }

                x = 0;
                z = 1;

                Vector3 move = transform.right * x + transform.forward * z;

                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
            }
        }

        if (startResident)
        {
            //Finding Path
            if (shouldPathFind)
            {
                navMeshAgent.destination = movePositionTransform.position;
                animator.SetBool("isWalking", true);
            }

            if (shouldWork)
            {
                navMeshAgent.destination = JobDoor.transform.position;
                animator.SetBool("isWalking", true);
            }

            if (walkHome)
            {
                navMeshAgent.destination = returnHome;
                animator.SetBool("isWalking", true);
                print("hi");
            }

            if (talking)
            {
                shouldWork = false;
                shouldWander = false;
                shouldPathFind = false;
                animator.SetBool("isWalking", false);
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                Vector3 newtarget = player.transform.position;
                newtarget.y = transform.position.y;
                transform.LookAt(newtarget);
            }

            //Distances
            if (Vector3.Distance(movePositionTransform.position, transform.position) <= 3 && shouldPathFind)
            {
                animator.SetBool("isWalking", false);
                ResidentEnable(false);
                shouldPathFind = false;
            }

            if (boat != null && Vector3.Distance(returnHome, transform.position) <= 1)
            {
                animator.SetBool("isWalking", false);
            }

            if (boat != null && Vector3.Distance(boat.transform.position, transform.position) <= 3)
            {
                transform.parent = boat.transform;
                animator.SetBool("isWalking", false);
                animator.SetBool("isSitting", true);
                transform.position = new Vector3(boat.transform.position.x + 0.2f, boat.transform.position.y + 0.3f, boat.transform.position.z + 0.2f);
                boat.GetComponent<Boat>().pickedUp = true;
            }

            if (Vector3.Distance(movePositionTransform.position, transform.position) <= 8 && findHome)
            {
                shouldPathFind = false;
                shouldWander = true;
                findHome = false;
            }

            if (hasJob)
            {
                if (Vector3.Distance(JobDoor.transform.position, transform.position) <= 5 && shouldWork)
                {
                    if(jobHome.name == "mine" && startJob)
                    {
                        jobHome.GetComponent<Mine>().workersActive++;
                        startJob = false;
                    }

                    if (jobHome.name == "farm" && startJob)
                    {
                        jobHome.GetComponent<Farm>().workersActive++;
                        startJob = false;
                    }

                    if (jobHome.name == "lumberMill" && startJob)
                    {
                        jobHome.GetComponent<lumberMill>().workersActive++;
                        startJob = false;
                    }

                    animator.SetBool("isWalking", false);
                    ResidentEnable(false);
                }
            }

            //Wandering
            if (shouldWander)
            {
                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -2;
                }

                x = 0;
                z = 1;

                Vector3 move = transform.right * x + transform.forward * z;

                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);

                if (!isWandering)
                {
                    StartCoroutine(Wander());
                }

                if (isRotationRight)
                {
                    transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
                }

                if (isRotationLeft)
                {
                    transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
                }

                if (isWalking)
                {
                    controller.Move(move * 1 * Time.deltaTime);
                    animator.SetBool("isWalking", true);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                }
            }

            //Time of day actions
            if (!talking && !walkHome)
            {
                if (dayCycle.GetComponent<LightingManager>().TimeOfDay >= 5 && dayCycle.GetComponent<LightingManager>().TimeOfDay <= 6.9)
                {
                    ResidentEnable(true);
                    shouldWork = false;
                    shouldWander = true;
                    shouldPathFind = false;
                }
                if (dayCycle.GetComponent<LightingManager>().TimeOfDay >= 7 && dayCycle.GetComponent<LightingManager>().TimeOfDay <= 15.9)
                {
                    if (hasJob)
                    {
                        shouldWork = true;
                        shouldWander = false;
                        shouldPathFind = false;
                    }
                    else
                    {
                        shouldWork = false;
                        shouldWander = true;
                        shouldPathFind = false;
                    }
                }
                if (dayCycle.GetComponent<LightingManager>().TimeOfDay >= 16 && dayCycle.GetComponent<LightingManager>().TimeOfDay <= 18.9)
                {
                    ResidentEnable(true);
                    shouldWork = false;
                    shouldWander = true;
                    shouldPathFind = false;

                    if(hasJob && jobHome.name == "mine" && !startJob)
                    {
                        jobHome.GetComponent<Mine>().workersActive--;
                        startJob = true;
                    }

                    if (hasJob && jobHome.name == "farm" && !startJob)
                    {
                        jobHome.GetComponent<Farm>().workersActive--;
                        startJob = true;
                    }

                    if (hasJob && jobHome.name == "lumberMill" && !startJob)
                    {
                        jobHome.GetComponent<lumberMill>().workersActive--;
                        startJob = true;
                    }
                }
                if (dayCycle.GetComponent<LightingManager>().TimeOfDay >= 19)
                {
                    shouldWork = false;
                    shouldWander = false;
                    shouldPathFind = true;
                }
            }

            if (mightGetFired)
            {
                if (gettingFired)
                {
                    if (jobHome.name == "mine")
                    {
                        jobHome.GetComponent<Mine>().workers--;
                    }

                    if (jobHome.name == "farm")
                    {
                        jobHome.GetComponent<Farm>().workers--;
                    }

                    if (jobHome.name == "lumberMill")
                    {
                        jobHome.GetComponent<lumberMill>().workers--;
                    }

                    jobHome = null;
                    JobDoor = null;
                    hasJob = false;
                    transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.white;
                    gettingFired = false;
                    mightGetFired = false;
                }
            }

            if (mightGetSentHome)
            {
                if (backHome)
                {
                    int xCord = Random.Range(250, 350);
                    int posNegX = Random.Range(0, 2);
                    int zCord = Random.Range(250, 350);
                    int posNegZ = Random.Range(0, 2);
                    if (posNegX == 0)
                    {
                        xCord *= -1;
                    }
                    if (posNegZ == 0)
                    {
                        zCord *= -1;
                    }
                    boat = Instantiate(boatInsant, new Vector3(xCord, 3, zCord), Quaternion.identity);
                    boat.SetActive(true);
                    transform.parent = null;
                    TaskOnClick();
                    transform.name = "residentLeaving";
                    StartCoroutine(ExampleCoroutine3(boat));
                }
            }
        }
    }
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotationRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotationRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotationLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotationLeft = false;
        }

        isWandering = false;
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10); //mess with position where resident gets off boat, need it for navmeshagent error
        gameObject.AddComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().radius = 1.2f;
        GetComponent<NavMeshAgent>().height = 9.3f;
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        shouldWander = false;
        walkHome = true;
        shouldPathFind = true;
        landed = false;
        startResident = true;
        //shouldPathFind = true;
    }

    IEnumerator ExampleCoroutine2()
    {
        yield return new WaitForSeconds(2);
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10); //mess with position where resident gets off boat, need it for navmeshagent error
        gameObject.AddComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().radius = 1.2f;
        GetComponent<NavMeshAgent>().height = 9.3f;
        navMeshAgent = GetComponent<NavMeshAgent>();
        startResident = true;
        //shouldPathFind = true;
    }

    IEnumerator ExampleCoroutine3(GameObject gameobject)
    {
        yield return new WaitForSeconds(1);
        gameobject.GetComponent<Boat>().getPoint = true;
        yield return new WaitForSeconds(1);
        returnHome = gameobject.GetComponent<Boat>().residentWalk;
        gameobject.GetComponent<Boat>().shouldPickUp = true;
        walkHome = true;
        backHome = false;
        mightGetSentHome = false;
        shouldPathFind = false;
        shouldWander = false;
    }

    public void ResidentEnable(bool question)
    {
        if (question)
        {
            foreach (Transform transform in transform)
            {
                transform.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform transform in transform)
            {
                transform.gameObject.SetActive(false);
            }
        }

    }

    public void TaskOnClick()
    {
        talking = false;
        mightGetFired = false;
        mightGetSentHome = false;
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
    }

    public void fireResident()
    {
        if (mightGetFired)
        {
            gettingFired = true;
        }
    }

    public void sendBackHome()
    {
        if (mightGetSentHome)
        {
            backHome = true;
        }
    }
}
