using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject sword;
    public GameObject pick;
    public GameObject axe;
    public Animator animator;

    private void Awake()
    {
        foreach(var button in GetComponentsInChildren<HotbarButton>())
        {
            button.OnButtonClicked += ButtonOnOButtonClicked;
        }
    }
    
    private void ButtonOnOButtonClicked(int buttonNumber)
    {
        //Debug.Log($"Button{buttonNumber} clicked!");

        //sword
        if(buttonNumber == 1 && !sword.activeSelf && !animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
        {
            sword.SetActive(true);
            axe.SetActive(false);
            pick.SetActive(false);
        }
        else if(buttonNumber == 1 && sword.activeSelf && !animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
        {
            sword.SetActive(false);
            axe.SetActive(false);
            pick.SetActive(false);
        }

        //pick
        if (buttonNumber == 2 && !pick.activeSelf && !animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
        {
            sword.SetActive(false);
            axe.SetActive(false);
            pick.SetActive(true);
        }
        else if (buttonNumber == 2 && pick.activeSelf && !animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
        {
            sword.SetActive(false);
            axe.SetActive(false);
            pick.SetActive(false);
        }

        //axe
        if (buttonNumber == 3 && !axe.activeSelf && !animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
        {
            sword.SetActive(false);
            axe.SetActive(true);
            pick.SetActive(false);
        }
        else if (buttonNumber == 3 && axe.activeSelf && !animator.GetCurrentAnimatorStateInfo(1).IsName("swing"))
        {
            sword.SetActive(false);
            axe.SetActive(false);
            pick.SetActive(false);
        }
    }
}