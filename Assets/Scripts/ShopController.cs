using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject mainMenuPanel;
    public Button tripleJumpButton,extraLifeButton,coinMagnetButton,doubleCoinsButton,tripleCoinsButton,moreVisionButton,quintupleCoinsButton,infiniteJumpButton;
    public TMP_Text playerCoins;
    public List<Image> unlockImageList = new List<Image>();
    const int tripleJumpPrice = 300,
            extraLifePrice = 400,
            coinMagnetPrice = 1500,
            doubleCoinsPrice = 750,
            tripleCoinsPrice = 1000,
            moreVisionPrice = 500,
            quintupleCoinsPrice = 3000,
            infiniteJumpPrice = 7500;
    public void Awake(){
        SetButtonInteractability();
    }
    public void Update(){
        UpdateCoinText();
    }
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    public void BackToMainMenu(){
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
        mainMenuPanel.SetActive(true);
    }
    public void purchaseTripleJump(){


        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isTripleJumpActive = true;
        upgradeData.isInfiniteJumpActive = false;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= tripleJumpPrice;
        CoinSaveSystem.SaveCoins(coinData);

        tripleJumpButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Triple Jump: "+upgradeData.isTripleJumpActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseExtraLife(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isExtraLifeActive = true;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= extraLifePrice;
        CoinSaveSystem.SaveCoins(coinData);

        extraLifeButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Extra Life: "+upgradeData.isExtraLifeActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseCoinMagnet(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isCoinMagnetActive = true;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= coinMagnetPrice;
        CoinSaveSystem.SaveCoins(coinData);

        coinMagnetButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Coin Magnet: "+upgradeData.isCoinMagnetActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseDoubleCoins(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isDoubleCoinsActive = true;
        upgradeData.isTripleCoinsActive = false;
        upgradeData.isQuintupleCoinsActive = false;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= doubleCoinsPrice;
        CoinSaveSystem.SaveCoins(coinData);

        doubleCoinsButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Double Coins: "+upgradeData.isDoubleCoinsActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseTripleCoins(){
        doubleCoinsButton.interactable = false;

        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isTripleCoinsActive = true;
        upgradeData.isDoubleCoinsActive = false;
        upgradeData.isQuintupleCoinsActive = false;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= tripleCoinsPrice;
        CoinSaveSystem.SaveCoins(coinData);

        tripleCoinsButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Triple Coins: "+upgradeData.isTripleCoinsActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseMoreVision(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isMoreVisionActive = true;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= moreVisionPrice;
        CoinSaveSystem.SaveCoins(coinData);

        moreVisionButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("More Vision: "+upgradeData.isMoreVisionActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseQuintupleCoins(){
        doubleCoinsButton.interactable = false;
        tripleCoinsButton.interactable = false;

        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isQuintupleCoinsActive = true;
        upgradeData.isTripleCoinsActive = false;
        upgradeData.isDoubleCoinsActive = false;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= quintupleCoinsPrice;
        CoinSaveSystem.SaveCoins(coinData);

        quintupleCoinsButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Quintuple Coins: "+upgradeData.isQuintupleCoinsActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void purchaseInfiniteJump(){
        tripleJumpButton.interactable = false;

        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isInfiniteJumpActive = true;
        upgradeData.isTripleJumpActive = false;

        UpgradeSaveSystem.SaveUpgrades(upgradeData);

        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount -= infiniteJumpPrice;
        CoinSaveSystem.SaveCoins(coinData);

        infiniteJumpButton.interactable = false;
        UpdateCoinText();
        SetButtonInteractability();

        Debug.Log("Infinite Jump: "+upgradeData.isInfiniteJumpActive);
        Debug.Log("Left Coin: "+coinData.coinAmount);
    }
    public void UpdateCoinText(){
        var coinData = CoinSaveSystem.LoadCoins();
        playerCoins.text = coinData.coinAmount.ToString();
    }
    public void SetButtonInteractability(){
        /*unlockImageList[0] -> 500ft
          unlockImageList[1] -> 1000ft
          unlockImageList[2] -> 3000ft
          unlockImageList[3] -> 5000ft*/
        var highScoreData = HighScoreSaveSystem.LoadHighScore();
        var coinData = CoinSaveSystem.LoadCoins();
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();

        if((highScoreData.highScore >= 500) && (highScoreData.highScore < 1000)){
            unlockImageList[0].gameObject.SetActive(false);
            if(coinData.coinAmount >= tripleCoinsPrice && !upgradeData.isTripleCoinsActive){
                tripleCoinsButton.interactable = true;
            }
            else{
                tripleCoinsButton.interactable = false;
            }
        }
        else if((highScoreData.highScore >= 1000) && (highScoreData.highScore < 3000)){
            unlockImageList[0].gameObject.SetActive(false);
            if(coinData.coinAmount >= tripleCoinsPrice && !upgradeData.isTripleCoinsActive){
                tripleCoinsButton.interactable = true;
            }
            else{
                tripleCoinsButton.interactable = false;
            }

            unlockImageList[1].gameObject.SetActive(false);
            if(coinData.coinAmount >= coinMagnetPrice && !upgradeData.isCoinMagnetActive){
                coinMagnetButton.interactable = true;
            }
            else{
                coinMagnetButton.interactable = false;
            }
        }
        else if((highScoreData.highScore >= 3000) && (highScoreData.highScore < 5000)){
            unlockImageList[0].gameObject.SetActive(false);
            if(coinData.coinAmount >= tripleCoinsPrice && !upgradeData.isTripleCoinsActive){
                tripleCoinsButton.interactable = true;
            }
            else{
                tripleCoinsButton.interactable = false;
            }

            unlockImageList[1].gameObject.SetActive(false);
            if(coinData.coinAmount >= coinMagnetPrice && !upgradeData.isCoinMagnetActive){
                coinMagnetButton.interactable = true;
            }
            else{
                coinMagnetButton.interactable = false;
            }

            unlockImageList[2].gameObject.SetActive(false);
            if(coinData.coinAmount >= quintupleCoinsPrice && !upgradeData.isQuintupleCoinsActive){
                quintupleCoinsButton.interactable = true;
            }
            else{
                quintupleCoinsButton.interactable = false;
            }
        }
        else if(highScoreData.highScore >= 5000){
            unlockImageList[0].gameObject.SetActive(false);
            if(coinData.coinAmount >= tripleCoinsPrice && !upgradeData.isTripleCoinsActive){
                tripleCoinsButton.interactable = true;
            }
            else{
                tripleCoinsButton.interactable = false;
            }

            unlockImageList[1].gameObject.SetActive(false);
            if(coinData.coinAmount >= coinMagnetPrice && !upgradeData.isCoinMagnetActive){
                coinMagnetButton.interactable = true;
            }
            else{
                coinMagnetButton.interactable = false;
            }

            unlockImageList[2].gameObject.SetActive(false);
            if(coinData.coinAmount >= quintupleCoinsPrice && !upgradeData.isQuintupleCoinsActive){
                quintupleCoinsButton.interactable = true;
            }
            else{
                quintupleCoinsButton.interactable = false;
            }

            unlockImageList[3].gameObject.SetActive(false);
            if(coinData.coinAmount >= infiniteJumpPrice && !upgradeData.isInfiniteJumpActive){
                infiniteJumpButton.interactable = true;
            }
            else{
                infiniteJumpButton.interactable = false;
            }
        }
        if(coinData.coinAmount >= tripleJumpPrice && !upgradeData.isTripleJumpActive){
            tripleJumpButton.interactable = true;
        }
        else{
            tripleJumpButton.interactable = false;
        }
        if(coinData.coinAmount >= extraLifePrice && !upgradeData.isExtraLifeActive){
            extraLifeButton.interactable = true;
        }
        else{
            extraLifeButton.interactable = false;
        }
        if(coinData.coinAmount >= doubleCoinsPrice && !upgradeData.isDoubleCoinsActive){
            doubleCoinsButton.interactable = true;
        }
        else{
            doubleCoinsButton.interactable = false;
        }
        if(coinData.coinAmount >= moreVisionPrice && !upgradeData.isMoreVisionActive){
            moreVisionButton.interactable = true;
        }
        else{
            moreVisionButton.interactable = false;
        }
    }
}
