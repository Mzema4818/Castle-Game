using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public GameObject townhall;
    public GameObject farm;
    public GameObject smallHouse;
    public GameObject lumberMill;
    public GameObject Mine;
    public GameObject buildings;
    public GameObject noEnough;
    public GameObject BuilderNPCCanvas;
    public GameObject buildMenu;
    public GameObject buildCamera;
    public GameObject mainCamera;
    public GameObject townhallText;
    public GameObject townhallBuilder;
    public GameObject farmText;
    public GameObject farmBuilder;
    public GameObject inTheWay;
    public GameObject townHallName;
    public GameObject nameNotEnough;
    public GameObject isLongEnough;
    public GameObject townNameCanvas;
    public GameObject smallHouseText;
    public GameObject smallHouseBuilder;
    public GameObject lumberMillText;
    public GameObject lumberMillBuilder;
    public GameObject mineText;
    public GameObject mineBuilder;
    public GameObject crosshair;
    public GameObject hotbar;
    public InputField getTownName;
    public GameObject getMovingObject;
    public GameObject moveObject;
    public GameObject backMoveObject;
    public GameObject builderText;
    public GameObject smallHouseBuildCamera;
    public GameObject smallHouseBackCamera;
    public GameObject saviorCube;
    public GameObject fireResidents;
    public GameObject moveAndDestroy;
    public GameObject terrain;
    public GameObject ifSavedBefore;
    public GameObject moveCanvas;
    public GameObject backCanvas;
    public GameObject destroyCanvas;

    private Renderer TownHallrend;
    private Renderer Farmrend;
    private Renderer smallHouseRend;
    private Renderer lumberMillRend;
    private Renderer mineRend;

    private Vector3 pos;

    private GameObject getCrosshair;
    private Crosshair crosshairScript;
    public GameObject move;
    private Vector3 movedPos;
    private Renderer movedRend;

    public GameObject wood;
    public GameObject money;
    public GameObject stone;

    private TMP_Text moneyText;
    private string moneyValue;
    private int moneyCalc;
    private int newMoneyValue;

    private TMP_Text woodText;
    private string woodValue;
    private int woodCalc;
    private int newWoodValue;

    private TMP_Text stoneText;
    private string stoneValue;
    private int stoneCalc;
    private int newStoneValue;

    private bool willPlaceTownHall = false;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = GameObject.Find("Player").transform.position;

        woodText = wood.GetComponent<TMP_Text>();
        woodValue = woodText.text;
        woodCalc = int.Parse(woodValue);

        moneyText = money.GetComponent<TMP_Text>();
        moneyValue = moneyText.text;
        moneyCalc = int.Parse(moneyValue);

        stoneText = stone.GetComponent<TMP_Text>();
        stoneValue = stoneText.text;
        stoneCalc = int.Parse(stoneValue);
    }

    //building objects
    public void buildTownHall()
    {
        GameObject TownHallBuilding = Instantiate(townhall, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        TownHallBuilding.AddComponent<ColorChange>();
        TownHallBuilding.SetActive(true);
    }

    public void buildFarm()
    {
        GameObject FarmBuilding = Instantiate(farm, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        FarmBuilding.AddComponent<ColorChange>();
        FarmBuilding.SetActive(true);
    }

    public void buildSmallHouse()
    {
        GameObject smallHouseBuilding = Instantiate(smallHouse, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        smallHouseBuilding.AddComponent<ColorChange>();
        smallHouseBuilding.SetActive(true);
    }

    public void buildLumberMill()
    {
        GameObject LumberMill = Instantiate(lumberMill, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        LumberMill.AddComponent<ColorChange>();
        LumberMill.SetActive(true);
    }

    public void buildMine()
    {
        GameObject mine = Instantiate(Mine, pos, Quaternion.Euler(new Vector3(0, 0, 0)));
        mine.AddComponent<ColorChange>();
        mine.SetActive(true);
    }

    //placing objects
    public void placeTownHall()
    {
        GameObject TownHallBuilding = GameObject.Find("townhall(Clone)");
        GameObject scaffolding = TownHallBuilding.transform.GetChild(0).gameObject;
        TownHallrend = TownHallBuilding.GetComponentInChildren<Renderer>();

        if (stoneCalc >= 10 && moneyCalc >= 10 && woodCalc >= 10 && TownHallrend.material.color == Color.green)
        {
            Destroy(TownHallBuilding.GetComponent<FollowingBuilderCam>());
            Destroy(TownHallBuilding.GetComponent<ColorChange>());
            //TownHallBuilding.AddComponent<GroundFormation>();
            reChangeTerrain();
            //TownHallBuilding.GetComponent<GroundFormation>().changeVertices(true);

            townHallName.SetActive(true);
            noEnough.SetActive(false);
            BuilderNPCCanvas.SetActive(false);
            mainCamera.SetActive(true);
            buildCamera.SetActive(false);
            townhallText.SetActive(true);
            townhallBuilder.SetActive(false);
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
        }
        else if(TownHallrend.material.color == Color.red && !willPlaceTownHall)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            townhallBuilder.SetActive(false);
            inTheWay.SetActive(true);
        }
        else if (stoneCalc <= 10 || moneyCalc <= 10 || woodCalc <= 10)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            townhallBuilder.SetActive(false);
            noEnough.SetActive(true);
        }

        if (willPlaceTownHall)
        {
            willPlaceTownHall = false;
            TownHallBuilding.transform.SetParent(buildings.transform);
            TownHallBuilding.name = "townhall";
            townNameCanvas.SetActive(false);
            terrainChange(TownHallBuilding, 1, 1, 1, 0);
        }
    }

    public void actuallyPlaceTownHall()
    {
        if(getTownName.text.Length >= 1)
        {
            willPlaceTownHall = true;

        }
        else
        {
            isLongEnough.SetActive(true);
        }
    }

    public void placeFarm()
    {
        GameObject FarmBuilding = GameObject.Find("farm(Clone)");
        Farmrend = FarmBuilding.GetComponentInChildren<Renderer>();

        if (stoneCalc >= 15 && moneyCalc >= 15 && woodCalc >= 15 && Farmrend.material.color == Color.green)
        {
            Destroy(FarmBuilding.GetComponent<ColorChange>());
            Destroy(FarmBuilding.GetComponent<FollowingBuilderCam>());
            //FarmBuilding.AddComponent<GroundFormation>();
            reChangeTerrain();
            //FarmBuilding.GetComponent<GroundFormation>().changeVertices(true);

            FarmBuilding.transform.SetParent(buildings.transform);
            FarmBuilding.name = "farm";
            noEnough.SetActive(false);
            BuilderNPCCanvas.SetActive(false);
            mainCamera.SetActive(true);
            buildCamera.SetActive(false);
            farmText.SetActive(true);
            farmBuilder.SetActive(false);
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
            terrainChange(FarmBuilding, 1, 1, 1, 0);
        }
        else if (Farmrend.material.color == Color.red)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            farmBuilder.SetActive(false);
            inTheWay.SetActive(true);
        }
        else if (stoneCalc <= 15 || moneyCalc <= 15 || woodCalc <= 15)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            farmBuilder.SetActive(false);
            noEnough.SetActive(true);
        }
    }

    public void placeSmallHouse()
    {
        GameObject smallHouseBuilding = GameObject.Find("smallHouse(Clone)");
        smallHouseRend = smallHouseBuilding.GetComponentInChildren<Renderer>();

        if (stoneCalc >= 20 && moneyCalc >= 20 && woodCalc >= 20 && smallHouseRend.material.color == Color.green)
        {
            Destroy(smallHouseBuilding.GetComponent<ColorChange>());
            Destroy(smallHouseBuilding.GetComponent<FollowingBuilderCam>());
            //smallHouseBuilding.AddComponent<GroundFormation>();
            reChangeTerrain();
            //smallHouseBuilding.GetComponent<GroundFormation>().changeVertices(true);

            smallHouseBuilding.GetComponent<SmallHouse>().enabled = true;
            smallHouseBuilding.transform.SetParent(buildings.transform);
            smallHouseBuilding.name = "smallHouse";
            noEnough.SetActive(false);
            BuilderNPCCanvas.SetActive(false);
            mainCamera.SetActive(true);
            buildCamera.SetActive(false);
            smallHouseText.SetActive(true);
            smallHouseBuilder.SetActive(false);
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
            terrainChange(smallHouseBuilding, 1, 1, 1, 0);
        }
        else if (smallHouseRend.material.color == Color.red)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            smallHouseBuilder.SetActive(false);
            inTheWay.SetActive(true);
        }
        else if (stoneCalc <= 20 || moneyCalc <= 20 || woodCalc <= 20)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            smallHouseBuilder.SetActive(false);
            noEnough.SetActive(true);
        }
    }

    public void placeLumberMill()
    {
        GameObject lumberMillBuilding = GameObject.Find("lumberMill(Clone)");
        lumberMillRend = lumberMillBuilding.GetComponentInChildren<Renderer>();

        if (stoneCalc >= 25 && moneyCalc >= 25 && woodCalc >= 25 && lumberMillRend.material.color == Color.green)
        {
            Destroy(lumberMillBuilding.GetComponent<ColorChange>());
            Destroy(lumberMillBuilding.GetComponent<FollowingBuilderCam>());
            //lumberMillBuilding.AddComponent<GroundFormation>();
            reChangeTerrain();
            //lumberMillBuilding.GetComponent<GroundFormation>().changeVertices(true);

            lumberMillBuilding.transform.SetParent(buildings.transform);
            lumberMillBuilding.name = "lumberMill";
            noEnough.SetActive(false);
            BuilderNPCCanvas.SetActive(false);
            mainCamera.SetActive(true);
            buildCamera.SetActive(false);
            lumberMillText.SetActive(true);
            lumberMillBuilder.SetActive(false);
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
            terrainChange(lumberMillBuilding, 1, 1, 1, 0);

        }
        else if (lumberMillRend.material.color == Color.red)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            lumberMillBuilder.SetActive(false);
            inTheWay.SetActive(true);
        }
        else if (stoneCalc <= 25 || moneyCalc <= 25 || woodCalc <= 25)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            lumberMillBuilder.SetActive(false);
            noEnough.SetActive(true);
        }
    }

    public void placeMine()
    {
        GameObject mineBuilding = GameObject.Find("mine(Clone)");
        mineRend = mineBuilding.GetComponentInChildren<Renderer>();

        if (stoneCalc >= 30 && moneyCalc >= 30 && woodCalc >= 30 && mineRend.material.color == Color.green)
        {
            Destroy(mineBuilding.GetComponent<ColorChange>());
            Destroy(mineBuilding.GetComponent<FollowingBuilderCam>());
            //mineBuilding.AddComponent<GroundFormation>();
            reChangeTerrain();
            //mineBuilding.GetComponent<GroundFormation>().changeVertices(true);

            mineBuilding.transform.SetParent(buildings.transform);
            mineBuilding.name = "mine";
            noEnough.SetActive(false);
            BuilderNPCCanvas.SetActive(false);
            mainCamera.SetActive(true);
            buildCamera.SetActive(false);
            mineText.SetActive(true);
            mineBuilder.SetActive(false);
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
            terrainChange(mineBuilding, 1, 1, 1, 0);
        }
        else if (mineRend.material.color == Color.red)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            mineBuilder.SetActive(false);
            inTheWay.SetActive(true);
        }
        else if (stoneCalc <= 30 || moneyCalc <= 30 || woodCalc <= 30)
        {
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            mineBuilder.SetActive(false);
            noEnough.SetActive(true);
        }
    }

    //destorying bad objects
    public void destroyBadTownHall()
    {
        willPlaceTownHall = false;
        GameObject bad = GameObject.Find("townhall(Clone)");
        Destroy(bad.gameObject);
    }

    public void destroyBadFarm()
    {
        GameObject bad2 = GameObject.Find("farm(Clone)");
        Destroy(bad2.gameObject);
    }

    public void destroyBadSmallHouse()
    {
        GameObject bad3 = GameObject.Find("smallHouse(Clone)");
        Destroy(bad3.gameObject);
    }

    public void destroyBadlumberMill()
    {
        GameObject bad4 = GameObject.Find("lumberMill(Clone)");
        Destroy(bad4.gameObject);
    }

    public void destroyBadMine()
    {
        GameObject bad5 = GameObject.Find("mine(Clone)");
        Destroy(bad5.gameObject);
    }

    //moving objects
    public void movingObject()
    {
        for (int i = 0; i < buildCamera.transform.childCount; i++)
        {
            buildCamera.transform.GetChild(i).gameObject.SetActive(false);
        }

        getCrosshair = GameObject.Find("Main Camera");
        crosshairScript = getCrosshair.GetComponent<Crosshair>();
        mainCamera.SetActive(false);
        buildCamera.SetActive(true);
        move = crosshairScript.getMovingName;
        movedPos = move.transform.position;

        buildCamera.transform.position = new Vector3(move.transform.position.x, buildCamera.transform.position.y, move.transform.position.z);

        move.AddComponent<ColorChange>();
        move.AddComponent<FollowingBuilderCam>();
        move.GetComponent<FollowingBuilderCam>().stop = true;
        //move.GetComponent<GroundFormation>().revertVertices();
        //move.GetComponent<GroundFormation>().SimulateDestroy();
        //terrain.AddComponent<DestroyColliders>();
    }

    public void placingMovedObject()
    {
        movedRend = move.GetComponentInChildren<Renderer>();

        if (movedRend.material.color == Color.green)
        {
            Destroy(move.GetComponent<ColorChange>());
            Destroy(move.GetComponent<FollowingBuilderCam>());
            //move.GetComponent<GroundFormation>().changeVertices(true);
            reChangeTerrain();
            noEnough.SetActive(false);
            BuilderNPCCanvas.SetActive(false);
            builderText.SetActive(true);
            mainCamera.SetActive(true);
            buildCamera.SetActive(false);
            buildMenu.SetActive(false);
            crosshair.SetActive(true);
            hotbar.SetActive(true);
            moveObject.SetActive(false);
            backMoveObject.SetActive(false);
            //move.GetComponent<GroundFormation>().Replace();
        }
        else if (movedRend.material.color == Color.red)
        {
            builderText.SetActive(false);
            BuilderNPCCanvas.SetActive(true);
            buildMenu.SetActive(false);
            inTheWay.SetActive(true);
        }
    }

    public void backMovedObject()
    {
        Destroy(move.GetComponent<ColorChange>());
        Destroy(move.GetComponent<FollowingBuilderCam>());
        reChangeTerrain();
        //move.transform.position = new Vector3(movedPos.x, move.transform.position.y, movedPos.z);
        move.transform.position = movedPos;
        //move.GetComponent<GroundFormation>().changeVertices(false);
    }

    //destroying objects
    [System.Obsolete]
    public void destroyObject()
    {
        getCrosshair = GameObject.Find("Main Camera");
        crosshairScript = getCrosshair.GetComponent<Crosshair>();
        move = crosshairScript.getMovingName;
        //move.GetComponent<GroundFormation>().revertVertices();
        reChangeTerrain();

        if (move.name == "farm")
        {
            if (move.gameObject.transform.Find("Farmers").childCount != 0)
            {
                fireResidents.SetActive(true);
            }
            else
            {
                Destroy(move);
                moveAndDestroy.SetActive(false);
                crosshair.SetActive(true);
                moveCanvas.SetActive(true);
                backCanvas.SetActive(true);
                destroyCanvas.SetActive(true);
            }
        }
        if (move.name == "mine")
        {
            if (move.gameObject.transform.Find("Miners").childCount != 0)
            {
                fireResidents.SetActive(true);
            }
            else
            {
                Destroy(move);
                moveAndDestroy.SetActive(false);
                crosshair.SetActive(true);
                moveCanvas.SetActive(true);
                backCanvas.SetActive(true);
                destroyCanvas.SetActive(true);
            }
        }
        if (move.name == "smallHouse")
        {
            /* for (int i = 0; i < move.transform.Find("Actual Residents").GetChildCount(); i++)
            {
                move.transform.Find("Actual Residents").gameObject.transform.GetChild(i).gameObject.GetComponent<Resident>().backHome = true;
                move.transform.Find("Actual Residents").gameObject.transform.GetChild(i).parent = null;
            }*/

            Destroy(move);
            moveAndDestroy.SetActive(false);
            crosshair.SetActive(true);
            moveCanvas.SetActive(true);
            backCanvas.SetActive(true);
            destroyCanvas.SetActive(true);
        }
        if (move.name == "lumberMill")
        {
            if (move.gameObject.transform.Find("LumberJacks").childCount != 0)
            {
                fireResidents.SetActive(true);
            }
            else
            {
                Destroy(move);
                moveAndDestroy.SetActive(false);
                crosshair.SetActive(true);
                moveCanvas.SetActive(true);
                backCanvas.SetActive(true);
                destroyCanvas.SetActive(true);
            }
        }
    }

    //redo terrain collider
    private void redoCollider()
    {
        //Destroy(GameObject.Find("GrassTerrain"));
    }

    private void terrainChange(GameObject objectName, int x, int y, int z, float offset)
    {
        //objectName.AddComponent<GroundFormation>();
        //objectName.GetComponent<GroundFormation>().objectScaleX = x;
        //objectName.GetComponent<GroundFormation>().objectScaleY = y;
        //objectName.GetComponent<GroundFormation>().objectScaleZ = 1;
        //objectName.GetComponent<GroundFormation>().offset = offset;
        //redoCollider();
    }

    public void reChangeTerrain()
    {
        for(int i = 0; i < buildings.transform.childCount; i++)
        {
            //buildings.transform.GetChild(i).GetComponent<GroundFormation>().changeVerticesWithOutPoint();
        }
    }
}