using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Sprite beigeGrin;
    public Sprite blueGrin;
    public Sprite greenGrin;
    public Sprite brownGrin;
    public SoundManager soundManager;
    public Player player;
    public bool SetReviveUIActive = false;
    public List<Sprite> deadSprites = new List<Sprite>();

    public void OnTriggerEnter2D(Collider2D col){

        //Diamond Collisions

        if(col.CompareTag("BeigeDiamond")){
            player.ChangePlayerColor("Beige");
            gameObject.GetComponent<SpriteRenderer>().sprite = beigeGrin;
            Destroy(col.gameObject);
            soundManager.PlaySound("collectSound");
        }
        else if(col.CompareTag("BlueDiamond")){
            player.ChangePlayerColor("Blue");
            gameObject.GetComponent<SpriteRenderer>().sprite = blueGrin;
            Destroy(col.gameObject);
            soundManager.PlaySound("collectSound");
        }
        else if(col.CompareTag("GreenDiamond")){
            player.ChangePlayerColor("Green");
            gameObject.GetComponent<SpriteRenderer>().sprite = greenGrin;
            Destroy(col.gameObject);
            soundManager.PlaySound("collectSound");
        }
        else if(col.CompareTag("BrownDiamond")){
            player.ChangePlayerColor("Brown");
            gameObject.GetComponent<SpriteRenderer>().sprite = brownGrin;
            Destroy(col.gameObject);
            soundManager.PlaySound("collectSound");
        }

        //Gate Collisions

        else if(col.CompareTag("BeigeGate")){
            if(player.playerColor != "Beige"){
                if(player.playerColor == "Black"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[4];
                }
                if(player.playerColor == "Green"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[3];
                }
                if(player.playerColor == "Blue"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[1];
                }
                if(player.playerColor == "Brown"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[2];
                }
                SetReviveUIActive = true;
                Time.timeScale = 0f;
                player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
        }
        else if(col.CompareTag("BlueGate")){
            if(player.playerColor != "Blue"){
                if(player.playerColor == "Black"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[4];
                }
                if(player.playerColor == "Green"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[3];
                }
                if(player.playerColor == "Beige"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[0];
                }
                if(player.playerColor == "Brown"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[2];
                }
                SetReviveUIActive = true;
                Time.timeScale = 0f;
                player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
        }
        else if(col.CompareTag("GreenGate")){
            if(player.playerColor != "Green"){
                if(player.playerColor == "Black"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[4];
                }
                if(player.playerColor == "Blue"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[1];
                }
                if(player.playerColor == "Beige"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[0];
                }
                if(player.playerColor == "Brown"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[2];
                }
                SetReviveUIActive = true;
                Time.timeScale = 0f;
                player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
        }
        else if(col.CompareTag("BrownGate")){
            if(player.playerColor != "Brown"){
                if(player.playerColor == "Black"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[4];
                }
                if(player.playerColor == "Blue"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[1];
                }
                if(player.playerColor == "Beige"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[0];
                }
                if(player.playerColor == "Green"){
                    gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[3];
                }
                SetReviveUIActive = true;
                Time.timeScale = 0f;
                player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
        }

        // Coin Collisions

        else if(col.CompareTag("Coin")){
            Destroy(col.gameObject);
            player.AddCoin();
            soundManager.PlaySound("collectSound");
        }
    }

    // Spikes Collisions

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Spikes")){
            if(player.playerColor == "Black"){
                if(player.extraLifePoint != 1){
                    SetReviveUIActive = true;
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[4];
                player.KillPlayer();
                var upgradeData = UpgradeSaveSystem.LoadUpgrades();
                Time.timeScale = 0f;
                //player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
            else if(player.playerColor == "Blue"){
                if(player.extraLifePoint != 1){
                    SetReviveUIActive = true;
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[1];
                player.KillPlayer();
                var upgradeData = UpgradeSaveSystem.LoadUpgrades();
                Time.timeScale = 0f;
                //player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
            else if(player.playerColor == "Beige"){
                if(player.extraLifePoint != 1){
                    SetReviveUIActive = true;
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[0];
                player.KillPlayer();
                var upgradeData = UpgradeSaveSystem.LoadUpgrades();
                Time.timeScale = 0f;
                //player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
            else if(player.playerColor == "Green"){
                if(player.extraLifePoint != 1){
                    SetReviveUIActive = true;
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[3];
                player.KillPlayer();
                var upgradeData = UpgradeSaveSystem.LoadUpgrades();
                Time.timeScale = 0f;
                //player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
            else if(player.playerColor == "Brown"){
                if(player.extraLifePoint != 1){
                    SetReviveUIActive = true;
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = deadSprites[2];
                player.KillPlayer();
                var upgradeData = UpgradeSaveSystem.LoadUpgrades();
                Time.timeScale = 0f;
                //player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
            else{
                if(player.extraLifePoint != 1){
                    SetReviveUIActive = true;
                }
                player.KillPlayer();
                var upgradeData = UpgradeSaveSystem.LoadUpgrades();
                Time.timeScale = 0f;
                //player.KillPlayer();
                soundManager.PlaySound("deathSound");
            }
        }
    }
}
