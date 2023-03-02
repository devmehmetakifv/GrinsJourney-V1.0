using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text highScoreCount;

    public void Awake(){
        displayHighScore();
    }

    public void displayHighScore(){
        var highScoreData = HighScoreSaveSystem.LoadHighScore();
        highScoreCount.text = highScoreData.highScore.ToString() + " ft";
    }
}
