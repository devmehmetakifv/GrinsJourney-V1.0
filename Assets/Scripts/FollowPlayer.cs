using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetVec;
    public MovePlayer movePlayer;
    Player player;

    void Awake(){
        player = target.GetComponent<Player>();
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + movePlayer.moveSpeed*Time.deltaTime,target.transform.position.y + offsetVec.y,target.transform.position.z + offsetVec.z);
        FastenCameraAndPlayer();
    }

    public void FastenCameraAndPlayer(){
        if(player.distanceCount > 500){
            movePlayer.moveSpeed = 3.7f;
        }
        else if(player.distanceCount > 1000){
            movePlayer.moveSpeed = 3.9f;
        }
        else if(player.distanceCount > 3000){
            movePlayer.moveSpeed = 4.1f;
        }
    }
}
