using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject mainMenu;
    public void ShopButtonFunc(){
        mainMenu.SetActive(false);
        gameObject.SetActive(false);
        shopUI.SetActive(true);

    }
}
