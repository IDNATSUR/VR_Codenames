using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectInteractionController : ObjectController
{
    public ScoreController sc;

    //rotate variable
    private float rotateSpeed = 360.0F;

    //move variable
    private float speed = 2.0F;

    private bool isClick = false;

    void Start()
    {
        sc = GameObject.Find("RoomController").GetComponent<ScoreController>();
    }

    void Update()
    {
        //outline show when pointing the cube
        // outline.enabled = isPointEnter ? true : false;

        //read the game mode
        switch (MenuDisplayController.Mode)
        {
            case MenuDisplayController.MODE.ROTATE_MODE:
                if (isPointEnter && isPointDown)
                    rotate();
                break;
            case MenuDisplayController.MODE.MOVE_MODE:
                if (isPointEnter && isPointDown)
                    move();
                break;
            default:
                break;
        }
    }

    //this method should be public and directly linked to the click event
    public void click(string objColor)
    {
        if (isClick)
            return;
        if (MenuDisplayController.Mode == MenuDisplayController.MODE.COLOR_MODE)
        {
            sc.Click(objColor);
        }
    }

    public void hasClick()
    {
        if (!isClick && MenuDisplayController.Mode == MenuDisplayController.MODE.COLOR_MODE)
            isClick = true;
    }

    void rotate()
    {
        transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }

    void move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
