using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanelController : MonoBehaviour
{
    public GameObject pauseMenu;
    public void PauseMenu(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PauseMenuToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
