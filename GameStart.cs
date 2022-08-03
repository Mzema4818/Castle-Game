using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject mainMenuCamera;
    public GameObject mainCamera;
    public GameObject hotbar;
    public GameObject crosshair;

    public void changeCamera()
    {
        mainMenuCamera.SetActive(false);
        mainCamera.SetActive(true);
        hotbar.SetActive(true);
        crosshair.SetActive(true);
    }

    public void changeCamera2()
    {
        mainMenuCamera.SetActive(true);
        mainCamera.SetActive(false);
        hotbar.SetActive(false);
        crosshair.SetActive(false);
    }
}
