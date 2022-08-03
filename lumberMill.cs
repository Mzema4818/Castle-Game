using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class lumberMill : MonoBehaviour
{
    public int LumberJacks;
    public int maxLumberJacks;
    public GameObject ChildLumberJacks;
    public int wood;
    private int numberOfLumberJacks;

    public GameObject woodMenu;
    public GameObject LumberJackMenu;
    public GameObject collectorMenu;

    public TextMeshProUGUI woodText;
    private string woodValue;
    private int woodCalc;
    private int newWoodValue;

    public TextMeshProUGUI LumberJackText;
    private string LumberJackValue;
    private int LumberJackCalc;
    private int newLumberJackValue;

    public TextMeshProUGUI collectorText;
    private string collectorValue;
    private int collectorCalc;
    private int newCollectorValue;

    public bool canSetWood;

    public int workers;
    public int workersActive;

    public Button backButton;
    public Button collectWoodButton;

    // Start is called before the first frame update
    void Start()
    {
        canSetWood = false;
        maxLumberJacks = 2;
        ChildLumberJacks = transform.Find("LumberJacks").gameObject;
        numberOfLumberJacks = ChildLumberJacks.transform.childCount;
        InvokeRepeating("getWoodValue", 0, 2.0f);

        //lumberMill
        /*LumberJackText = LumberJackMenu.GetComponent<TMP_Text>();
        LumberJackValue = LumberJackText.text;
        LumberJackCalc = int.Parse(LumberJackValue);

        newLumberJackValue = ChildLumberJacks.transform.childCount;
        LumberJackText.text = newLumberJackValue.ToString();
        */
    }

    // Update is called once per frame
    void Update()
    {
        collectWoodButton.GetComponent<Button>().onClick.AddListener(collectWood);
        backButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        if (canSetWood)
        {
            LumberJackText.text = workers.ToString();
            woodText.text = wood.ToString();
        }
    }

    void getWoodValue()
    {
        if (workersActive != 0)
        {
            wood += 1 * workersActive;
            if (canSetWood)
            {
                LumberJackText.text = wood.ToString();
            }
        }
    }

    public void collectWood()
    {
        if (canSetWood)
        {
            woodValue = woodText.text;
            woodCalc = int.Parse(woodValue);

            //collector
            collectorValue = collectorText.text;
            collectorCalc = int.Parse(collectorValue);

            newCollectorValue = woodCalc + collectorCalc;
            collectorText.text = newCollectorValue.ToString();

            //stone;
            //stoneText = stoneMenu.GetComponent<TMP_Text>();
            wood = 0;
            woodText.text = wood.ToString();
        }
    }

    public void TaskOnClick()
    {
        canSetWood = false;
    }
}
