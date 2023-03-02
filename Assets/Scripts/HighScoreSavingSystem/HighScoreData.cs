using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public float bestDistanceCount;

    public HighScoreData(Player player){
        bestDistanceCount = player.distanceCount;
    }
}
