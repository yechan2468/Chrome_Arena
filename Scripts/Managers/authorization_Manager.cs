using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class authorization_Manager : MonoBehaviour
{
    public InputField nickname_Inputfield;
    public Button start_Button;
    public static string Nickname;

    // Start is called before the first frame update
    void Start()
    {
        start_Button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nickname_Inputfield.text == "")
        {
            start_Button.interactable = false;
        }
        else
        {
            start_Button.interactable = true;
        }
        
    }

    public void startGame()
    {
        Nickname = nickname_Inputfield.text;
        SceneManager.LoadScene("Lobby");

    }

    public void quitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL("http://google.com");
        #else
            Application.Quit();
        #endif
    }
}
