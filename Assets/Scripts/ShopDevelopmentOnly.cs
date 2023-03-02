using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDevelopmentOnly : MonoBehaviour
{
    public ShopController shopController;

    public void ResetCoin(){
        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount = 0;
        CoinSaveSystem.SaveCoins(coinData);
        Debug.Log("Current Coin: "+coinData.coinAmount);
        shopController.tripleJumpButton.interactable = false;
        shopController.tripleCoinsButton.interactable = false;
        shopController.quintupleCoinsButton.interactable = false;
        shopController.moreVisionButton.interactable = false;
        shopController.infiniteJumpButton.interactable = false;
        shopController.extraLifeButton.interactable = false;
        shopController.doubleCoinsButton.interactable = false;
        shopController.coinMagnetButton.interactable = false;
    }
    public void GiveCoin(){
        var coinData = CoinSaveSystem.LoadCoins();
        coinData.coinAmount = 9999;
        CoinSaveSystem.SaveCoins(coinData);
        Debug.Log("Current Coin: "+coinData.coinAmount);
        shopController.tripleJumpButton.interactable = true;
        shopController.tripleCoinsButton.interactable = true;
        shopController.quintupleCoinsButton.interactable = true;
        shopController.moreVisionButton.interactable = true;
        shopController.infiniteJumpButton.interactable = true;
        shopController.extraLifeButton.interactable = true;
        shopController.doubleCoinsButton.interactable = true;
        //shopController.coinMagnetButton.interactable = true;
    }
    public void ResetUpgrades(){
        var upgradeData = UpgradeSaveSystem.LoadUpgrades();
        upgradeData.isCoinMagnetActive = false;
        upgradeData.isDoubleCoinsActive = false;
        upgradeData.isExtraLifeActive = false;
        upgradeData.isInfiniteJumpActive = false;
        upgradeData.isMoreVisionActive = false;
        upgradeData.isQuintupleCoinsActive = false;
        upgradeData.isTripleCoinsActive = false;
        upgradeData.isTripleJumpActive = false;

        shopController.tripleJumpButton.interactable = true;
        shopController.tripleCoinsButton.interactable = true;
        shopController.quintupleCoinsButton.interactable = true;
        shopController.moreVisionButton.interactable = true;
        shopController.infiniteJumpButton.interactable = true;
        shopController.extraLifeButton.interactable = true;
        shopController.doubleCoinsButton.interactable = true;
        shopController.coinMagnetButton.interactable = true;
        UpgradeSaveSystem.SaveUpgrades(upgradeData);
    }
}
