using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsMenuObject;
    public GameObject MainMenuObject;
    public void SettingsButtonFunc(){
        MainMenuObject.SetActive(false);
        SettingsMenuObject.SetActive(true);
    }
}
