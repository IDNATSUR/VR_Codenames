using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class EndGame : MonoBehaviourPun
{
    Canvas over;

    // Start is called before the first frame update
    void Start()
    {
        over = GetComponent<Canvas>();
        over.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreController.gameover) {
            //print("game over..");
            over.enabled = true;
        }
    }

    public void Return()
    {
        //reset ScoreController values
        ScoreController.redScore = 0;
        ScoreController.blueScore = 0;
        ScoreController.assassinTouch = false;
        ScoreController.gameover = false;
        ScoreController.redWin = 8;
        ScoreController.blueWin = 8;

        PhotonNetwork.LeaveRoom();
    }
}