using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public GameObject MainMenuObject;
    public GameObject CreditsObject;
    public void CreditsButtonFunc(){
        CreditsObject.SetActive(true);
        MainMenuObject.SetActive(false);
    }
}
