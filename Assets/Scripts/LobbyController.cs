using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    public Button btnConnectMaster;
    public Button btnConnectRoom;

    
    
    public bool existRoom = false;
    // helps to identify which state we are
    protected bool triesToConnectToMaster;
    protected bool triesToConnectToRoom;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        triesToConnectToMaster = false;
        triesToConnectToRoom   = false;
        btnConnectMaster = transform.Find("btnConnectToMaster").GetComponent<Button>();
        btnConnectRoom = transform.Find("btnConnectRoom").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (btnConnectMaster != null)
            btnConnectMaster.gameObject.SetActive(!PhotonNetwork.IsConnected && !triesToConnectToMaster);
        if (btnConnectRoom != null)
            btnConnectRoom.gameObject.SetActive(PhotonNetwork.IsConnected && !triesToConnectToMaster && !triesToConnectToRoom);
    }

    public void OnClickConnectToMaster()
    {
        triesToConnectToMaster = true;

        //Photon networking settings
        PhotonNetwork.OfflineMode = false;          
        // System.Random random = new System.Random(); 
        // int name = random.Next(0,100);
        // PhotonNetwork.NickName = ""+name;
        PhotonNetwork.AutomaticallySyncScene = true; 
        PhotonNetwork.GameVersion = "v1";            

        if(!PhotonNetwork.OfflineMode)
            PhotonNetwork.ConnectUsingSettings();    

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        triesToConnectToMaster = false;
        Debug.Log("Connected to Master!");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        triesToConnectToMaster = false;
        triesToConnectToRoom   = false;
        Debug.Log(cause);
    }

    public void OnClickConnectToRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        triesToConnectToRoom = true;
        //PhotonNetwork.CreateRoom("Peter's Game 1"); //Create a specific Room - Error: OnCreateRoomFailed
        //PhotonNetwork.JoinRoom("Peter's Game 1");   //Join a specific Room   - Error: OnJoinRoomFailed  
        PhotonNetwork.JoinRandomRoom();               //Join a random Room     - Error: OnJoinRandomRoomFailed  
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        //no room available
        //create a room (null as a name means "does not matter")
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log(message);
        base.OnCreateRoomFailed(returnCode, message);
        triesToConnectToRoom = false;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        triesToConnectToRoom = false;       
        Debug.Log("Master: " + PhotonNetwork.IsMasterClient + " | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount + " | RoomName: " + PhotonNetwork.CurrentRoom.Name + " Region: " + PhotonNetwork.CloudRegion);
        //if(PhotonNetwork.IsMasterClient && SceneManager.GetActiveScene().name != "Network")
        //    PhotonNetwork.LoadLevel("Network");
        if(PhotonNetwork.IsMasterClient && SceneManager.GetActiveScene().name != "MainScene")
            PhotonNetwork.LoadLevel("SpaceScene");
    }
}
