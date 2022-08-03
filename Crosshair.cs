using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public RaycastHit hit;
    public float time1 = 4;
    private float initalTime1;
    private float timeStore1;
    private bool canClick1;
    private float halfTime1;
    public float time2 = 4;
    private float initalTime2;
    private float timeStore2;
    private bool canClick2;
    private float halfTime2;
    public GameObject axe;
    public GameObject pickaxe;
    public GameObject sword;
    public GameObject inventory;
    public GameObject movingObject;
    public int distance;
    public GameObject merchant;
    public GameObject builder;
    public GameObject crosshair;
    public GameObject hotbar;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject getTownName;
    public GameObject destory;
    public GameObject getMovingName;
    public GameObject residentMenu;
    public GameObject jobCamera;
    public GameObject farmMenu;
    public GameObject lumberMillMenu;
    public GameObject MineMenu;
    public Button collect;
    public Button fireRes;
    public GameObject jobMenu;
    public GameObject move;
    public TextMeshProUGUI jobMenuText;

    public GameObject wood;
    public GameObject stone;

    public GameObject wheat;
    public GameObject newwood;
    public GameObject newstone;

    private TMP_Text woodText;
    private string woodValue;
    private int woodCalc;
    private int newWoodValue;

    private TMP_Text stoneText;
    private string stoneValue;
    private int stoneCalc;
    private int newStoneValue;

    private TMP_Text wheatText;
    private string wheatValue;
    private int wheatCalc;
    private int newWheatValue;

    private TMP_Text changedWoodText;
    private string changedWoodValue;
    private int changedWoodCalc;
    private int changedNewWoodValue;

    private TMP_Text changedStoneText;
    private string changedStoneValue;
    private int changedStoneCalc;
    private int changedNewStoneValue;

    public Button CustomButton;
    public GameObject actualBuildings;

    public Animator animator;

    public GameObject canvas;
    public List<GameObject> canvasObjects = new List<GameObject>();
    public bool[] canvasObjectsActive;

    void Start()
    {
        initalTime1 = time1;
        timeStore1 = time1;
        canClick1 = true;
        halfTime1 = time1 / 2;
        initalTime2 = time2;
        timeStore2 = time2;
        canClick2 = true;
        halfTime2 = time2 / 2;

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
        //woodText = wood.GetComponent<TMP_Text>();
        //woodValue = woodText.text;
        //woodCalc = int.Parse(woodValue);

        stoneText = stone.GetComponent<TMP_Text>();
        stoneValue = stoneText.text;
        stoneCalc = int.Parse(stoneValue);

        if (checkIfAllTrue())
        {
            if ((axe.activeSelf || pickaxe.activeSelf || sword.activeSelf) && Input.GetMouseButtonDown(0))
            {
                animator.SetBool("swing", true);
            }

            if (animator.GetBool("swing") && animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
            {
                animator.SetBool("swing", false);
            }
        }

        if(!checkIfAllTrue())
        {
            animator.SetBool("swing", false);
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if ((hit.collider.gameObject.name.Contains("branch") || hit.collider.gameObject.name.Contains("leave")) && hit.distance <= distance && Input.GetMouseButtonDown(0) && canClick1 && axe.activeSelf == true && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                //hit.transform.SendMessage("HitByRay");
                //newWoodValue = woodCalc + 1;
                //canClick1 = false;
                //woodText.text = newWoodValue.ToString();
            }
            if (!canClick1)
            {
                time1 -= Time.deltaTime;
            }
            if (time1 < 0)
            {
                time1 = initalTime1;
                canClick1 = true;
            }
           
            if (!canClick2)
            {
                time2 -= Time.deltaTime;
            }
            if (time2 < 0)
            {
                time2 = initalTime2;
                canClick2 = true;
            }

            if(hit.collider.gameObject.name == "Merchant" && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                merchant.SetActive(true);
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);
            }

            if (hit.collider.gameObject.name == "Builder" && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                builder.SetActive(true);
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);
            }

            if (hit.collider.gameObject.name == "resident" && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);

                if (hit.collider.gameObject.GetComponent<Resident>().jobHome == null)
                {
                    residentMenu.SetActive(true);
                    hit.collider.gameObject.GetComponent<Resident>().mightGetSentHome = true;
                }
                else
                {
                    jobMenuText.text = "Wonderful day at the " + hit.collider.gameObject.GetComponent<Resident>().jobHome.name + " today!";
                    jobMenu.SetActive(true);
                    hit.collider.gameObject.GetComponent<Resident>().mightGetFired = true;
                }

                hit.collider.gameObject.GetComponent<Resident>().talking = true;
                //hit.collider.gameObject.GetComponent<Resident>().isMenuOpen = true;
                //hit.collider.gameObject.GetComponent<Resident>().canRandomize = true;
                jobCamera.GetComponent<JobCamera>().residentHome = hit.collider.gameObject;
            }

            if (hit.collider.gameObject.name == "farmer" && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
              
                farmMenu.SetActive(true);
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);
                hit.collider.gameObject.GetComponent<Farmer>().isMenuOpen = true;
                hit.collider.gameObject.GetComponent<Farmer>().canRandomize = true;
                hit.collider.gameObject.GetComponent<Farmer>().parent = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                CustomButton = hit.collider.gameObject.GetComponent<Farmer>().CustomButton;
                CustomButton.onClick.RemoveAllListeners();
                CustomButton.onClick.AddListener(hit.collider.gameObject.GetComponent<Farmer>().parent.GetComponent<Farm>().collectWheat);
                wheatText = wheat.GetComponent<TMP_Text>();
                wheatText.text = hit.collider.gameObject.GetComponent<Farmer>().parent.GetComponent<Farm>().wheat.ToString();

                foreach (Transform child in actualBuildings.transform)
                {
                    if(child.name == "farm")
                    {
                        child.GetComponent<Farm>().canSetWheat = false;
                    }
                }

                hit.collider.gameObject.GetComponent<Farmer>().parent.GetComponent<Farm>().canSetWheat = true;
                getMovingName = hit.collider.transform.gameObject;
            }

            if (hit.collider.gameObject.name == "lumberJack" && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                lumberMillMenu.SetActive(true);
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);
                hit.collider.gameObject.GetComponent<LumberJack>().isMenuOpen = true;
                hit.collider.gameObject.GetComponent<LumberJack>().canRandomize = true;
                hit.collider.gameObject.GetComponent<LumberJack>().parent = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                CustomButton = hit.collider.gameObject.GetComponent<LumberJack>().CustomButton;
                CustomButton.onClick.RemoveAllListeners();
                CustomButton.onClick.AddListener(hit.collider.gameObject.GetComponent<LumberJack>().parent.GetComponent<lumberMill>().collectWood);
                changedWoodText = newwood.GetComponent<TMP_Text>();
                changedWoodText.text = hit.collider.gameObject.GetComponent<LumberJack>().parent.GetComponent<lumberMill>().wood.ToString();

                foreach (Transform child in actualBuildings.transform)
                {
                    if (child.name == "lumberMill")
                    {
                        child.GetComponent<lumberMill>().canSetWood = false;
                    }
                }

                hit.collider.gameObject.GetComponent<LumberJack>().parent.GetComponent<lumberMill>().canSetWood = true;
                getMovingName = hit.collider.transform.gameObject;
            }

            if (hit.collider.gameObject.name == "miner" && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && getTownName.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                MineMenu.SetActive(true);
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);
                hit.collider.gameObject.GetComponent<Miner>().isMenuOpen = true;
                hit.collider.gameObject.GetComponent<Miner>().canRandomize = true;
                hit.collider.gameObject.GetComponent<Miner>().parent = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                CustomButton = hit.collider.gameObject.GetComponent<Miner>().CustomButton;
                CustomButton.onClick.RemoveAllListeners();
                CustomButton.onClick.AddListener(hit.collider.gameObject.GetComponent<Miner>().parent.GetComponent<Mine>().collectStone);
                changedStoneText = newstone.GetComponent<TMP_Text>();
                changedStoneText.text = hit.collider.gameObject.GetComponent<Miner>().parent.GetComponent<Mine>().stone.ToString();

                foreach (Transform child in actualBuildings.transform)
                {
                    if (child.name == "mine")
                    {
                        child.GetComponent<Mine>().canSetStone = false;
                    }
                }

                hit.collider.gameObject.GetComponent<Miner>().parent.GetComponent<Mine>().canSetStone = true;
                getMovingName = hit.collider.transform.gameObject;
            }

            if (((hit.collider.transform.parent != null && hit.collider.transform.parent.name == "townhall") || (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "farm") || (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "smallHouse") || (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "lumberMill") || (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "mine")) && hit.distance <= distance && Input.GetMouseButtonDown(0) && pauseMenu.activeSelf == false && mainMenu.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && MineMenu.activeSelf == false)
            {
                destory.SetActive(true);
                move.SetActive(true);
                movingObject.SetActive(true);
                inventory.SetActive(false);
                crosshair.SetActive(false);
                hotbar.SetActive(false);
                collect.gameObject.SetActive(false);

                if(hit.collider.transform.parent != null && hit.collider.transform.parent.name == "mine")
                {
                    collect.gameObject.SetActive(true);
                    collect.onClick.RemoveAllListeners();
                    collect.GetComponent<Button>().onClick.AddListener(TaskOnClick);
                }

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "farm")
                {
                    collect.gameObject.SetActive(true);
                    collect.onClick.RemoveAllListeners();
                    collect.GetComponent<Button>().onClick.AddListener(TaskOnClick);
                }

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "farm" && hit.collider.transform.parent.GetComponent<Farm>().workers != 0)
                {
                    destory.SetActive(false);
                    move.SetActive(false);
                }

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "lumberMill")
                {
                    collect.gameObject.SetActive(true);
                    collect.onClick.RemoveAllListeners();
                    collect.GetComponent<Button>().onClick.AddListener(TaskOnClick);
                }

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "lumberMill" && hit.collider.transform.parent.GetComponent<lumberMill>().workers != 0)
                {
                    destory.SetActive(false);
                    move.SetActive(false);
                }

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "smallHouse" && hit.collider.transform.parent.gameObject.transform.Find("Actual Residents").childCount != 0)
                {
                    destory.SetActive(false);
                    move.SetActive(false);
                }

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "townhall")
                {
                    destory.SetActive(false);
                }

                getMovingName = hit.collider.transform.parent.gameObject;
            }
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

    public void TaskOnClick()
    {
        if(hit.collider.transform.parent != null && hit.collider.transform.parent.name == "mine")
        {
            MineMenu.SetActive(true);
            movingObject.SetActive(false);
            hit.collider.transform.parent.GetComponent<Mine>().canSetStone = true;
        }

        if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "farm")
        {
            farmMenu.SetActive(true);
            movingObject.SetActive(false);
            hit.collider.transform.parent.GetComponent<Farm>().canSetWheat = true;
        }

        if (hit.collider.transform.parent != null && hit.collider.transform.parent.name == "lumberMill")
        {
            lumberMillMenu.SetActive(true);
            movingObject.SetActive(false);
            hit.collider.transform.parent.GetComponent<lumberMill>().canSetWood = true;
        }
    }

}