using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject SettingsMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene("BattleGround");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void exitButton()
    {
        Application.Quit();
    }    
}
