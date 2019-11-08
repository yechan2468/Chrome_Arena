using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class In_Game_Manager : MonoBehaviourPun
{
    public bool isMasterClientLocal => PhotonNetwork.IsMasterClient;


    

    // Start is called before the first frame update
    void Start()
    {
        if (!isMasterClientLocal) 
        {
            return;
        }else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
