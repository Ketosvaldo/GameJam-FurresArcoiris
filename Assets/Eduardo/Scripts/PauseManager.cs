using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ShowWinScreen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ShowLoseScreen();
        }
        
    }

    public void PauseGame()
    {
        if (pauseScreen.activeInHierarchy)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(true);
        }
    }

    private void ShowLoseScreen()
    {
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }
    private void ShowWinScreen()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("Eduardo/Scenes/Level_1");
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
