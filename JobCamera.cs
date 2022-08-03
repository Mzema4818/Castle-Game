using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobCamera : MonoBehaviour
{
    public GameObject actualBuildings;
    public GameObject jobBoard;
    public GameObject arrowRight;
    public GameObject arrowLeft;
    public GameObject back;
    public GameObject hire;
    public GameObject residentHome;
    public GameObject farmer;
    public GameObject LumberJack;
    public GameObject miner;
    public GameObject jobsHome;
    public GameObject jobMenu;
    public GameObject mainCamera;
    public GameObject crossHair;
    public GameObject hotbar;
    public GameObject tooManyFarmers;
    public GameObject residents;
    public GameObject realResidents;
    public GameObject crossHairObject;
    public GameObject jobCamera;

    public GameObject farmerJobBoard;
    public GameObject lumberJackJobBoard;
    public GameObject minerJobBoard;
    public bool displayFarmer;
    public bool displayLumberJack;
    public bool displayMiner;

    public float height = 200;

    private GameObject getCrosshair;
    private Crosshair crosshairScript;
    private GameObject move;

    public int positionNum;

    private int[] farmObjects = new int[0];
    private int[] farmObjectsPosition = new int[0];
    private int numberOfFarmObjects = 0;
    private int[] LumberMillObjects = new int[0];
    private int[] LumberMillPosition = new int[0];
    private int numberOfLumberMillObjects = 0;
    private int[] MineObjects = new int[0];
    private int[] MinePosition = new int[0];
    private int numberOfMineObjects = 0;
    private int num1 = 0;
    private int num2 = 0;
    private int num3 = 0;
    private bool farmingJob;
    private bool lumberMillJob;
    private bool mineJob;
    private GameObject farmerHome;

    // Start is called before the first frame update
    void Start()
    {
        numberOfFarmObjects = 0;
        numberOfLumberMillObjects = 0;
        numberOfMineObjects = 0;
        num1 = 0;
        num2 = 0;
        num3 = 0;
        farmingJob = false;
        lumberMillJob = false;
        mineJob = false;
    }

    private void Update()
    {
        Transform[] children = new Transform[actualBuildings.transform.childCount];
        for (int i = 0; i < actualBuildings.transform.childCount; i++)
        {
            children[i] = actualBuildings.transform.GetChild(i);
        }

        farmerJobBoard.SetActive(false);
        minerJobBoard.SetActive(false);
        lumberJackJobBoard.SetActive(false);

        foreach (Transform building in children)
        {
            if(building.name == "farm")
            {
                farmerJobBoard.SetActive(true);
            }
            else if (building.name == "mine")
            {
                minerJobBoard.SetActive(true);
            }
            else if(building.name == "lumberMill")
            {
                lumberJackJobBoard.SetActive(true);
            }
        }
    }

    public void FarmJob()
    {
        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if (actualBuildings.transform.GetChild(i).name == "farm")
            {
                numberOfFarmObjects++; 
            }
        }

        farmObjects = new int[numberOfFarmObjects];

        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if(actualBuildings.transform.GetChild(i).name == "farm")
            {
                farmObjects[num1] = i;
                num1 += 1;
            }
        }
        numberOfFarmObjects = 0;
        num1 = 0;
        jobBoard.SetActive(false);
        arrowRight.SetActive(true);
        arrowLeft.SetActive(true);
        back.SetActive(true);
        hire.SetActive(true);
        lumberMillJob = false;
        mineJob = false;
        farmingJob = true;
        jobCamera.transform.position = new Vector3(actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.z);
    }

    public void LumberMillJob()
    {
        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if (actualBuildings.transform.GetChild(i).name == "lumberMill")
            {
                numberOfLumberMillObjects++;
            }
        }

        LumberMillObjects = new int[numberOfLumberMillObjects];

        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if (actualBuildings.transform.GetChild(i).name == "lumberMill")
            {
                LumberMillObjects[num2] = i;
                num2 += 1;
            }
        }
        numberOfLumberMillObjects = 0;
        num2 = 0;
        jobBoard.SetActive(false);
        arrowRight.SetActive(true);
        arrowLeft.SetActive(true);
        back.SetActive(true);
        hire.SetActive(true);
        farmingJob = false;
        mineJob = false;
        lumberMillJob = true;
        jobCamera.transform.position = new Vector3(actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.z);
    }

    public void MineJob()
    {
        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if (actualBuildings.transform.GetChild(i).name == "mine")
            {
                numberOfMineObjects++;
            }
        }

        MineObjects = new int[numberOfMineObjects];

        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if (actualBuildings.transform.GetChild(i).name == "mine")
            {
                MineObjects[num3] = i;
                num3 += 1;
            }
        }
        numberOfMineObjects = 0;
        num3 = 0;
        jobBoard.SetActive(false);
        arrowRight.SetActive(true);
        arrowLeft.SetActive(true);
        back.SetActive(true);
        hire.SetActive(true);
        farmingJob = false;
        lumberMillJob = false;
        mineJob = true;
        jobCamera.transform.position = new Vector3(actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.z);
    }

    [System.Obsolete]
    public void hireResident()
    {
        if (farmingJob)
        {
            if (actualBuildings.transform.GetChild(farmObjects[positionNum]).name == "farm")
            {
                if (actualBuildings.transform.GetChild(farmObjects[positionNum]).GetComponent<Farm>().workers < actualBuildings.transform.GetChild(farmObjects[positionNum]).GetComponent<Farm>().maxFarmers)
                {
                    residentHome.transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    residentHome.GetComponent<Resident>().TaskOnClick();
                    residentHome.GetComponent<Resident>().hasJob = true;
                    residentHome.GetComponent<Resident>().jobHome = actualBuildings.transform.GetChild(farmObjects[positionNum]).gameObject;
                    actualBuildings.transform.GetChild(farmObjects[positionNum]).gameObject.GetComponent<Farm>().workers++;
                    residentHome.GetComponent<Resident>().JobDoor = actualBuildings.transform.GetChild(farmObjects[positionNum]).FindChild("Door").gameObject;

                    mainCamera.SetActive(true);
                    crossHair.SetActive(true);
                    hotbar.SetActive(true);
                    jobBoard.SetActive(false);
                    arrowRight.SetActive(false);
                    arrowLeft.SetActive(false);
                    back.SetActive(false);
                    hire.SetActive(false);
                    jobMenu.SetActive(false);
                }
                else
                {
                    tooManyFarmers.SetActive(true);
                }
            }
        }

        if (lumberMillJob)
        {
            if (actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).name == "lumberMill")
            {
                if (actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).GetComponent<lumberMill>().workers < actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).GetComponent<lumberMill>().maxLumberJacks)
                {
                    residentHome.transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.red;
                    residentHome.GetComponent<Resident>().TaskOnClick();
                    residentHome.GetComponent<Resident>().hasJob = true;
                    residentHome.GetComponent<Resident>().jobHome = actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).gameObject;
                    actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).gameObject.GetComponent<lumberMill>().workers++;
                    residentHome.GetComponent<Resident>().JobDoor = actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).FindChild("Door").gameObject;

                    mainCamera.SetActive(true);
                    crossHair.SetActive(true);
                    hotbar.SetActive(true);
                    jobBoard.SetActive(false);
                    arrowRight.SetActive(false);
                    arrowLeft.SetActive(false);
                    back.SetActive(false);
                    hire.SetActive(false);
                    jobMenu.SetActive(false);
                }
                else
                {
                    tooManyFarmers.SetActive(true);
                }
            }
        }

        if (mineJob)
        {
            if (actualBuildings.transform.GetChild(MineObjects[positionNum]).name == "mine")
            {
                if (actualBuildings.transform.GetChild(MineObjects[positionNum]).GetComponent<Mine>().workers < actualBuildings.transform.GetChild(MineObjects[positionNum]).GetComponent<Mine>().maxMiners)
                {
                    residentHome.transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    residentHome.GetComponent<Resident>().TaskOnClick();
                    residentHome.GetComponent<Resident>().hasJob = true;
                    residentHome.GetComponent<Resident>().jobHome = actualBuildings.transform.GetChild(MineObjects[positionNum]).gameObject;
                    actualBuildings.transform.GetChild(MineObjects[positionNum]).gameObject.GetComponent<Mine>().workers++;
                    residentHome.GetComponent<Resident>().JobDoor = actualBuildings.transform.GetChild(MineObjects[positionNum]).FindChild("Door").gameObject;

                    mainCamera.SetActive(true);
                    crossHair.SetActive(true);
                    hotbar.SetActive(true);
                    jobBoard.SetActive(false);
                    arrowRight.SetActive(false);
                    arrowLeft.SetActive(false);
                    back.SetActive(false);
                    hire.SetActive(false);
                    jobMenu.SetActive(false);
                }
                else
                {
                    tooManyFarmers.SetActive(true);
                }
            }
        }
    }

    public void FireResident()
    {
        getCrosshair = GameObject.Find("Main Camera");
        crosshairScript = getCrosshair.GetComponent<Crosshair>();
        move = crosshairScript.getMovingName;

        crossHairObject.SetActive(true);
        Destroy(move);

        if(move.name == "farmer")
        {
            move.transform.parent.parent.GetComponent<Farm>().Farmers -= 1;
        }

        if (move.name == "lumberJack")
        {
            move.transform.parent.parent.GetComponent<lumberMill>().LumberJacks -= 1;
        }

        if (move.name == "miner")
        {
            move.transform.parent.parent.GetComponent<Mine>().Miners -= 1;
        }

        for (int i = 0; i < actualBuildings.transform.childCount; ++i)
        {
            if (actualBuildings.transform.GetChild(i).name == "smallHouse" && actualBuildings.transform.GetChild(i).GetComponent<SmallHouse>().maxResidents < 4)
            {
                GameObject resident = Instantiate(residents, new Vector3(actualBuildings.transform.GetChild(i).transform.position.x + 10, actualBuildings.transform.GetChild(i).transform.position.y + 3, actualBuildings.transform.GetChild(i).transform.position.z), Quaternion.identity);
                realResidents = actualBuildings.transform.GetChild(i).gameObject.transform.Find("Actual Residents").gameObject;
                resident.transform.SetParent(realResidents.transform);
                resident.name = "resident";
                resident.SetActive(true);
                actualBuildings.transform.GetChild(i).GetComponent<SmallHouse>().Residents += 1;
                actualBuildings.transform.GetChild(i).GetComponent<SmallHouse>().maxResidents += 1;
                break;
            }
        }
    }
    public void rightArrow()
    {
        if (farmingJob)
        {
            positionNum++;
            if (positionNum == farmObjects.Length)
            {
                positionNum = 0;
            }
            Vector3 position = new Vector3(actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.z);
            jobCamera.transform.position = position;
        }

        if (lumberMillJob)
        {
            positionNum++;
            if (positionNum == LumberMillObjects.Length)
            {
                positionNum = 0;
            }
            Vector3 position = new Vector3(actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.z);
            jobCamera.transform.position = position;
        }

        if (mineJob)
        {
            positionNum++;
            if (positionNum == MineObjects.Length)
            {
                positionNum = 0;
            }
            Vector3 position = new Vector3(actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.z);
            jobCamera.transform.position = position;
        }
    }

    public void leftArrow()
    {
        if (farmingJob)
        {
            positionNum--;
            if (positionNum == -1)
            {
                positionNum = farmObjects.Length - 1;
            }
            Vector3 position = new Vector3(actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(farmObjects[positionNum]).transform.position.z);
            jobCamera.transform.position = position;
        }

        if (lumberMillJob)
        {
            positionNum--;
            if (positionNum == -1)
            {
                positionNum = LumberMillObjects.Length - 1;
            }
            Vector3 position = new Vector3(actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(LumberMillObjects[positionNum]).transform.position.z);
            jobCamera.transform.position = position;
        }

        if (mineJob)
        {
            positionNum--;
            if (positionNum == -1)
            {
                positionNum = MineObjects.Length - 1;
            }
            Vector3 position = new Vector3(actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.x, actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.y - height, actualBuildings.transform.GetChild(MineObjects[positionNum]).transform.position.z);
            jobCamera.transform.position = position;
        }
    }

    public void backButton()
    {
        farmingJob = false;
    }
}
