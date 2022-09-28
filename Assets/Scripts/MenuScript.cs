using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuScript : MonoBehaviour
{
    public InputField playerName;

    public void PlayButton ()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitButton ()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnChangeInputName()
    {
        MySettings.Instance.PlayerName = playerName.text;
    }
}
