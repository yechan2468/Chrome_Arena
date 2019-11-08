using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class lobby_Manager : MonoBehaviourPunCallbacks
{
    private readonly string game_Version = "0.0.1";

    public Text nickname_Text;
    public Button search_Queue_Button;
    public Button host_Game_Button;
    

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = game_Version;
        if (PhotonNetwork.IsConnected == false)
        {
        PhotonNetwork.ConnectUsingSettings();
        }
        Debug.Log("1");
        search_Queue_Button.interactable = false;
        host_Game_Button.interactable = false;
        nickname_Text.text = "Connecting to Master Server...";


    }

    // 마스터 서버에 접속되었을 때 자동으로 실행
    public override void OnConnectedToMaster()
    {
        search_Queue_Button.interactable = true;
        host_Game_Button.interactable = true;
        
        string tmp = authorization_Manager.Nickname;
        nickname_Text.text = $"Welcome,\n{tmp}!";
    }

    // 마스터 서버에 접속 실패되거나 혹은 접속 중 접속 끊길 때 자동으로 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        search_Queue_Button.interactable = false;
        host_Game_Button.interactable = false;
        nickname_Text.text = $"Connection Lost:\n{cause.ToString()}\nTrying to reconnect...";

        PhotonNetwork.ConnectUsingSettings();
    }

    // 방 찾기 함수
    public void search_Queue()
    {
        search_Queue_Button.interactable = false;
        host_Game_Button.interactable = false;
        nickname_Text.text = "Searching...";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
        nickname_Text.text = "Connection Lost:\nTrying to reconnect...";
        PhotonNetwork.ConnectUsingSettings();
        }
    }

    // 빈 방이 없어 joinRandomRoom() method를 실행할 수 없을때 실행됨
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        nickname_Text.text = "There is no empty room.";
        search_Queue_Button.interactable = true;
        host_Game_Button.interactable = true;
    }

    // 방 만들기 함수
    public void create_Room()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = 8});
    }

    // 방에 참가했을 때 자동으로 실행되는 함수 (방참가, 방만들기 두 경우 모두)
    public override void OnJoinedRoom()
    {
        nickname_Text.text = "Found a room!";
        PhotonNetwork.LoadLevel("Waiting_Room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
