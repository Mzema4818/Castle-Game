using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject inventory;
    public GameObject woodObject;
    public GameObject moneyObject;
    public GameObject stoneObject;

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

    // Update is called once per frame
    void Update()
    {
        woodText = woodObject.GetComponent<TMP_Text>();
        woodValue = woodText.text;
        woodCalc = int.Parse(woodValue);

        moneyText = moneyObject.GetComponent<TMP_Text>();
        moneyValue = moneyText.text;
        moneyCalc = int.Parse(moneyValue);

        stoneText = stoneObject.GetComponent<TMP_Text>();
        stoneValue = stoneText.text;
        stoneCalc = int.Parse(stoneValue);
    }

    private void calcMoney()
    {
        money = moneyCalc + 1;
    }

    private void CalcWood()
    {
        wood = woodCalc - 1;
    }

    private void CalcStone()
    {
        stone = stoneCalc - 1;
    }

    public void SellWood()
    {
        if (woodCalc > 0)
        {
            CalcWood();
            calcMoney();
            woodText.text = wood.ToString();
            moneyText.text = money.ToString();
        }
    }

    public void SellStone()
    {

        if(stoneCalc > 0)
        {
            CalcStone();
            calcMoney();
            stoneText.text = stone.ToString();
            moneyText.text = money.ToString();
        }
    }
}
