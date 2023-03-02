using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreSaveSystem : MonoBehaviour
{
    private static readonly string path = Path.Combine(Application.persistentDataPath + "highScoreSaveSystem.json");
    public static void SaveHighScore(HighScoreSave highScoreSave){
        var json = JsonUtility.ToJson(highScoreSave,true);
        File.WriteAllText(path,json);

    }
    public static HighScoreSave LoadHighScore(){
        if(!File.Exists(path)){
            return new HighScoreSave();
        }
        var json = File.ReadAllText(path);

        return JsonUtility.FromJson<HighScoreSave>(json);
    }
    public class HighScoreSave{
        public float highScore = 0f;
    }
}
