using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathUIController : MonoBehaviour
{
    public Player player;
    public TMP_Text collectedCoinsCount;
    public TMP_Text travelledDistanceCount;

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void Awake(){
        printCollectedCoinsCount();
        printTravelledDistanceCount();
    }
    private void printCollectedCoinsCount(){
        collectedCoinsCount.text = player.coinCountText.text;
    }
    private void printTravelledDistanceCount(){
        travelledDistanceCount.text = player.distanceCountText.text;
    }

}
