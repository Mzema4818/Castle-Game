using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour
{
    public int Farmers;
    public int maxFarmers;
    public GameObject ChildFarmers;
    public int wheat;
    private int numberOfFarmers;

    public GameObject wheatMenu;
    public GameObject FarmerMenu;
    public GameObject collectorMenu;

    public TextMeshProUGUI wheatText;
    private string wheatValue;
    private int wheatCalc;
    private int newWheatValue;

    public TextMeshProUGUI farmerText;
    private string farmerValue;
    private int farmerCalc;
    private int newfarmerValue;

    public TextMeshProUGUI collectorText;
    private string collectorValue;
    private int collectorCalc;
    private int newCollectorValue;

    public bool canSetWheat;

    public int workers;
    public int workersActive;

    public Button backButton;
    public Button collectWheatButton;

    // Start is called before the first frame update
    void Start()
    {
        canSetWheat = false;
        maxFarmers = 2;
        ChildFarmers = transform.Find("Farmers").gameObject;
        numberOfFarmers = ChildFarmers.transform.childCount;
        InvokeRepeating("getWheatValue", 0, 2.0f);

        //farm
        //farmerText = FarmerMenu.GetComponent<TMP_Text>();
        //farmerValue = farmerText.text;
        //farmerCalc = int.Parse(farmerValue);

        //newfarmerValue = ChildFarmers.transform.childCount;
        //farmerText.text = newfarmerValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(numberOfFarmers != ChildFarmers.transform.childCount)
        {
            farmerText = FarmerMenu.GetComponent<TMP_Text>();
            farmerValue = farmerText.text;
            farmerCalc = int.Parse(farmerValue);

            newfarmerValue = ChildFarmers.transform.childCount;
            farmerText.text = newfarmerValue.ToString();
            numberOfFarmers = ChildFarmers.transform.childCount;
        }*/

        collectWheatButton.GetComponent<Button>().onClick.AddListener(collectWheat);
        backButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);

        if (canSetWheat)
        {
            farmerText.text = workers.ToString();
            wheatText.text = wheat.ToString();
        }
    }

    void getWheatValue()
    {
        if (workersActive != 0)
        {
            wheat += 1 * workersActive;
            if (canSetWheat)
            {
                wheatText.text = wheat.ToString();
            }
        }
    }

    public void collectWheat()
    {
        if (canSetWheat)
        {
            wheatValue = wheatText.text;
            wheatCalc = int.Parse(wheatValue);

            //collector
            collectorValue = collectorText.text;
            collectorCalc = int.Parse(collectorValue);

            newCollectorValue = wheatCalc + collectorCalc;
            collectorText.text = newCollectorValue.ToString();

            //stone;
            //stoneText = stoneMenu.GetComponent<TMP_Text>();
            wheat = 0;
            wheatText.text = wheat.ToString();
        }
    }

    public void TaskOnClick()
    {
        canSetWheat = false;
    }
}
