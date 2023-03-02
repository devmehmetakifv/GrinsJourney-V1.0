using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public const float PLAYER_DISTANCE = 35f;
    public Transform LevelPart_0;
    public List<Transform> EasyLevelParts;
    public Vector2 lastEndPosition;
    public Vector2 lastStartPosition;
    public Transform player;
    public Transform lastLevelPartTransform;

    void Awake(){
        lastEndPosition = LevelPart_0.Find("EndPoint").position;
        lastStartPosition = LevelPart_0.Find("StartPoint").position;
        SpawnLevelPart();
    }
    void Update(){
        if(Vector3.Distance(player.position,lastEndPosition) < PLAYER_DISTANCE){
            SpawnLevelPart();
        }
    }

    public Transform GenerateLevel(Vector2 startPoint,Transform level){
        Transform levelPartTransform = Instantiate(level,startPoint,Quaternion.identity);
        return levelPartTransform;
    }
    public void SpawnLevelPart(){
        Transform chosenLevel = EasyLevelParts[Random.Range(0,EasyLevelParts.Count)];
        lastLevelPartTransform = GenerateLevel(lastEndPosition,chosenLevel);
        lastEndPosition = lastLevelPartTransform.Find("EndPoint").position;
        lastStartPosition = lastLevelPartTransform.Find("StartPoint").position;
    }
 
}
