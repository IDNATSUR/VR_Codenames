using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionController : ObjectController
{
    //rotate variable
    private float rotateSpeed = 360.0F;

    //move variable
    private float speed = 2.0F;

    private bool isClick = false;

    void Start()
    {

    }

    void Update()
    {
        //outline show when pointing the cube
        // outline.enabled = isPointEnter ? true : false;

        //read the game mode
        switch (MenuDisplayController.Mode)
        {
            case MenuDisplayController.MODE.ROTATE_MODE:
                rotate();
                break;
            case MenuDisplayController.MODE.MOVE_MODE:
                move();
                break;
            default:
                break;
        }
    }

    void rotate()
    {
        if (isPointEnter && isPointDown)
            transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }

    void move()
    {
        if (isPointEnter && isPointDown)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //this method should be public and directly linked to the click event
    public void click(string objColor)
    {
        if (isClick)
            return;
        if (MenuDisplayController.Mode == MenuDisplayController.MODE.COLOR_MODE)
        {
            // color = !color;
            // renderer.material.SetColor("_Color", Color.red);
            //determine what color object it is by looking at the parent
            switch (objColor)
            {
                case "blue":
                    ScoreController.blueScore++;
                    ScoreController.redTurn = false;
    
                    break;
                case "red":
                    ScoreController.redScore++;
                    ScoreController.redTurn = true;
                    break;
                case "double":
                    if (ScoreController.turn == 0) {
                        ScoreController.redScore++;
                        ScoreController.redTurn = true;
                    }
                    else {
                        ScoreController.blueScore++;
                        ScoreController.redTurn = false;
                    }
                    break;
                case "neutral":
                    ScoreController.redTurn = !ScoreController.redTurn;
                    break;
                case "assassin":
                    ScoreController.assassinTouch = true;
                    break;
                
            }
        }
    }

    public void hasClick()
    {
        if(!isClick)
            isClick = true;
    }
}
