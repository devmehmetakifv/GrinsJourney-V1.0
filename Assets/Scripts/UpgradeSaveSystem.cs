using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UpgradeSaveSystem : MonoBehaviour
{
    private static readonly string path = Path.Combine(Application.persistentDataPath + "upgradeSaveSystem.json");
    public static void SaveUpgrades(UpgradeSave upgradeSave){
        var json = JsonUtility.ToJson(upgradeSave,true);
        File.WriteAllText(path,json);

    }
    public static UpgradeSave LoadUpgrades(){
        if(!File.Exists(path)){
            return new UpgradeSave();
        }
        var json = File.ReadAllText(path);

        return JsonUtility.FromJson<UpgradeSave>(json);
    }
    public class UpgradeSave{
        public bool isTripleJumpActive = false; //coded - tested - worked successfuly
        public bool isExtraLifeActive = false; //coded - tested - worked successfuly
        public bool isCoinMagnetActive = false; //coded - tested - worked successfuly
        public bool isDoubleCoinsActive = false; //coded - tested - worked successfuly
        public bool isTripleCoinsActive = false; //coded - tested - worked successfuly
        public bool isMoreVisionActive = false; //coded - tested - worked successfuly

        public bool isQuintupleCoinsActive = false; //coded - tested - worked successfuly
        public bool isInfiniteJumpActive = false; //coded - tested - worked successfuly
    }
}
