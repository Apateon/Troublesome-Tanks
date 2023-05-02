using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LevelManager : MonoBehaviour
{
    public GameObject[] maps;
    public GameObject player;

    private PauseControls input;
    public GameObject pauseMenuPrefab;
    GameObject pauseMenu;
    private bool pauseflag = false;

    private void Awake()
    {
        input= new PauseControls();
    }

    private void OnEnable()
    {
        input.Enable();
        input.MenuControls.PauseGame.performed += gamePaused;
        input.MenuControls.ExitGame.performed += gameExit;
    }

    private void gamePaused(InputAction.CallbackContext value)
    {
        if(pauseflag)
        {
            pauseflag = false;
            Time.timeScale = 1;
            turretManager.isPaused = false;
            Destroy(pauseMenu);
        }
        else
        {
            pauseflag = true;
            Time.timeScale = 0;
            turretManager.isPaused = true;
            pauseMenu = Instantiate(pauseMenuPrefab, transform.position, transform.rotation);
        }
    }

    private void gameExit(InputAction.CallbackContext value)
    {
        pauseflag = false;
        Time.timeScale = 1;
        turretManager.isPaused = false;
        SceneManager.LoadScene("StartScreen");
    }

    void Start()
    {
        int mapnumber = Random.Range(0, maps.Length);
        GameObject map = Instantiate(maps[mapnumber], new Vector3(0, 0, 1), Quaternion.identity);
        player.transform.position = new Vector3(0, 0, 0);
    }
}
