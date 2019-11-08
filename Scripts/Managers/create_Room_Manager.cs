using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class create_Room_Manager : MonoBehaviourPunCallbacks
{
    private readonly string GameVersion = "0.0.1";
    private bool is_Connected = false;

    public string room_Name;
    public int room_Max_Players = 2;
    public string map;
    public string gamemode;
    public bool is_Private;
    public string room_Password = "";

    public InputField room_Name_Inputfield;
    public Slider max_Players_Slider;
    public Text max_Players_Text;
    public Dropdown gamemode_Dropdown;
    public Toggle is_Private_Toggle;
    public InputField room_Password_Inputfield;

    public Button cancel_Button;
    public Button create_New_Room_Button;


    void Start()
    {
        create_New_Room_Button.interactable = false;
        room_Password_Inputfield.interactable = false;
        PhotonNetwork.GameVersion = GameVersion;
        if (PhotonNetwork.IsConnected == false)
        {
        PhotonNetwork.ConnectUsingSettings();
        }
    }
    void Update()
    {
        //룸 이름 적지 않으면 룸 생성 못하도록 함
        if (room_Name_Inputfield.text != "" && is_Connected)
        {
            create_New_Room_Button.interactable = true;
        }else
        {
            create_New_Room_Button.interactable = false;
        }

        // 최대 플레이어 스크롤바
        max_Players_Text.text = max_Players_Slider.value.ToString();

        if (is_Private_Toggle.isOn)
        {
            room_Password_Inputfield.interactable = true;
        }

    }

    public override void OnConnectedToMaster()
    {        
        Debug.Log("Connected to Master Server.");
        is_Connected = true;
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        create_New_Room_Button.interactable = false;
        Debug.Log($"Connection Lost:\n{cause.ToString()}\nTrying to reconnect...");

        PhotonNetwork.ConnectUsingSettings();
    }
    public void create_New_Room()
    {
        // 유저가 입력한 정보들 저장
        room_Name = room_Name_Inputfield.text;
        room_Max_Players = (int)max_Players_Slider.value;
        map = "Classic";
        gamemode = gamemode_Dropdown.options[gamemode_Dropdown.value].ToString();
        is_Private = is_Private_Toggle.isOn;
        string tmp = room_Password_Inputfield.text;
        if (tmp != null)
        {
            room_Password = tmp;
        }else
        {
            room_Password = "";
        }

        if (is_Connected)
        {
            PhotonNetwork.CreateRoom(room_Name, new RoomOptions{MaxPlayers = (byte)room_Max_Players});
            Debug.Log($"Room Created\nRoom Name: {room_Name}, Room Max Players: {room_Max_Players}");
            SceneManager.LoadScene("Waiting_Room");
        }else
        {
            Debug.Log("Room Creating Failed, Not Connected to Master Server.");
        }
        
    }
}
