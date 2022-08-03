using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject inventory;
    public GameObject merchant;
    public GameObject builder;
    public GameObject menu;
    public GameObject secondCam;
    public GameObject pauseMenu;
    public GameObject getTownName;
    public GameObject moving;
    public GameObject residentMenu;
    public GameObject jobCamera;
    public GameObject farmMenu;
    public GameObject lumberMillMenu;
    public GameObject mineMenu;

    Vector2 rotation = new Vector2(0, 0);
    public float speed = 3;

    void Update()
    {
        if (inventory.activeSelf == false && merchant.activeSelf == false && builder.activeSelf == false && menu.activeSelf == false && secondCam.activeSelf == false && pauseMenu.activeSelf == false && getTownName.activeSelf == false && moving.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && mineMenu.activeSelf == false)
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            transform.eulerAngles = (Vector2)rotation * speed;
        }
    }
}
