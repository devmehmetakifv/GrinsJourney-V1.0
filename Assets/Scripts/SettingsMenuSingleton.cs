using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SettingsMenuSingleton : MonoBehaviour
{
    public static SettingsMenuSingleton instance;

    private void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Awake(){
        MakeSingleton();
    }
}
