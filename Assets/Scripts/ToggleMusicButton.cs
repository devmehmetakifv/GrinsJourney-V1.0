using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusicButton : MonoBehaviour
{
    private GameManager gameManager;
    void Update(){
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }
    
    public void ToggleMusic(bool isOn){
        if(gameManager.bgMusic != null){
            gameManager.bgMusic.mute = isOn;
            PlayerPrefs.SetInt("toggleMusic",boolToInt(isOn));
            PlayerPrefs.Save();
        }
    }
    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }
}
