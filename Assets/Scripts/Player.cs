using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject reviveUI;
    public string playerColor;
    public int coinCount;
    public float distanceCount;
    public bool isDead;
    public Transform spawnPoint;
    Transform playerTransform;
    public Transform cameraTransform;
    public TMP_Text coinCountText;
    public TMP_Text distanceCountText;
    public MovePlayer movePlayer;
    public Camera cameraObj;
    public int extraLifePoint;
    [SerializeField] LevelGenerator levelGenerator;
    public bool freezeAfterExtraLife = false;
    public PlayerCollision playerCollision;

    public LayerMask coinLayer;

    public List<Sprite> animationSprites = new List<Sprite>();
    public List<Sprite> originalSprites = new List<Sprite>();
    public List<Sprite> deadSprites = new List<Sprite>();
    public SpriteRenderer spriteRenderer;
    public bool isRevived = false;

    public void ChangePlayerColor(string color){
        switch(color){
            case "Green":
                playerColor = "Green";
                break;
            case "Blue":
                playerColor = "Blue";
                break;
            case "Brown":
                playerColor = "Brown";
                break;
            case "Beige":
                playerColor = "Beige";
                break;
        }
    }
    public void UpdateSprite(){
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if(playerColor == "Black"){
            if(rb.velocity.y > 0){
                spriteRenderer.sprite = animationSprites[9];
            }
            else if(rb.velocity.y < 0){
                spriteRenderer.sprite = animationSprites[8];
            }
        }
        if(playerColor == "Green"){
            if(rb.velocity.y > 0){
                spriteRenderer.sprite = animationSprites[7];
            }
            else if(rb.velocity.y < 0){
                spriteRenderer.sprite = animationSprites[6];
            }
            else{
                spriteRenderer.sprite = originalSprites[3];
            }
        }
        if(playerColor == "Brown"){
            if(rb.velocity.y > 0){
                spriteRenderer.sprite = animationSprites[5];
            }
            else if(rb.velocity.y < 0){
                spriteRenderer.sprite = animationSprites[4];
            }
            else{
                spriteRenderer.sprite = originalSprites[2];
            }
        }
        if(playerColor == "Blue"){
            if(rb.velocity.y > 0){
                spriteRenderer.sprite = animationSprites[3];
            }
            else if(rb.velocity.y < 0){
                spriteRenderer.sprite = animationSprites[2];
            }
            else{
                spriteRenderer.sprite = originalSprites[1];
            }
        }
        if(playerColor == "Beige"){
            if(rb.velocity.y > 0){
                spriteRenderer.sprite = animationSprites[1];
            }
            else if(rb.velocity.y < 0){
                spriteRenderer.sprite = animationSprites[0];
            }
            else{
                spriteRenderer.sprite = originalSprites[0];
            }
        }
    }
    public void AddCoin(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        if(upgradeData.isDoubleCoinsActive){
            coinCount+=2;
        }
        if(upgradeData.isTripleCoinsActive){
            coinCount+=3;
        }
        if(upgradeData.isQuintupleCoinsActive){
            coinCount+=5;
        }
        if(!upgradeData.isDoubleCoinsActive && !upgradeData.isTripleCoinsActive && !upgradeData.isQuintupleCoinsActive){
            coinCount++;
        }
    }
    public void UpdateCoinText(){
        coinCountText.text = coinCount.ToString();
    }
    public void KillPlayer(){
        //var highScoreData = HighScoreSaveSystem.LoadHighScore();
        //var coinData = CoinSaveSystem.LoadCoins();
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        if(upgradeData.isExtraLifeActive && (extraLifePoint == 1)){
            movePlayer.jumpRights = 2;
            if(upgradeData.isTripleJumpActive){
                movePlayer.jumpRights = 3;
            }
            if(upgradeData.isInfiniteJumpActive){
                movePlayer.jumpRights = 999999;
            }
            playerTransform.position = levelGenerator.lastStartPosition + new Vector2(0,0.8f);
            cameraObj.GetComponent<Transform>().position = playerTransform.position + new Vector3(0,0,10);
            extraLifePoint--;
            Time.timeScale = 0f;
            freezeAfterExtraLife = true;
            Debug.Log(movePlayer.jumpRights);
        }
        else{
            //isDead = true;
        }
    }
    public void SaveCoinAndDistance(){
        var highScoreData = HighScoreSaveSystem.LoadHighScore();
        var coinData = CoinSaveSystem.LoadCoins();
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        if(distanceCount > highScoreData.highScore){
            Debug.Log("You had "+ coinData.coinAmount+ " coins at the beginning of this round.");
            coinData.coinAmount += coinCount;
            CoinSaveSystem.SaveCoins(coinData);
            highScoreData.highScore = distanceCount;
            HighScoreSaveSystem.SaveHighScore(highScoreData);
            Time.timeScale = 0f;
            //Debugging
            Debug.Log("You earn " + coinCount + " coins this round.");
            Debug.Log("You have total of "+coinData.coinAmount + " coins now.");
        }
        else{
            Debug.Log("You had "+ coinData.coinAmount+ " coins at the beginning of this round.");
            coinData.coinAmount += coinCount;
            CoinSaveSystem.SaveCoins(coinData);
            Time.timeScale = 0f;
            Debug.Log("You earn " + coinCount + " coins this round.");
            Debug.Log("You have total of "+coinData.coinAmount + " coins now.");
        }
    }
    public float MeasureDistance(){
        return Vector2.Distance(new Vector2((int)playerTransform.position.x,0),new Vector2((int)spawnPoint.position.x,0));
    }
    public void UpdateDistanceText(){
        distanceCountText.text = MeasureDistance().ToString() + " FT";
    }

    void Start(){
        isDead = false;

        playerTransform = gameObject.GetComponent<Transform>();
        playerTransform.transform.position = spawnPoint.transform.position;

        coinCount = 0;
        Time.timeScale = 1f;
    }
    void Update(){
        distanceCount = MeasureDistance();
        UpdateCoinText();
        UpdateDistanceText();
        UpdateSprite();
        SetReviveUIActive();
        CoinMagnet();
    }
    public void SetReviveUIActive(){
        if(playerCollision.SetReviveUIActive && !isRevived){
            reviveUI.SetActive(true);
            playerCollision.SetReviveUIActive = true;
        }
    }
    public void Awake(){
        playerColor = "Black";
        var upgradeData = UpgradeSaveSystem.LoadUpgrades(); // Fetch all upgrade info
        if(upgradeData.isTripleJumpActive){
            movePlayer.jumpRights = 3;
        }
        if(upgradeData.isInfiniteJumpActive){
            movePlayer.jumpRights = 999999;
        }
        if(upgradeData.isMoreVisionActive){
            cameraObj.orthographicSize = 7f;
        }
        if(upgradeData.isExtraLifeActive){
            extraLifePoint = 1;
        }
    }

    public void CoinMagnet(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        if(upgradeData.isCoinMagnetActive){
            GameObject detectedCoin = Physics2D.OverlapCircle(playerTransform.position,6f,coinLayer).gameObject;
            detectedCoin.transform.position = Vector2.MoveTowards(detectedCoin.transform.position,playerTransform.position,30f*Time.deltaTime);
        }
    }

    /*private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerTransform.position,6f);
    }*/

    public void OnBecameInvisible(){
        playerCollision.SetReviveUIActive = true;
        Time.timeScale = 0f;
        KillPlayer();
    }

}
