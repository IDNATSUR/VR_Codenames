using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class EndGame : MonoBehaviourPun
{
    Canvas over;
    private float distance = 2f;


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
            over.transform.position = Camera.main.transform.position + new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z) * distance;
            over.transform.eulerAngles = new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f);
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