using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUi : MonoBehaviour
{

    [SerializeField]
    public GameObject pauseMenu;
    [SerializeField]
    public GameObject gameOverMenu;
    [SerializeField]
    public GameObject winMenu;
    [SerializeField]
    public GameObject startMenu;
    [SerializeField]
    public GameObject rulesMenu;


    // Start is called before the first frame update
    void Start()
    {

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        startMenu.SetActive(true);
        rulesMenu.SetActive(false);
        Pause();
    }

    

    // Update is called once per frame
    void Update()
    {
        //Menu de pause apres le clic sur le bouton ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            PauseMenu();
        }

        // Show variables
        // Debug.Log("isPaused: " + isPaused);
        // Debug.Log("inGame: " + inGame);
        // Debug.Log("Time.timeScale: " + Time.timeScale);

    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void StopApplication()
    {
        Application.Quit();
    }

    public void toTheMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Rules()
    {
       // Hide startMenu and show rules menu
        startMenu.SetActive(false);
        rulesMenu.SetActive(true);
    }

    

}
