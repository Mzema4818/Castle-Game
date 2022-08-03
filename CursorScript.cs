using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour
{
    public GameObject merchant;
    public GameObject builder;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject secondCam;
    public GameObject getTownName;
    public GameObject moving;
    public GameObject residentMenu;
    public GameObject jobCamera;
    public GameObject farmMenu;
    public GameObject lumberMillMenu;
    public GameObject mineMenu;

    // Use this for initialization
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (builder.activeSelf == true || merchant.activeSelf == true || mainMenu.activeSelf == true || secondCam.activeSelf == true || pauseMenu.activeSelf == true || getTownName.activeSelf == true || moving.activeSelf == true || residentMenu.activeSelf == true || jobCamera.activeSelf == true || farmMenu.activeSelf == true || lumberMillMenu.activeSelf == true || mineMenu.activeSelf == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        if(builder.activeSelf == false && merchant.activeSelf == false && mainMenu.activeSelf == false && secondCam.activeSelf == false && pauseMenu.activeSelf == false && getTownName.activeSelf == false && moving.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && mineMenu.activeSelf == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}