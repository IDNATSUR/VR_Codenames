using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController:MonoBehaviour
{
    public static int blueScore = 0;
    public static int redScore = 0;
    public Canvas scoreBoard;
    public Text redText;
    public Text blueText;


    void Start()
    {
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
            redText.text = "Red Team: \n"+"Score: " + blueScore;
            blueText.text = "Blue Team: \n"+"Score: " + redScore;
            scoreBoard.enabled = true;
        }
        //if "Fire2" is pressed, hide score board
        if (Input.GetButton("Fire2"))
        {
            scoreBoard.enabled = false;
        }
    }

}
