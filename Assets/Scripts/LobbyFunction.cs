﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LobbyFunction : MonoBehaviour
{
    [SerializeField]
    private RoomListDisplay _roomListDisplay;
    private RoomListDisplay RoomListDisplay
    {
        get { return _roomListDisplay; }
    }

    public void OnClickRoom(string roomName)
    {
        if (PhotonNetwork.JoinRoom(roomName))
        {
            Debug.Log("Player Joined in the Room");
        }
        else
        {
            Debug.Log("Failed to join in the room, please fix the error!");
        }
    }
}
