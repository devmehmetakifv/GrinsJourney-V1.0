using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuBackButton : MonoBehaviour
{
    public GameObject SettingsMenuObject;
    public GameObject MainMenuObject;
    public void SettingsMenuBackButtonFunction(){
        MainMenuObject.SetActive(true);
        SettingsMenuObject.SetActive(false);
    }
}
