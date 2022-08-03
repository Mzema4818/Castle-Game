using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuButton : MonoBehaviour
{
    public GameObject buildMenu;
    public GameObject crosshair;
    public GameObject hotbar;

    public Animator animator;
    public bool animationRunning;
    public bool resetTime;

    public float time = 5;

    public GameObject canvas;
    public List<GameObject> canvasObjects = new List<GameObject>();
    public bool[] canvasObjectsActive;

    void Start()
    {
        animationRunning = false;
        resetTime = false;

        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (!(canvas.transform.GetChild(i).gameObject.name == "Hotbar" || canvas.transform.GetChild(i).gameObject.name == "Game has Been Saved" || canvas.transform.GetChild(i).gameObject.name == "Crosshair"))
            {
                canvasObjects.Add(canvas.transform.GetChild(i).gameObject);
            }
        }
        canvasObjectsActive = new bool[canvasObjects.Count];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && checkIfAllTrue())
        {
            buildMenu.SetActive(true);
            crosshair.SetActive(false);
            hotbar.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.B) && buildMenu.activeSelf == true)
        {
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
            //animator.SetBool("close", true);
            //animationRunning = true;
        }

        /*if (animationRunning)
        {
            if (time != 0)
            {
                time -= Time.deltaTime;
            }

            if (time < 0)
            {
                animationRunning = false;
                animator.SetBool("close", false);
                inventory.SetActive(false);
                wood.SetActive(false);
                stone.SetActive(false);
                crosshair.SetActive(true);
                hotbar.SetActive(true);
                time = 0.7f;
            }
        }*/
    }

    void SoldWood()
    {
        print("works");
    }

    public bool checkIfAllTrue()
    {
        for (int i = 0; i < canvasObjects.Count; i++)
        {
            canvasObjectsActive[i] = canvasObjects[i].activeSelf;
        }

        bool returnBool = true;

        for (int i = 0; i < canvasObjectsActive.Length; i++)
        {
            if (canvasObjectsActive[i] == true)
            {
                returnBool = false;
                break;
            }
        }
        return returnBool;
    }
}
