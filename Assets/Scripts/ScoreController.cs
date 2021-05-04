using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreController:MonoBehaviourPun, IPunObservable
{
    public static int blueScore = 0;
    public static int redScore = 0;
    public static bool redTurn;

    public static int blueWin = 8;
    public static int redWin = 8;


    //turn is used to randomly decide which team goes first
    public static int turn;

    public static bool assassinTouch = false;

    public static bool gameover = false;
    PhotonView photonView;

    

    void Start()
    {
        photonView = PhotonView.Get(this);
        // endMenu = GetComponent<Canvas>();
        // endMenu.gameObject.SetActive(false);
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
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(blueScore);
            stream.SendNext(redScore);
            stream.SendNext(redTurn);
            stream.SendNext(blueWin);
            stream.SendNext(redWin);
            stream.SendNext(turn);
            stream.SendNext(assassinTouch);
        }
        else
        {
            //Network player, receive data
            blueScore = (int)stream.ReceiveNext();
            redScore = (int)stream.ReceiveNext();
            redTurn = (bool)stream.ReceiveNext();
            blueWin = (int)stream.ReceiveNext();
            redWin = (int)stream.ReceiveNext();
            turn = (int)stream.ReceiveNext();
            assassinTouch = (bool)stream.ReceiveNext();
        }
    }

    public void Click(string objColor)
    {
        photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
        // color = !color;
        // renderer.material.SetColor("_Color", Color.red);
        //determine what color object it is by looking at the parent
        switch (objColor)
        {
            case "blue":
                blueScore++;
                redTurn = false;

                break;
            case "red":
                redScore++;
                redTurn = true;
                break;
            case "double":
                if (turn == 0)
                {
                    redScore++;
                    redTurn = true;
                }
                else
                {
                    blueScore++;
                    redTurn = false;
                }
                break;
            case "neutral":
                redTurn = !redTurn;
                break;
            case "assassin":
                assassinTouch = true;
                break;
        }
    }

    void Update()
    {

    }
}
