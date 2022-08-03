using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausing : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject crosshair;
    public GameObject inventory;
    public GameObject merchantNPC;
    public GameObject builderNPC;
    public GameObject mainMenu;
    public GameObject builderCam;
    public GameObject getTownName;
    public GameObject moving;
    public GameObject residentMenu;
    public GameObject jobCamera;
    public GameObject farmMenu;
    public GameObject lumberMillMenu;
    public GameObject mineMenu;
    public GameObject hotbar;

    public GameObject canvas;
    public List<GameObject> canvasObjects = new List<GameObject>();
    public bool[] canvasObjectsActive;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (!(canvas.transform.GetChild(i).gameObject.name == "Hotbar" || canvas.transform.GetChild(i).gameObject.name == "Game has Been Saved" || canvas.transform.GetChild(i).gameObject.name == "Crosshair"))
            {
                canvasObjects.Add(canvas.transform.GetChild(i).gameObject);
            }
        }
        canvasObjectsActive = new bool[canvasObjects.Count];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && checkIfAllTrue())
        {
            pauseMenu.SetActive(true);
            inventory.SetActive(false);
            merchantNPC.SetActive(false);
            builderNPC.SetActive(false);
            crosshair.SetActive(false);
            hotbar.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
        }
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
