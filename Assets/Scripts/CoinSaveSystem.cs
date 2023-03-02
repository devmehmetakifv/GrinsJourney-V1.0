using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CoinSaveSystem : MonoBehaviour
{
    private static readonly string path = Path.Combine(Application.persistentDataPath + "coinSave.json");

    public static void SaveCoins(CoinSave coinSave)
    {  
        var json = JsonUtility.ToJson(coinSave, true);  
        
        File.WriteAllText(path, json);
    }

    public static CoinSave LoadCoins()
    {       
        if(!File.Exists(path)){
            return new CoinSave();
        }

        var json = File.ReadAllText(path);
        
        return JsonUtility.FromJson<CoinSave>(json);
    }

    public class CoinSave{
        public int coinAmount;
    }
}
