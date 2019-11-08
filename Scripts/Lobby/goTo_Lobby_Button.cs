using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goTo_Lobby_Button : MonoBehaviour
{
    public Button go_To_Lobby_Button;

    public void go_To_Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
