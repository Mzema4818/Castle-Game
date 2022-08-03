using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public GameObject woodObject;
    public GameObject moneyObject;
    public GameObject stoneObject;
    public GameObject wheatObject;
    public GameObject gameSaved;
    public GameObject forestGenerator;
    public GameObject navBaker;
    public Shader shader;

    public InputField getTownName;
    public string townName;
    public int seed;

    private TMP_Text moneyText;
    private string moneyValue;
    public int moneyCalc;
    public int money;

    private TMP_Text woodText;
    private string woodValue;
    public int woodCalc;
    public int wood;

    private TMP_Text stoneText;
    private string stoneValue;
    public int stoneCalc;
    public int stone;

    private TMP_Text wheatText;
    private string wheatValue;
    public int wheatCalc;
    public int wheat;

    public string[] buildingNames;
    public float[] postition;

    public int children;
    public int tree;
    public int rock;
    public int numberOfChildren;
    public int getNumberOfResidents;
    public int getNumberOfMaxResidents;
    public int getNumberOfFarmers;
    public int getNumberOfWheat;
    public int getNumberOfLumberJacks;
    public int getNumberOfWood;
    public int getNumberOfMiners;
    public int getNumberOfStone;
    public int getNumberOfResidentJob;
    public int getNumberOfVertexPoints;

    public string[] building = new string[0];
    public Vector3[] position = new Vector3[0];
    public Quaternion[] rotation = new Quaternion[0];
    public Vector3[] treePosition = new Vector3[0];
    public Quaternion[] treeRotation = new Quaternion[0];
    public string[] treeNames = new string[0];
    public string[] rockNames = new string[0];
    public Vector3[] rockPosition = new Vector3[0];
    public Quaternion[] rockRotation = new Quaternion[0];
    public int[] numberOfResidents = new int[0];
    public int[] numberOfMaxResidents = new int[0];
    public int[] numberOfFarmers = new int[0];
    public int[] numberOfWheat = new int[0];
    public int[] numberOfLumberJacks = new int[0];
    public int[] numberOfWood = new int[0];
    public int[] numberOfMiners = new int[0];
    public int[] numberOfStone = new int[0];
    public Vector3[] residentJobs = new Vector3[0];
    public Vector3[] vertexPoints = new Vector3[0];

    public float[] actualPos;
    public Vector3[] realPos;

    public float[] actualTreePos;
    public Vector3[] realTreePos;

    public float[] actualTreeRos;
    public Quaternion[] realTreeRos;

    public float[] actualRockPos;
    public Vector3[] realRockPos;

    public float[] actualRockRos;
    public Quaternion[] realRockRos;

    public float[] actualRot;
    public Quaternion[] realRot;

    public int[] realNumberOfResidents;
    public int[] realNumberOfMaxResidents;
    public int[] realNumberOfFarmers;
    public int[] realNumberOfLumberJacks;
    public int[] realNumberOfMiners;
    public int[] realNumberOfWheat;
    public int[] realNumberOfWood;
    public int[] realNumberOfStone;

    public int num = 0;
    public int num2 = 0;
    public int num3 = 0;
    public int num4 = 0;
    public int num5 = 0;
    public int newNum = 0;
    public int newestNum = 0;
    public bool canSpawn;
    public bool canLoad = true;
    public bool canDestroy = true;

    public GameObject townhall;
    public GameObject farm;
    public GameObject buildings;
    public GameObject getTownNameInput;
    public GameObject onlyOneTownHall;
    public GameObject farms;
    public GameObject mines;
    public GameObject lumbermills;
    public GameObject smallHouse;
    public GameObject smallHouses;
    public GameObject lumberMill;
    public GameObject mine;
    public GameObject resident;
    public GameObject realResidents;
    public GameObject Door;
    public GameObject realFarmers;
    public GameObject realLumberJacks;
    public GameObject realMiners;
    public GameObject residents;
    public GameObject farmers;
    public GameObject lumberJacks;
    public GameObject Miners;
    public GameObject LoadIsOnCoolDown;
    public GameObject treeTransform;
    public GameObject rockTransform;
    public GameObject treeObject;
    public GameObject rockObject;
    public GameObject saviorCube;

    public NoiseData noiseData;

    private MeshCollider meshCollider;

    public GameObject terrain;
    Mesh mesh;
    public bool oneOriginalVertices;

    public float[] getJobHome;
    public float[] getVertexPoint;

    public float[] verticesFloat;
    public Vector3[] vertices;

    public float[] originalVerticesFloat;
    public Vector3[] originalVertices;

    public bool canChangeVertices;
    public int groundLayer;



    public LightingManager dayNight;
    public int numberOfDays;
    public float timeOfDay;

    private void Awake()
    {
        //noiseData = (NoiseData)FindObjectOfType(typeof(NoiseData));
    }

    private void Start()
    {
        num = 0;
        num2 = 0;
        num3 = 0;
        num4 = 0;
        num5 = 0;
        newNum = 0;
        newestNum = 0;
        canLoad = true;
        canSpawn = true;
        canDestroy = true;
        oneOriginalVertices = false;
        canChangeVertices = false;
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        meshCollider = terrain.GetComponent<MeshCollider>();
        vertices = new Vector3[mesh.vertices.Length];
        groundLayer = LayerMask.NameToLayer("Ground");
        //originalVertices = new Vector3[mesh.vertices.Length];
        //realResidents = GameObject.Find("Actual Residents");
    }

    // Update is called once per frame
    void Update()
    {
        if (getTownNameInput.activeSelf == true) {
            townName = getTownName.text;
        }

        seed = noiseData.seed;
        numberOfDays = dayNight.numberOfDays;
        timeOfDay = dayNight.TimeOfDay;
        //print(seed);

        children = transform.childCount;
        tree = treeTransform.transform.childCount;
        rock = rockTransform.transform.childCount;

        postition = new float[transform.childCount];
        actualPos = new float[transform.childCount * 3];

        woodText = woodObject.GetComponent<TMP_Text>();
        woodValue = woodText.text;
        woodCalc = int.Parse(woodValue);

        moneyText = moneyObject.GetComponent<TMP_Text>();
        moneyValue = moneyText.text;
        moneyCalc = int.Parse(moneyValue);

        stoneText = stoneObject.GetComponent<TMP_Text>();
        stoneValue = stoneText.text;
        stoneCalc = int.Parse(stoneValue);

        wheatText = wheatObject.GetComponent<TMP_Text>();
        wheatValue = wheatText.text;
        wheatCalc = int.Parse(wheatValue);

        building = new string[transform.childCount];
        position = new Vector3[transform.childCount];
        rotation = new Quaternion[transform.childCount];

        treePosition = new Vector3[treeTransform.transform.childCount];
        treeRotation = new Quaternion[treeTransform.transform.childCount];

        treeNames = new string[treeTransform.transform.childCount];
        rockNames = new string[rockTransform.transform.childCount];

        rockPosition = new Vector3[rockTransform.transform.childCount];
        rockRotation = new Quaternion[rockTransform.transform.childCount];

        vertexPoints = new Vector3[children];
    }

    //functions for PlayerData
    public void getSmallHouse()
    {
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "smallHouse")
            {
                num2++;
            }
        }
        numberOfResidents = new int[num2];
        numberOfMaxResidents = new int[num2];
        num2 = 0;
    }

    public void getFarm()
    {
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "farm")
            {
                num++;
            }
        }
        numberOfFarmers = new int[num];
        numberOfWheat = new int[num];
        num = 0;
    }

    public void getLumberMill()
    {
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "lumberMill")
            {
                num4++;
            }
        }
        numberOfLumberJacks = new int[num4];
        numberOfWood = new int[num4];
        num4 = 0;
    }

    public void getMine()
    {
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "mine")
            {
                num5++;
            }
        }
        numberOfMiners = new int[num5];
        numberOfStone = new int[num5];
        num5 = 0;
    }

    public string[] getBuildings()
    {
        for (int i = 0; i < children; ++i)
        {
            building[i] = transform.GetChild(i).name;
        }

        return building;
    }

    public Vector3[] getOriginalVertices()
    {
        return originalVertices; 
    }

    public Vector3[] getVertices()
    {
        return vertices;
    }

    public bool getOneOriginalVertices()
    {
        return oneOriginalVertices;
    }

    public Vector3[] getPosition()
    {
        for (int i = 0; i < children; ++i)
        {
            position[i] = transform.GetChild(i).position;
        }

        return position;
    }

    public Quaternion[] getRotation()
    {
        for (int i = 0; i < children; ++i)
        {
            rotation[i] = transform.GetChild(i).rotation;
        }

        return rotation;
    }

    public int[] getResidents()
    {
        int i2 = 0;
        getSmallHouse();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "smallHouse")
            {
               numberOfResidents[i2] = transform.GetChild(i).GetComponent<SmallHouse>().Residents;
                i2++;
                //print(transform.GetChild(i).GetComponent<SmallHouse>().Residents); 
            }
        }
        //print(numberOfResidents.Length);
        return numberOfResidents;
    }

    public Vector3[] GetJobHome()
    {
        int total = 0;
        getResidents();
        foreach (int num in numberOfResidents)
        {
            total += num;
        }

        residentJobs = new Vector3[total];

        int i3 = 0;
        for (int i = 0; i < children; i++)
        {
            if (transform.GetChild(i).name == "smallHouse")
            {
                foreach (Transform transform in transform.GetChild(i))
                {
                    if (transform.name == "Actual Residents")
                    {
                        foreach (Transform transform1 in transform)
                        {
                            try
                            {
                                residentJobs[i3] = transform1.GetComponent<Resident>().jobHome.transform.localPosition;
                            }
                            catch
                            {

                            }
                            i3++;
                        }
                    }
                }
            }
        }

        return residentJobs;
    }

    public Vector3[] getVertexPoints()
    {
        for (int i = 0; i < children; ++i)
        {
            //vertexPoints[i] = transform.GetChild(i).GetComponent<GroundFormation>().point;
        }

        return vertexPoints;
    }

    public int[] getWheatValue()
    {
        int i3 = 0;
        getFarm();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "farm")
            {
                numberOfWheat[i3] = transform.GetChild(i).GetComponent<Farm>().wheat;
                i3++;
            }
        }
        return numberOfWheat;
    }

    public int[] getWoodValue()
    {
        int i4 = 0;
        getLumberMill();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "lumberMill")
            {
                numberOfWood[i4] = transform.GetChild(i).GetComponent<lumberMill>().wood;
                i4++;
            }
        }
        return numberOfWood;
    }

    public int[] getStoneValue()
    {
        int i4 = 0;
        getMine();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "mine")
            {
                numberOfStone[i4] = transform.GetChild(i).GetComponent<Mine>().stone;
                i4++;
            }
        }
        return numberOfStone;
    }

    public int[] getMaxResidents()
    {
        int i2 = 0;
        getSmallHouse();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "smallHouse")
            {
                numberOfMaxResidents[i2] = transform.GetChild(i).GetComponent<SmallHouse>().maxResidents;
                i2++;
                //print(transform.GetChild(i).GetComponent<SmallHouse>().Residents);
            }
        }
        //print(numberOfResidents.Length);
        return numberOfMaxResidents;
    }

    public int[] getFarmers()
    {
        int i2 = 0;
        getFarm();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "farm")
            {
                numberOfFarmers[i2] = transform.GetChild(i).GetComponent<Farm>().Farmers;
                i2++;
                //print(transform.GetChild(i).GetComponent<Farm>().Farmers);
            }
        }
        return numberOfFarmers;
    }

    public int[] getLumberJacks()
    {
        int i2 = 0;
        getLumberMill();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "lumberMill")
            {
                numberOfLumberJacks[i2] = transform.GetChild(i).GetComponent<lumberMill>().LumberJacks;
                i2++;
                //print(transform.GetChild(i).GetComponent<Farm>().Farmers);
            }
        }
        return numberOfLumberJacks;
    }

    public int[] getMiners()
    {
        int i2 = 0;
        getMine();
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).name == "mine")
            {
                numberOfMiners[i2] = transform.GetChild(i).GetComponent<Mine>().Miners;
                i2++;
                //print(transform.GetChild(i).GetComponent<Farm>().Farmers);
            }
        }
        return numberOfMiners;
    }

    public Vector3[] getTreePos()
    {
        for (int i = 0; i < tree; ++i)
        {
            treePosition[i] = treeTransform.transform.GetChild(i).position;
        }
        return treePosition;
    }

    public Quaternion[] getTreeRos()
    {
        for (int i = 0; i < tree; ++i)
        {
            treeRotation[i] = treeTransform.transform.GetChild(i).rotation;
        }

        return treeRotation;
    }
    public string[] getTreeName()
    {
        for (int i = 0; i < tree; ++i)
        {
            treeNames[i] = treeTransform.transform.GetChild(i).name;
        }

        return treeNames;
    }
    public string[] getRockName()
    {
        for (int i = 0; i < rock; ++i)
        {
            rockNames[i] = rockTransform.transform.GetChild(i).name;
        }

        return rockNames;
    }

    public Vector3[] getRockPos()
    {
        for (int i = 0; i < rock; ++i)
        {
            rockPosition[i] = rockTransform.transform.GetChild(i).position;
        }
        return rockPosition;
    }

    public Quaternion[] getRockRos()
    {
        for (int i = 0; i < rock; ++i)
        {
            rockRotation[i] = rockTransform.transform.GetChild(i).rotation;
        }

        return rockRotation;
    }

    //timer
    IEnumerator ExampleCoroutine()
    {
        gameSaved.SetActive(true);

        yield return new WaitForSeconds(2);

        SaveSystem.SaveItems(this);
        gameSaved.SetActive(false);
    }

    //saving and loading
    public void SavePlayer()
    {
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        dayNight.startSun = true;
      
        if (!oneOriginalVertices)
        {
            originalVertices = mesh.vertices;
            oneOriginalVertices = true;
        }

        vertices = mesh.vertices;
        SaveSystem.SaveItems(this);
        StartCoroutine(ExampleCoroutine());
    }

    [System.Obsolete]
    public void LoadPlayer()
    {
        foreach (Transform child in buildings.transform)
        {
            Destroy(child.gameObject);
        }

        dayNight.startSun = true;

        PlayerData data = SaveSystem.loadPlayer();

        int i3 = 0;
        int i4 = 0;
        int i5 = 0;
        int i7 = 0;
        numberOfChildren = data.numberOfChildren;
        tree = data.numberOfTrees;
        rock = data.numberOfRocks;
        getNumberOfResidents = data.getNumberOfResidents;
        getNumberOfMaxResidents = data.getNumberOfMaxResidents;
        getNumberOfFarmers = data.getNumberOfFarmers;
        getNumberOfLumberJacks = data.getNumberOfLumberJacks;
        getNumberOfMiners = data.getNumberOfMiners;
        getNumberOfWheat = data.getNumberOfWheat;
        getNumberOfWood = data.getNumberOfWood;
        getNumberOfStone = data.getNumberOfStone;
        oneOriginalVertices = data.oneOriginalVertices;
        moneyCalc = data.money;
        woodCalc = data.wood;
        stoneCalc = data.stone;
        wheatCalc = data.wheat;
        townName = data.townName;
        seed = data.seed;
        numberOfDays = data.numberOfDays;
        timeOfDay = data.timeOfDay;
        dayNight.numberOfDays = numberOfDays;
        dayNight.TimeOfDay = timeOfDay;
        noiseData.setLoadSeed(seed);

        print(seed);
        //terrain.AddComponent<GetVertices>();

        buildingNames = data.buildingNames;
        actualPos = data.postition;
        actualRot = data.rotation;
        actualTreePos = data.treePostition;
        actualTreeRos = data.treeRotation;
        actualRockPos = data.rockPostition;
        actualRockRos = data.rockRotation;
        treeNames = data.treeNames;
        rockNames = data.rockNames;
        originalVerticesFloat = data.originalVertices;
        verticesFloat = data.vertices;
        getJobHome = data.numberOfJobs;
        getVertexPoint = data.vertexPoints;

        originalVertices = new Vector3[originalVerticesFloat.Length / 3];
        vertices = new Vector3[verticesFloat.Length / 3];
        residentJobs = new Vector3[getJobHome.Length / 3];
        vertexPoints = new Vector3[getVertexPoint.Length / 3];
        realPos = new Vector3[numberOfChildren];
        realTreePos = new Vector3[tree];
        realTreeRos = new Quaternion[tree];
        realRockPos = new Vector3[rock];
        realRockRos = new Quaternion[rock];
        realRot = new Quaternion[numberOfChildren];
        realNumberOfResidents = new int[getNumberOfResidents];
        realNumberOfResidents = data.numberOfResidents;
        realNumberOfMaxResidents = new int[getNumberOfMaxResidents];
        realNumberOfMaxResidents = data.numberOfMaxResidents;
        realNumberOfFarmers = new int[getNumberOfFarmers];
        realNumberOfFarmers = data.numberOfFarmers;
        realNumberOfLumberJacks = new int[getNumberOfLumberJacks];
        realNumberOfLumberJacks = data.numberOfLumberJacks;
        realNumberOfMiners = new int[getNumberOfMiners];
        realNumberOfMiners = data.numberOfMiners;
        realNumberOfWheat = new int[getNumberOfWheat];
        realNumberOfWheat = data.numberOfWheat;
        realNumberOfWood = new int[getNumberOfWood];
        realNumberOfWood = data.numberOfWood;
        realNumberOfStone = new int[getNumberOfStone];
        realNumberOfStone = data.numberOfStone;

        woodText.text = woodCalc.ToString();
        stoneText.text = stoneCalc.ToString();
        moneyText.text = moneyCalc.ToString();
        wheatText.text = wheatCalc.ToString();

        //for vertices
        
        for (int i = 0; i < (originalVertices.Length * 3); i += 3)
        {
            originalVertices[i / 3] = new Vector3(originalVerticesFloat[i], originalVerticesFloat[i + 1], originalVerticesFloat[i + 2]);
        }

        for (int i = 0; i < (vertices.Length * 3); i += 3)
        {
            vertices[i / 3] = new Vector3(verticesFloat[i], verticesFloat[i + 1], verticesFloat[i + 2]);
            //vertices[i / 3] = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < (residentJobs.Length * 3); i += 3)
        {
            residentJobs[i / 3] = new Vector3(getJobHome[i], getJobHome[i + 1], getJobHome[i + 2]);
            //vertices[i / 3] = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < (vertexPoints.Length * 3); i += 3)
        {
            vertexPoints[i / 3] = new Vector3(getVertexPoint[i], getVertexPoint[i + 1], getVertexPoint[i + 2]);
            //print(vertexPoints[i]);
            //vertices[i / 3] = new Vector3(1, 1, 1);
        }

        //terrain.AddComponent<updateVertices>();
        //terrain.GetComponent<updateVertices>().vertices = vertices;

        //for pos and rot
        for (int i = 0; i < (numberOfChildren * 3); i += 3)
        {
            realPos[i / 3] = new Vector3(actualPos[i], actualPos[i + 1], actualPos[i + 2]);
        }

        for (int i = 0; i < (numberOfChildren * 4); i += 4)
        {
            realRot[i / 4] = new Quaternion(actualRot[i], actualRot[i + 1], actualRot[i + 2], actualRot[i + 3]);
        }

        //for tree and rock pos and rot
        for (int i = 0; i < (tree * 3); i += 3)
        {
            realTreePos[i / 3] = new Vector3(actualTreePos[i], actualTreePos[i + 1], actualTreePos[i + 2]);
        }

        for (int i = 0; i < (tree * 4); i += 4)
        {
            realTreeRos[i / 4] = new Quaternion(actualTreeRos[i], actualTreeRos[i + 1], actualTreeRos[i + 2], actualTreeRos[i + 3]);
        }

        for (int i = 0; i < (rock * 3); i += 3)
        {
            realRockPos[i / 3] = new Vector3(actualRockPos[i], actualRockPos[i + 1], actualRockPos[i + 2]);
        }

        for (int i = 0; i < (rock * 4); i += 4)
        {
            realRockRos[i / 4] = new Quaternion(actualRockRos[i], actualRockRos[i + 1], actualRockRos[i + 2], actualRockRos[i + 3]);
        }

        newestNum = -1;
        //for townhall
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (buildingNames[i] == "townhall")
            {
                GameObject TownHallBuilding = Instantiate(townhall, realPos[i] + Vector3.up * 5, realRot[i]);
                TownHallBuilding.transform.SetParent(buildings.transform);
                TownHallBuilding.SetActive(true);
                StartCoroutine(updateVertices(TownHallBuilding));
                Destroy(TownHallBuilding.GetComponent<FollowingBuilderCam>());
                TownHallBuilding.name = "townhall";
                newestNum += 1;

                Destroy(TownHallBuilding.transform.GetComponent<Rigidbody>());
                for (int i2 = 0; i2 < TownHallBuilding.transform.childCount; i2++)
                {
                    TownHallBuilding.transform.GetChild(i2).gameObject.GetComponent<MeshCollider>().convex = true;
                    TownHallBuilding.transform.GetChild(i2).GetComponent<MeshCollider>().enabled = true;
                }
                TownHallBuilding.transform.GetComponent<BoxCollider>().enabled = false;
            }
        }

        //for farm
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (buildingNames[i] == "farm")
            {
                GameObject farmBuilding = Instantiate(farm, realPos[i], realRot[i]);
                farmBuilding.transform.SetParent(buildings.transform);
                farmBuilding.GetComponent<Farm>().Farmers = realNumberOfFarmers[i4];
                farmBuilding.SetActive(true);
                StartCoroutine(updateVertices(farmBuilding));
                farmBuilding.GetComponent<Farm>().wheat = realNumberOfWheat[i4];
                Destroy(farmBuilding.GetComponent<FollowingBuilderCam>());
                farmBuilding.name = "farm";
                realFarmers = farmBuilding.transform.Find("Farmers").gameObject;

                Destroy(farmBuilding.transform.GetComponent<Rigidbody>());
                for (int i2 = 0; i2 < farmBuilding.transform.childCount; i2++)
                {
                    farmBuilding.transform.GetChild(i2).gameObject.GetComponent<MeshCollider>().convex = true;
                    farmBuilding.transform.GetChild(i2).GetComponent<MeshCollider>().enabled = true;
                }
                farmBuilding.transform.GetComponent<BoxCollider>().enabled = false;

                for (int i6 = 0; i6 < farmBuilding.GetComponent<Farm>().Farmers; ++i6)
                {
                    GameObject farmer = Instantiate(farmers, new Vector3(farmBuilding.transform.position.x, farmBuilding.transform.position.y + 3, farmBuilding.transform.position.z + 3), Quaternion.identity);
                    farmer.SetActive(true);
                    farmer.transform.SetParent(realFarmers.transform);
                    farmer.name = "farmer";
                    farmer.transform.rotation *= Quaternion.Euler(-90, 90, 0);
                }

                i4++;
            }
        }

        //for smallHouse
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (buildingNames[i] == "smallHouse")
            {
                GameObject smallHouseBuilding = Instantiate(smallHouse, realPos[i], realRot[i]);
                smallHouseBuilding.transform.SetParent(buildings.transform);
                smallHouseBuilding.GetComponent<SmallHouse>().Residents = realNumberOfResidents[i3];
                smallHouseBuilding.GetComponent<SmallHouse>().maxResidents = realNumberOfMaxResidents[i3];
                smallHouseBuilding.GetComponent<SmallHouse>().enabled = true;
                smallHouseBuilding.SetActive(true);
                StartCoroutine(updateVertices(smallHouseBuilding));
                Destroy(smallHouseBuilding.GetComponent<FollowingBuilderCam>());
                smallHouseBuilding.name = "smallHouse";
                realResidents = smallHouseBuilding.transform.Find("Actual Residents").gameObject;
                Door = smallHouseBuilding.transform.Find("Door").gameObject;

                Destroy(smallHouseBuilding.transform.GetComponent<Rigidbody>());
                for (int i2 = 0; i2 < smallHouseBuilding.transform.childCount; i2++)
                {
                    smallHouseBuilding.transform.GetChild(i2).gameObject.GetComponent<MeshCollider>().convex = true;
                    smallHouseBuilding.transform.GetChild(i2).GetComponent<MeshCollider>().enabled = true;
                }
                smallHouseBuilding.transform.GetComponent<BoxCollider>().enabled = false;

                //spawns residents
                for (int i6 = 0; i6 < smallHouseBuilding.GetComponent<SmallHouse>().Residents; ++i6)
                {
                    GameObject resident = Instantiate(residents, new Vector3(smallHouseBuilding.transform.position.x + i6 + 5, smallHouseBuilding.transform.position.y + 3, smallHouseBuilding.transform.position.z + i6 + 5), Quaternion.identity);
                    resident.SetActive(true);
                    resident.GetComponent<Resident>().movePositionTransform = Door.transform;
                    resident.GetComponent<Resident>().realResidents = realResidents;
                    resident.GetComponent<Resident>().spawnedIn = true;
                    resident.transform.SetParent(realResidents.transform);
                    resident.name = "resident";
                    ResidentLifeCycle(resident);
                }

                i3++;
            }
        }

        //for lumbermill
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (buildingNames[i] == "lumberMill")
            {
                GameObject lumberMillBuilding = Instantiate(lumberMill, realPos[i], realRot[i]);
                lumberMillBuilding.transform.SetParent(buildings.transform);
                lumberMillBuilding.GetComponent<lumberMill>().LumberJacks = realNumberOfLumberJacks[i5];
                lumberMillBuilding.SetActive(true);
                StartCoroutine(updateVertices(lumberMillBuilding));
                lumberMillBuilding.GetComponent<lumberMill>().wood = realNumberOfWood[i5];
                Destroy(lumberMillBuilding.GetComponent<FollowingBuilderCam>());
                lumberMillBuilding.name = "lumberMill";
                realLumberJacks = lumberMillBuilding.transform.Find("LumberJacks").gameObject;

                Destroy(lumberMillBuilding.transform.GetComponent<Rigidbody>());
                for (int i2 = 0; i2 < lumberMillBuilding.transform.childCount; i2++)
                {
                    lumberMillBuilding.transform.GetChild(i2).gameObject.GetComponent<MeshCollider>().convex = true;
                    lumberMillBuilding.transform.GetChild(i2).GetComponent<MeshCollider>().enabled = true;
                }
                lumberMillBuilding.transform.GetComponent<BoxCollider>().enabled = false;

                for (int i6 = 0; i6 < lumberMillBuilding.GetComponent<lumberMill>().LumberJacks; ++i6)
                {
                    GameObject lumberJack = Instantiate(lumberJacks, new Vector3(lumberMillBuilding.transform.position.x, lumberMillBuilding.transform.position.y + 3, lumberMillBuilding.transform.position.z + 3), Quaternion.identity);
                    lumberJack.SetActive(true);
                    lumberJack.transform.SetParent(realLumberJacks.transform);
                    lumberJack.name = "lumberJack";
                    lumberJack.transform.rotation *= Quaternion.Euler(-90, 90, 0);
                }

                i5++;
            }
        }

        //for mine
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (buildingNames[i] == "mine")
            {
                GameObject MineBuilding = Instantiate(mine, realPos[i], realRot[i]);
                MineBuilding.transform.SetParent(buildings.transform);
                MineBuilding.GetComponent<Mine>().Miners = realNumberOfMiners[i7];
                MineBuilding.SetActive(true);
                StartCoroutine(updateVertices(MineBuilding));
                MineBuilding.GetComponent<Mine>().stone = realNumberOfStone[i7];
                Destroy(MineBuilding.GetComponent<FollowingBuilderCam>());
                MineBuilding.name = "mine";
                realMiners = MineBuilding.transform.Find("Miners").gameObject;

                Destroy(MineBuilding.transform.GetComponent<Rigidbody>());
                for (int i2 = 0; i2 < MineBuilding.transform.childCount; i2++)
                {
                    MineBuilding.transform.GetChild(i2).gameObject.GetComponent<MeshCollider>().convex = true;
                    MineBuilding.transform.GetChild(i2).GetComponent<MeshCollider>().enabled = true;
                }
                MineBuilding.transform.GetComponent<BoxCollider>().enabled = false;

                for (int i6 = 0; i6 < MineBuilding.GetComponent<Mine>().Miners; ++i6)
                {
                    GameObject miners = Instantiate(Miners, new Vector3(MineBuilding.transform.position.x, MineBuilding.transform.position.y + 3, MineBuilding.transform.position.z + 3), Quaternion.identity);
                    miners.SetActive(true);
                    miners.transform.SetParent(realMiners.transform);
                    miners.name = "miner";
                    miners.transform.rotation *= Quaternion.Euler(-90, 90, 0);
                }

                i7++;
            }
        }

        //for tree
        for (int i = 0; i < tree; ++i)
        {
            int num = 0;

            for(int i2 = 0; i2 < forestGenerator.GetComponent<ForestGenerator>().tree.Length; i2++)
            {
                if(treeNames[i] == forestGenerator.GetComponent<ForestGenerator>().tree[i2].name)
                {
                    num = i2;
                }
            }

            GameObject tree = Instantiate(forestGenerator.GetComponent<ForestGenerator>().tree[num], realTreePos[i], realTreeRos[i]);
            tree.SetActive(true);

            for (int i2 = 0; i2 < tree.transform.childCount; i2++)
            {
                if (tree.transform.GetChild(i2).name != "Empty")
                {
                    Renderer rend = tree.transform.GetChild(i2).GetComponent<Renderer>();
                    Color color = tree.transform.GetChild(i2).GetComponent<Renderer>().material.color;
                    rend.material = new Material(shader);
                    rend.material.SetColor("_Tint", color);

                    if (tree.transform.GetChild(i2).name.Contains("branches") || tree.transform.GetChild(i2).name.Contains("branchs") || tree.transform.GetChild(i2).name.Contains("branch"))
                    {
                        changeShaderToTrunk(rend);
                    }

                    if (tree.transform.GetChild(i2).name.Contains("leaves"))
                    {
                        changeShaderToLeaves(rend);
                    }
                }
            }

            //regular trees
            if (num == 0 || num == 1)
            {
                tree.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            }
            if (num == 2 || num == 3)
            {
                tree.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            //snow trees
            if (num == 5)
            {
                tree.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            }
            if (num == 6)
            {
                tree.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            //tree.transform.Translate(Vector3.down * 1);
            tree.layer = groundLayer;
            tree.transform.eulerAngles = new Vector3(
                 tree.transform.eulerAngles.x + 0,
                 tree.transform.eulerAngles.y,
                 tree.transform.eulerAngles.z
                 );
            tree.transform.SetParent(treeTransform.transform);
            foreach (Transform child in tree.transform)
            {
                child.gameObject.AddComponent<TreeScript>();
                child.gameObject.layer = groundLayer;
            }
            tree.SetActive(true);
            tree.name = treeNames[i];
        }

        //for rock
        for (int i = 0; i < rock; ++i)
        {
            int num = 0;

            for (int i2 = 0; i2 < forestGenerator.GetComponent<ForestGenerator>().rock.Length; i2++)
            {
                if (rockNames[i] == forestGenerator.GetComponent<ForestGenerator>().rock[i2].name)
                {
                    num = i2;
                }
            }

            GameObject rock = Instantiate(forestGenerator.GetComponent<ForestGenerator>().rock[num], realRockPos[i], realRockRos[i]);
            rock.SetActive(true);

            rock.transform.localScale = new Vector3(2, 2, 2);
            //rock.transform.Translate(Vector3.up * 3f);
            rock.layer = groundLayer;
            rock.transform.eulerAngles = new Vector3(
                 rock.transform.eulerAngles.x + 0,
                 rock.transform.eulerAngles.y,
                 rock.transform.eulerAngles.z
                 );
            rock.transform.SetParent(rockTransform.transform);
            foreach (Transform child in rock.transform)
            {
                child.gameObject.AddComponent<StoneScript>();
                child.gameObject.layer = groundLayer;
            }
            rock.SetActive(true);
            rock.name = rockNames[i];
        }

        //Add resident job
        int numberOfJobsAndResidents = 0;

        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "smallHouse")
            {
                foreach (Transform transform in transform.GetChild(i))
                {
                    if (transform.name == "Actual Residents")
                    {
                        foreach (Transform transform1 in transform)
                        {
                            //transform1.GetComponent<Resident>().jobHome = GetClosestJob(children, residentJobs[numberOfJobsAndResidents]).gameObject;
                            Transform trans = GetClosestJob(children, residentJobs[numberOfJobsAndResidents]);
                            if(trans != null)
                            {
                                transform1.GetComponent<Resident>().hasJob = true;
                                transform1.GetComponent<Resident>().jobHome = trans.gameObject;
                                transform1.GetComponent<Resident>().JobDoor = trans.gameObject.transform.FindChild("Door").gameObject;

                                if(trans.name == "mine")
                                {
                                    transform1.transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.gray;
                                }

                                if (trans.name == "farm")
                                {
                                    transform1.transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                                }

                                if (trans.name == "lumberMill")
                                {
                                    transform1.transform.FindChild("Cube").gameObject.GetComponent<Renderer>().material.color = Color.red;
                                }
                            }
                            numberOfJobsAndResidents++;
                        }
                    }
                }
            }
        }
        newNum = 0;
        
        //for one townhall;
        foreach (Transform child in buildings.transform)
        {
            if (child.name == "townhall")
            {
                onlyOneTownHall.SetActive(false);
                farms.SetActive(true);
                smallHouses.SetActive(true);
                lumbermills.SetActive(true);
                mines.SetActive(true);
            }
        }

        navBaker.GetComponent<NavigationBaker>().shouldUpdate = true;
        //Destroy(GameObject.Find("GrassTerrain").GetComponent<MeshCollider>());
        //StartCoroutine(ExampleCoroutine2());
    }

    //redo terrain collider
    public void redoCollider()
    {
        //terrain.AddComponent<MeshCollider>();
    }

    private void terrainChange(GameObject objectName, int x, int y, int z, float offset, bool canGo, bool canGo2, GameObject terrain)
    {
        //objectName.AddComponent<GroundFormation>();
        //objectName.AddComponent<GroundFormation>().changeVertices(false, );
        //objectName.AddComponent<GroundFormation>().changeVertices(false);
        //objectName.GetComponent<GroundFormation>().terrainHit = terrain;
        //objectName.GetComponent<GroundFormation>().canGo = canGo;
        //objectName.GetComponent<GroundFormation>().canGo2 = true;
        //objectName.GetComponent<GroundFormation>().objectScaleX = x;
        //objectName.GetComponent<GroundFormation>().objectScaleY = y;
        //objectName.GetComponent<GroundFormation>().objectScaleZ = z;
        //objectName.GetComponent<GroundFormation>().terrainOriginalVertices = originalVertices;
        //objectName.GetComponent<GroundFormation>().offset = offset;
        //objectName.GetComponent<GroundFormation>().chooseStart = true;

        //for (int i = 0; i < objectName.transform.childCount; i++)
        //{
        //objectName.transform.GetChild(i).gameObject.AddComponent<ChangeColorChild>();
        //objectName.transform.GetChild(i).gameObject.GetComponent<ChangeColorChild>().saviorCube = saviorCube;
        //objectName.transform.GetChild(i).gameObject.GetComponent<ChangeColorChild>().enabled = false;
        //}
        //objectName.AddComponent<ChangeColor>();

        //redoCollider();
    }

    IEnumerator updateVertices(GameObject gameobject)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        //gameobject.AddComponent<GroundFormation>();
        //gameobject.GetComponent<GroundFormation>().changeVertices(false);
    }


    IEnumerator ExampleCoroutine2()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Destroy(GameObject.Find("GrassTerrain").GetComponent<MeshCollider>());
        navBaker.GetComponent<NavigationBaker>().shouldUpdate = true;
    }

    public void changeShaderToTrunk(Renderer rend)
    {
        rend.material.SetFloat("_wind_size", 15f);
        rend.material.SetFloat("_tree_sway_stutter_influence", 0.2f);
        rend.material.SetFloat("_tree_sway_stutter", 1.5f);
        rend.material.SetFloat("_tree_sway_speed", 1f);
        rend.material.SetFloat("_tree_sway_disp", 0.3f);
        rend.material.SetFloat("_branches_disp", 0.3f);
        rend.material.SetFloat("_leaves_wiggle_disp", 0.07f);
        rend.material.SetFloat("_leaves_wiggle_speed", 0.01f);
        rend.material.SetFloat("_r_influence", 0.006f);
        rend.material.SetFloat("_b_influence", 1);
    }

    public void changeShaderToLeaves(Renderer rend)
    {
        rend.material.SetFloat("_wind_size", 11.2f);
        rend.material.SetFloat("_tree_sway_stutter_influence", 0.717f);
        rend.material.SetFloat("_tree_sway_stutter", 0.49f);
        rend.material.SetFloat("_tree_sway_speed", 1f);
        rend.material.SetFloat("_tree_sway_disp", 1f);
        rend.material.SetFloat("_branches_disp", 0.118f);
        rend.material.SetFloat("_leaves_wiggle_disp", 0.07f);
        rend.material.SetFloat("_leaves_wiggle_speed", 0.01f);
        rend.material.SetFloat("_r_influence", 0.03f);
        rend.material.SetFloat("_b_influence", 0f);
    }

    public void ResidentLifeCycle(GameObject resident)
    {
        Resident residentScript = resident.GetComponent<Resident>();

        if (dayNight.GetComponent<LightingManager>().TimeOfDay >= 5 && dayNight.GetComponent<LightingManager>().TimeOfDay <= 6.9)
        {
            residentScript.ResidentEnable(true);
            residentScript.shouldWork = false;
            residentScript.shouldWander = true;
            residentScript.shouldPathFind = false;
        }
        if (dayNight.GetComponent<LightingManager>().TimeOfDay >= 7 && dayNight.GetComponent<LightingManager>().TimeOfDay <= 15.9)
        {
            if (residentScript.hasJob)
            {
                residentScript.shouldWork = true;
                residentScript.shouldWander = false;
                residentScript.shouldPathFind = false;
            }
        }
        if (dayNight.GetComponent<LightingManager>().TimeOfDay >= 16 && dayNight.GetComponent<LightingManager>().TimeOfDay <= 18.9)
        {
            residentScript.ResidentEnable(true);
            residentScript.shouldWork = false;
            residentScript.shouldWander = true;
            residentScript.shouldPathFind = false;
        }
        if (dayNight.GetComponent<LightingManager>().TimeOfDay >= 19)
        {
            residentScript.shouldWork = false;
            residentScript.shouldWander = false;
            residentScript.shouldPathFind = true;
        }
    }

    public Transform GetClosestJob(Transform[] buildings, Vector3 savedPos)
    {
        if(savedPos == new Vector3(0, 0, 0))
        {
            return null;
        }

        Transform tMin = null;
        float minDist = Mathf.Infinity;

        foreach (Transform t in buildings)
        {
            float dist = Vector3.Distance(t.localPosition, savedPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        return tMin;
    }
}