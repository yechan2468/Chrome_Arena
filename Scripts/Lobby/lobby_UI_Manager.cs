using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobby_UI_Manager : MonoBehaviour
{
    public Button configuration_Button;
    public Button developers_Button;
    public Button go_Back_To_Main_Button;

    void configuration()
    {
        SceneManager.LoadScene("Configuration");
    }

    void developers()
    {
        SceneManager.LoadScene("Developers");
    }

    void go_Back_To_Main()
    {
        SceneManager.LoadScene("Main");
    }
}
