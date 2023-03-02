using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuButton : MonoBehaviour
{
    public GameObject MainMenuObject;
    public void BackToMainMenu(){
        MainMenuObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
