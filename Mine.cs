using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    public int Miners;
    public int maxMiners;
    public GameObject ChildMiners;
    public int stone;
    private int numberOfMiners;

    public GameObject stoneMenu;
    public GameObject MinersMenu;
    public GameObject collectorMenu;

    public TextMeshProUGUI stoneText;
    private string stoneValue;
    private int stoneCalc;
    private int newstoneValue;

    public TextMeshProUGUI MinerText;
    private string MinerValue;
    private int MinerCalc;
    private int newMinerValue;

    public TextMeshProUGUI collectorText;
    private string collectorValue;
    private int collectorCalc;
    private int newCollectorValue;

    public Button backButton;
    public Button collectStoneButton;

    public bool canSetStone;

    public int workers;
    public int workersActive;

    public int test;

    //Start is called before the first frame update
    void Start()
    {
        canSetStone = false;
        maxMiners = 2;
        ChildMiners = transform.Find("Miners").gameObject;
        numberOfMiners = ChildMiners.transform.childCount;
        InvokeRepeating("getStoneValue", 0, 2.0f);

        //Mine
        //MinerText = MinersMenu.GetComponent<TMP_Text>();
        //MinerValue = MinerText.text;
        //MinerCalc = int.Parse(MinerValue);

        //newMinerValue = workers;
        //MinerText.text = workers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        collectStoneButton.GetComponent<Button>().onClick.AddListener(collectStone);
        backButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        if (canSetStone)
        {
            MinerText.text = workers.ToString();
            stoneText.text = stone.ToString();
        }
    }

    void getStoneValue()
    {
        if (workersActive != 0)
        {
            stone += 1 * workersActive;
            if (canSetStone)
            {
                stoneText.text = stone.ToString();
            }
        }
    }

    public void collectStone()
    {
        if (canSetStone)
        {
            stoneValue = stoneText.text;
            stoneCalc = int.Parse(stoneValue);

            //collector
            collectorValue = collectorText.text;
            collectorCalc = int.Parse(collectorValue);

            newCollectorValue = stoneCalc + collectorCalc;
            collectorText.text = newCollectorValue.ToString();

            //stone;
            //stoneText = stoneMenu.GetComponent<TMP_Text>();
            stone = 0;
            stoneText.text = stone.ToString();
        }
    }

    public void TaskOnClick()
    {
        canSetStone = false;
    }
}
