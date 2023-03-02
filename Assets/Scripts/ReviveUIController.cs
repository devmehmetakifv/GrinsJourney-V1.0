using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveUIController : MonoBehaviour
{
    public GameObject deathUI;
    public PlayerCollision playerCollision;
    public RewardedAdsButton rewardedAdsButton;
    public Player player;
    public void Revive(){
        rewardedAdsButton.LoadAd();
    }
    public void backToDeathUI(){
        gameObject.SetActive(false);
        deathUI.SetActive(true);
        playerCollision.SetReviveUIActive = false;
        player.SaveCoinAndDistance();
        Debug.Log("Back To DEATH UI");
    }
}
