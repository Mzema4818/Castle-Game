using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Miner : MonoBehaviour
{
    private Vector3 location;
    private Quaternion rotation;
    private int speed;
    private Vector3 moveDirection = Vector3.zero;
    private bool canRotate = true;
    private bool canMove = true;
    public bool willReTransform;
    public Vector3 respawnLocation;
    public GameObject MinerMenu;
    public bool isMenuOpen;
    public GameObject player;
    public string[] texts = new string[] { "test1", "test2", "test3" };
    public int message = 0;
    public bool canRandomize = false;
    public bool canMoveAgain;
    public bool canButtonBePressed = false;
    Vector3 moveVector;
    CharacterController controller;
    public GameObject ButtonGameObject;

    public GameObject parent;
    public Button CustomButton;

    void Start()
    {
        canButtonBePressed = false;
        controller = GetComponent<CharacterController>();
        speed = 6;
        SetRandomPos();
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        //Dear god, why do you hate me? Did I sin?
        //If not, why the fuck won't you make gravity work?
        moveVector = Vector3.zero;

        if (controller.isGrounded == false)
        {
            moveVector += Physics.gravity;
        }

        controller.Move(moveVector * Time.deltaTime);


        if (canMove && !isMenuOpen)
        {
            float step = speed * Time.deltaTime;
            //its magic dont touch
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(location.x, transform.position.y, location.z), step);
        }

        if (canRotate && !isMenuOpen)
        {
            transform.LookAt(location);
            transform.rotation *= Quaternion.Euler(-90, 90, 0);
            canRotate = false;
        }

        if (transform.position.x == location.x && transform.position.z == location.z && !isMenuOpen)
        {
            canMove = false;
            StartCoroutine(ExampleCoroutine());
        }

        if (willReTransform)
        {
            transform.position = respawnLocation;
            willReTransform = false;
        }

        if (MinerMenu.activeSelf == true && isMenuOpen == true)
        {
            canMove = false;
            canRotate = true;
            if (canRandomize)
            {
                message = Random.Range(1, 3);
                if (message == 1)
                    MinerMenu.GetComponentInChildren<TextMeshProUGUI>().text = texts[0];
                if (message == 2)
                    MinerMenu.GetComponentInChildren<TextMeshProUGUI>().text = texts[1];
                if (message == 3)
                    MinerMenu.GetComponentInChildren<TextMeshProUGUI>().text = texts[2];
            }
            canRandomize = false;
            if (canRotate)
            {
                transform.LookAt(player.transform);
                transform.rotation *= Quaternion.Euler(-90, 90, 0);
                canRotate = false;
            }
            canButtonBePressed = true;
        }

        if (Input.GetMouseButtonUp(0) && EventSystem.current.currentSelectedGameObject == ButtonGameObject && canButtonBePressed)
        {
            isMenuOpen = false;
            canMoveAgain = true;
            canButtonBePressed = false;
        }

        if (canMoveAgain)
        {
            transform.LookAt(location);
            transform.rotation *= Quaternion.Euler(-90, 90, 0);
            canMove = true;
            canMoveAgain = false;
        }
    }

    void SetRandomPos()
    {
        location = new Vector3(Random.Range(transform.parent.parent.position.x - 5f, transform.parent.parent.position.x + 5f), transform.parent.parent.position.y, Random.Range(transform.parent.parent.position.z - 5f, transform.parent.parent.position.z + 5f));
        canRotate = true;
        canMove = true;
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        //After we have waited 5 seconds print the time again.
        if (!isMenuOpen)
        {
            SetRandomPos();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        canMove = false;
        StartCoroutine(ExampleCoroutine());
    }

    void canStartMovingAgain()
    {
        canMoveAgain = true;
    }
}
