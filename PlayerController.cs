using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed = 6.0F;
    public float sprintSpeed = 10.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
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

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded && inventory.activeSelf == false && merchant.activeSelf == false && builder.activeSelf == false && menu.activeSelf == false && secondCam.activeSelf == false && pauseMenu.activeSelf == false && getTownName.activeSelf == false && moving.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && mineMenu.activeSelf == false)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= sprintSpeed;
            }
            else
            {
                moveDirection *= speed;
            }
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        if(inventory.activeSelf == false && merchant.activeSelf == false && builder.activeSelf == false && menu.activeSelf == false && secondCam.activeSelf == false && pauseMenu.activeSelf == false && getTownName.activeSelf == false && moving.activeSelf == false && residentMenu.activeSelf == false && jobCamera.activeSelf == false && farmMenu.activeSelf == false && lumberMillMenu.activeSelf == false && mineMenu.activeSelf == false)
            controller.Move(moveDirection * Time.deltaTime);
    }
}