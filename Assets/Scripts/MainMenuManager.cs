using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    #region Menu Variables
    [Header("User Data")]
    public string player;
    public TMP_InputField userName;
    public TMP_Text highScore;

    #endregion



#region Start Menu Controls
public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }


    public void SaveName()
    {
        player = userName.text;
    }

    #endregion



}
