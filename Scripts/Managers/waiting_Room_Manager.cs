using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class waiting_Room_Manager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.Log("New Player");

    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log("byebye");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leave_Room()
    {
        PhotonNetwork.LeaveRoom();
    }
}
