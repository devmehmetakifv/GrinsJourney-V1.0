using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    public MovePlayer movement;
    public Player player;
    public SpriteRenderer playerSpriteRenderer;

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Ground")){
            movement.currentJumpRights = movement.jumpRights;
            if(player.playerColor == "Black"){
                playerSpriteRenderer.sprite = player.spriteRenderer.sprite = player.originalSprites[4];
            }
            else if(player.playerColor == "Green"){
                playerSpriteRenderer.sprite = player.spriteRenderer.sprite = player.originalSprites[3];
            }
            else if(player.playerColor == "Brown"){
                playerSpriteRenderer.sprite = player.spriteRenderer.sprite = player.originalSprites[2];
            }
            else if(player.playerColor == "Blue"){
                playerSpriteRenderer.sprite = player.spriteRenderer.sprite = player.originalSprites[1];
            }
            else if(player.playerColor == "Beige"){
                playerSpriteRenderer.sprite = player.spriteRenderer.sprite = player.originalSprites[0];
            }
        }
    }
}
