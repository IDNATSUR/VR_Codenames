using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController:MonoBehaviour
{
    public static int blueScore = 0;
    public static int redScore = 0;
    
    //turn is used to denote whose turn it is(red team or blue team)
    public static int turn;
    public static bool redTurn;
    public static bool blueTurn;
    public Canvas scoreBoard;
    public Text redText;
    public Text blueText;
    public float distance = 50.0f;


    void Start()
    {
        //randomly set up the turn
        System.Random random = new System.Random(); 
        turn= random.Next(0,2);
        redTurn = turn==0?true:false;
        blueTurn = turn==1?true:false;
        scoreBoard = GetComponent<Canvas>();
        scoreBoard.enabled = false;
        redText = transform.Find("RedText").GetComponent<Text>();
        blueText = transform.Find("BlueText").GetComponent<Text>();
    }

    void Update()
    {
        //if "Fire1" is pressed, show score board
        if (Input.GetButton("Fire1"))
        {
            //update menu text
            //turn 0 is associated with red team, while turn 1 is associated with blue team
            redText.text = "Red Team: \n"+"Score:" + redScore + "\nActive: "+redTurn; 
            blueText.text = "Blue Team: \n"+"Score:" + blueScore + "\nActive: "+blueTurn; 
   
            //set up the menu position
            scoreBoard.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            scoreBoard.transform.rotation = Camera.main.transform.rotation;
            //make menu visible
            scoreBoard.enabled = true;
        }
        //if "Fire2" is pressed, hide score board
        if (Input.GetButton("Fire2"))
        {
            scoreBoard.enabled = false;
        }
    }

}
