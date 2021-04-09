using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController:MonoBehaviour
{
    public static int blueScore = 0;
    public static int redScore = 0;
    public static bool redTurn;

    public int blueWin = 8;
    public int redWin = 8;

    //turn is used to randomly decide which team goes first
    public static int turn;
    
    public Canvas scoreBoard;
    public Text redText;
    public Text blueText;
    public Text gameStatus;
    public Button playAgain;
    public Button mainMenu;
    public float distance = 50.0f;

    void Start()
    {
        //randomly set up who goes first
        System.Random random = new System.Random(); 
        turn= random.Next(0,2);
        if (turn == 1)
        {
            redTurn = false;
            blueWin++;
        }
        else
        {
            redTurn = true;
            redWin++;
        }

        scoreBoard = GetComponent<Canvas>();
        scoreBoard.enabled = false;
        redText = transform.Find("RedText").GetComponent<Text>();
        blueText = transform.Find("BlueText").GetComponent<Text>();
        gameStatus = transform.Find("GameStatusText").GetComponent<Text>();
        playAgain = transform.Find("PlayAgainButton").GetComponent<Button>();
        mainMenu = transform.Find("MainMenuButton").GetComponent<Button>();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        //update menu text
        redText.text = "Red Team: \n" + "Score:" + redScore;
        blueText.text = "Blue Team: \n" + "Score:" + blueScore;
        if (redTurn)
        {
            gameStatus.text = "Red Team's Turn";
        }
        else
        {
            gameStatus.text = "Blue Team's Turn";
        }

        //game end conditions
        if (redScore == redWin)
        {
            gameStatus.text += "\nRed Team Wins!";
            GameEnd();
        }
        else if (blueScore == blueWin)
        {
            gameStatus.text += "\nBlue Team Wins!";
            GameEnd();
        }

        //if "Fire1" is pressed, show score board
        if (Input.GetButton("Fire1"))
        {
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

    public void FoundAssassin()
    {
        if (redTurn)
        {
            gameStatus.text += "\nRed Team found the Assassin Object\nBlue Team Wins!";
        }
        else
        {
            gameStatus.text += "\nBlue Team found the Assassin Object\nRed Team Wins!";
        }
        GameEnd();
    }

    public void GameEnd()
    {
        //force the scoreboard to pop up
        //set up the menu position
        scoreBoard.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        scoreBoard.transform.rotation = Camera.main.transform.rotation;

        //make menu visible
        scoreBoard.enabled = true;

        //enable main menu and play again buttons
        playAgain.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
}
