using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController:MonoBehaviour
{
    public static int blueScore = 0;
    public static int redScore = 0;
    public static bool redTurn;

    public static int blueWin = 8;
    public static int redWin = 8;

    //turn is used to randomly decide which team goes first
    public static int turn;

    public static bool assassinTouch = false;
    
    public Canvas scoreBoard;
    public Text redText;
    public Text blueText;
    public Text gameStatus;
    // public Button playAgain;
    // public Button mainMenu;
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
        // playAgain = transform.Find("PlayAgainButton").GetComponent<Button>();
        // mainMenu = transform.Find("MainMenuButton").GetComponent<Button>();
        // playAgain.gameObject.SetActive(false);
        // mainMenu.gameObject.SetActive(false);

        //show the menu
        scoreBoard.enabled = true;
    }

    void Update()
    {
        //update menu text
        redText.text = "Red Team: \n" + "Score: " + redScore;
        blueText.text = "Blue Team: \n" + "Score: " + blueScore;
        if (redTurn)
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
        if (redScore == redWin)
        {
            gameStatus.text = "\nRed Team Wins!";
            gameStatus.color = Color.red;
            GameEnd();
        }
        else if (blueScore == blueWin)
        {
            gameStatus.text = "\nBlue Team Wins!";
            gameStatus.color = Color.blue;
            GameEnd();
        }
        if (assassinTouch)
            FoundAssassin();

        scoreBoard.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        scoreBoard.transform.rotation = Camera.main.transform.rotation;

    }

    public void FoundAssassin()
    {
        if (redTurn)
        {
            gameStatus.text = "\nRed Team found the assassin Object. Blue Team wins!";
            gameStatus.color = Color.black;
        }
        else
        {
            gameStatus.text = "\nBlue Team found the assassin Object. Red Team wins!";
            gameStatus.color = Color.black;
        }
        GameEnd();
    }

    public void GameEnd()
    {
        //enable main menu and play again buttons
        // playAgain.gameObject.SetActive(true);
        // mainMenu.gameObject.SetActive(true);
    }
}
