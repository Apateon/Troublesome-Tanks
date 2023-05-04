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
    public GameObject enemyprefab;
    GameObject[] enemies = new GameObject[3];

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

    private void Update()
    {
        if (enemies[0].IsDestroyed() && enemies[1].IsDestroyed() && enemies[2].IsDestroyed())//you have won condition
        {
            SceneManager.LoadScene("WinScreen");
        }
        else if (player.GetComponentInChildren<playerManager>().isDead)//you have lost the game
        {
            SceneManager.LoadScene("LooseScreen");
        }
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
        Instantiate(maps[mapnumber], new Vector3(0, 0, 1), Quaternion.identity);
        player.transform.position = new Vector3(-16, -3, 0);
        enemies[0] = Instantiate(enemyprefab, new Vector3(-9, 4, 0), Quaternion.identity);
        enemies[1] = Instantiate(enemyprefab, new Vector3(9, 4, 0), Quaternion.identity);
        enemies[2] = Instantiate(enemyprefab, new Vector3(9, -4, 0), Quaternion.identity);
    }
}
