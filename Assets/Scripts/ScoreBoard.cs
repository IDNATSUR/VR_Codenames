using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Canvas scoreBoard;
    public Text redText;
    public Text blueText;
    public Text gameStatus;
    public float distance = 50.0f;


    void Start()
    {
        scoreBoard = GetComponent<Canvas>();
        redText = transform.Find("RedText").GetComponent<Text>();
        blueText = transform.Find("BlueText").GetComponent<Text>();
        gameStatus = transform.Find("GameStatusText").GetComponent<Text>();


        //show the menu
        scoreBoard.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //update menu text
        redText.text = "Red Team: \n" + "Score: " + ScoreController.redScore;
        blueText.text = "Blue Team: \n" + "Score: " + ScoreController.blueScore;
        if (ScoreController.redTurn)
        {
            gameStatus.text = "Red Team's Turn";
            gameStatus.color = Color.red;
        }

        else
        {
            gameStatus.text = "Blue Team's Turn";
            gameStatus.color = Color.blue;
        }

        //game end conditions
        if (ScoreController.redScore == ScoreController.redWin)
        {
            gameStatus.text = "\nRed Team Wins!";
            gameStatus.color = Color.red;
            EndGame.gameover = true;
            
        }
        else if (ScoreController.blueScore == ScoreController.blueWin)
        {
            gameStatus.text = "\nBlue Team Wins!";
            gameStatus.color = Color.blue;
            EndGame.gameover = true;
            
        }
        if (ScoreController.assassinTouch)
            FoundAssassin();

        scoreBoard.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        scoreBoard.transform.rotation = Camera.main.transform.rotation;
    }

    public void FoundAssassin()
    {
        if (ScoreController.redTurn)
        {
            gameStatus.text = "\nRed Team found the assassin Object. Blue Team wins!";
            gameStatus.color = Color.gray;
        }
        else
        {
            gameStatus.text = "\nBlue Team found the assassin Object. Red Team wins!";
            gameStatus.color = Color.gray;
        }
        EndGame.gameover = true;
    }
}
