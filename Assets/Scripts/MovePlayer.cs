using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float jumpRights = 2; //Default is 2, don't touch!
    public float currentJumpRights;
    public SoundManager soundManager;
    public RewardedAdsButton rewardedAdsButton;
    public Player player;
    public PlayerCollision playerCollision;

    void Start(){
        currentJumpRights = jumpRights;
    }
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + (moveSpeed * Time.deltaTime),gameObject.transform.position.y);
    }
    public void Jump(){
            if(rewardedAdsButton.isAdShowed)
            {
                currentJumpRights = 0f;
                Time.timeScale = 1f;
                rewardedAdsButton.isAdShowed = false;
                playerCollision.SetReviveUIActive = false;
                player.isRevived = false;
            }
            if(player.freezeAfterExtraLife)
            {
                //currentJumpRights = 0f;
                Time.timeScale = 1f;
                player.freezeAfterExtraLife = false;
            }
            if (currentJumpRights > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                soundManager.PlaySound("jumpSound");
                currentJumpRights--;
            }
    }
}
