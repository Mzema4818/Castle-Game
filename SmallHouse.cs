using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHouse : MonoBehaviour
{
    public int maxResidents = 4;
    public int Residents = 0;
    public bool canAdd = true;
    public GameObject residents;
    public GameObject realResidents;
    public GameObject boatInstant;
    private GameObject actualresidents;
    public bool canSpawn;
    public bool testSpawn;

    void Awake()
    {
        actualresidents = GameObject.Find("Actual Residents");

        if (canSpawn)
        {
            for (int i = 0; i < Residents; ++i)
            {
                GameObject resident = Instantiate(residents, new Vector3(gameObject.transform.position.x + 10, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                resident.transform.SetParent(realResidents.transform);
                resident.name = "resident";
                resident.AddComponent<Resident>();
                resident.SetActive(true);
            }
            canSpawn = false;
        }
    }

    void OnDestroy()
    {
        //for (int i = 0; i < Residents; ++i)
        //{
            //Destroy(actualresidents.gameObject.transform.GetChild(i).gameObject);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (testSpawn)
        {
            int xCord = Random.Range(250, 350);
            int posNegX = Random.Range(0, 2);
            int zCord = Random.Range(250, 350);
            int posNegZ = Random.Range(0, 2);
            print("x: " + posNegX);
            print("z: " + posNegZ);
            if (posNegX == 0)
            {
                xCord *= -1;
            }
            if (posNegZ == 0)
            {
                zCord *= -1;
            }
            GameObject boat = Instantiate(boatInstant, new Vector3(xCord, 3, zCord), Quaternion.identity);
            boat.SetActive(true);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        if (Residents < maxResidents && canAdd && gameObject.activeSelf == true)
        {
            if (1 == 1) //Random.value > 0.8
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
                GameObject boat = Instantiate(boatInstant, new Vector3(xCord, 3, zCord), Quaternion.identity);
                GameObject resident = Instantiate(residents, new Vector3(boat.transform.position.x + 0.2f, boat.transform.position.y + 0.3f, boat.transform.position.z + 0.2f), Quaternion.identity);

                foreach (Transform transform in gameObject.transform)
                {
                    if (transform.name == "Door")
                    {
                        resident.GetComponent<Resident>().movePositionTransform = transform;
                    }
                }
                resident.GetComponent<Resident>().realResidents = realResidents;
                boat.SetActive(true);
                resident.SetActive(true);
                resident.transform.SetParent(boat.transform);
                resident.name = "resident";
                canAdd = false;
            }
        }

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        canAdd = true;
        StartCoroutine(ExampleCoroutine());
    }

}
