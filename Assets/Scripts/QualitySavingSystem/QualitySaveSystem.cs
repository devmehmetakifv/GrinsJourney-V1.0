using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class QualitySaveSystem : MonoBehaviour
{
    private static readonly string path = Path.Combine(Application.persistentDataPath + "quality.json");
    public static void SaveQuality(QualitySave qualitySave){
        var json = JsonUtility.ToJson(qualitySave,true);
        File.WriteAllText(path,json);

    }
    public static QualitySave LoadQuality(){
        if(!File.Exists(path)){
            return new QualitySave();
        }
        var json = File.ReadAllText(path);

        return JsonUtility.FromJson<QualitySave>(json);
    }
    public class QualitySave{
        public float bloomValue = 4.9f;
        public float vignetteValue = 0.456f;
        public float chromValue = 0.079f;
        public float grainValue = 0.1f;
        public float lensValue = 11f;
    }
}
