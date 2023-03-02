using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class QualityAdjustment : MonoBehaviour
{
    //Volume
    public PostProcessVolume postProcessingVolume;
    //Effects
    public Bloom bloom;
    public Vignette vignette;
    public ChromaticAberration chromaticAberration;
    public Grain grain;
    public LensDistortion lensDistortion;

    public static QualityAdjustment instance;
    private void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Awake(){
        MakeSingleton();
    }

    void Start(){
        postProcessingVolume.profile.TryGetSettings<Bloom>(out bloom);
        postProcessingVolume.profile.TryGetSettings<Vignette>(out vignette);
        postProcessingVolume.profile.TryGetSettings<ChromaticAberration>(out chromaticAberration);
        postProcessingVolume.profile.TryGetSettings<Grain>(out grain);
        postProcessingVolume.profile.TryGetSettings<LensDistortion>(out lensDistortion);
    }
    void Update(){
        postProcessingVolume = GameObject.FindObjectOfType<PostProcessVolume>();
    }

    public void QualityUltra(){
        var qualityData = QualitySaveSystem.LoadQuality();
        bloom.intensity.value = 4.9f;
        vignette.intensity.value = 0.456f;
        chromaticAberration.intensity.value = 0.079f;
        grain.intensity.value = 0.1f;
        lensDistortion.intensity.value = 11f;

        qualityData.bloomValue = bloom.intensity.value;
        qualityData.vignetteValue = vignette.intensity.value;
        qualityData.chromValue = chromaticAberration.intensity.value;
        qualityData.grainValue = grain.intensity.value;
        qualityData.lensValue = lensDistortion.intensity.value;
        //SaveQuality(4.9f,0.456f,0.079f,0.1f,11f);
        QualitySaveSystem.SaveQuality(qualityData);
    }

    public void QualityVeryHigh(){
        var qualityData = QualitySaveSystem.LoadQuality();
        bloom.intensity.value = 3.92f;
        vignette.intensity.value = 0.3648f;
        chromaticAberration.intensity.value = 0.0632f;
        grain.intensity.value = 0.08f;
        lensDistortion.intensity.value = 8.8f;

        qualityData.bloomValue = bloom.intensity.value;
        qualityData.vignetteValue = vignette.intensity.value;
        qualityData.chromValue = chromaticAberration.intensity.value;
        qualityData.grainValue = grain.intensity.value;
        qualityData.lensValue = lensDistortion.intensity.value;
        //SaveQuality(3.92f,0.3648f,0.0632f,0.08f,8.8f);
        QualitySaveSystem.SaveQuality(qualityData);
    }
    public void QualityHigh(){
        var qualityData = QualitySaveSystem.LoadQuality();
        bloom.intensity.value = 2.94f;
        vignette.intensity.value = 0.2736f;
        chromaticAberration.intensity.value = 0.0474f;
        grain.intensity.value = 0.06f;
        lensDistortion.intensity.value = 6.6f;

        qualityData.bloomValue = bloom.intensity.value;
        qualityData.vignetteValue = vignette.intensity.value;
        qualityData.chromValue = chromaticAberration.intensity.value;
        qualityData.grainValue = grain.intensity.value;
        qualityData.lensValue = lensDistortion.intensity.value;
        //SaveQuality(2.94f,0.2736f,0.0474f,0.06f,6.6f);
        QualitySaveSystem.SaveQuality(qualityData);
    }
    public void QualityMedium(){
        var qualityData = QualitySaveSystem.LoadQuality();
        bloom.intensity.value = 1.96f;
        vignette.intensity.value = 0.1824f;
        chromaticAberration.intensity.value = 0.0316f;
        grain.intensity.value = 0.04f;
        lensDistortion.intensity.value = 4.4f;

        qualityData.bloomValue = bloom.intensity.value;
        qualityData.vignetteValue = vignette.intensity.value;
        qualityData.chromValue = chromaticAberration.intensity.value;
        qualityData.grainValue = grain.intensity.value;
        qualityData.lensValue = lensDistortion.intensity.value;
        //SaveQuality(1.96f,0.1824f,0.0316f,0.04f,4.4f);
        QualitySaveSystem.SaveQuality(qualityData);
    }
    public void QualityLow(){
        var qualityData = QualitySaveSystem.LoadQuality();
        bloom.intensity.value = 0.98f;
        vignette.intensity.value = 0.0912f;
        chromaticAberration.intensity.value = 0.0158f;
        grain.intensity.value = 0.02f;
        lensDistortion.intensity.value = 2.2f;

        qualityData.bloomValue = bloom.intensity.value;
        qualityData.vignetteValue = vignette.intensity.value;
        qualityData.chromValue = chromaticAberration.intensity.value;
        qualityData.grainValue = grain.intensity.value;
        qualityData.lensValue = lensDistortion.intensity.value;
        //SaveQuality(0.98f,0.0912f,0.0158f,0.02f,2.2f);
        QualitySaveSystem.SaveQuality(qualityData);
    }
    public void QualityVeryLow(){
        var qualityData = QualitySaveSystem.LoadQuality();
        bloom.intensity.value = 0f;
        vignette.intensity.value = 0f;
        chromaticAberration.intensity.value = 0f;
        grain.intensity.value = 0f;
        lensDistortion.intensity.value = 0f;

        qualityData.bloomValue = bloom.intensity.value;
        qualityData.vignetteValue = vignette.intensity.value;
        qualityData.chromValue = chromaticAberration.intensity.value;
        qualityData.grainValue = grain.intensity.value;
        qualityData.lensValue = lensDistortion.intensity.value;
        //SaveQuality(0f,0f,0f,0f,0f);
        QualitySaveSystem.SaveQuality(qualityData);
    }
    /*public void SetMainQuality(int qual){
        switch(qual){
            case 0:
                QualityUltra();
                QualitySettings.SetQualityLevel(0);
            break;
    
            case 1:
                QualityVeryHigh();
                QualitySettings.SetQualityLevel(1);
            break;

            case 2:
                QualityHigh();
                QualitySettings.SetQualityLevel(2);
            break;

            case 3:
                QualityMedium();
                QualitySettings.SetQualityLevel(3);
            break;

            case 4:
                QualityLow();
                QualitySettings.SetQualityLevel(4);
            break;

            case 5:
                QualityVeryLow();
                QualitySettings.SetQualityLevel(5);
            break;
        }
    }*/
    /*public void SaveQuality(float bloomVal,float vignetteVal,float chromVal,float grainVal,float lensVal){
        PlayerPrefs.SetFloat("bloomVal",bloomVal);
        PlayerPrefs.SetFloat("vignetteVal",vignetteVal);
        PlayerPrefs.SetFloat("chromVal",chromVal);
        PlayerPrefs.SetFloat("grainVal",grainVal);                                                |-------------------|
        PlayerPrefs.SetFloat("lensVal",lensVal);                                                  |OLD SAVE SYSTEM .-.|
        PlayerPrefs.Save();                                                                       |-------------------|
    }
    public void UpdateQuality(){
        if(PlayerPrefs.HasKey("bloomVal") && PlayerPrefs.HasKey("vignetteVal") && PlayerPrefs.HasKey("chromVal") && PlayerPrefs.HasKey("grainVal") && PlayerPrefs.HasKey("lensVal")){
            bloom.intensity.value = PlayerPrefs.GetFloat("bloomVal");
            vignette.intensity.value = PlayerPrefs.GetFloat("bloomVal");
            chromaticAberration.intensity.value = PlayerPrefs.GetFloat("bloomVal");
            grain.intensity.value = PlayerPrefs.GetFloat("bloomVal");
            lensDistortion.intensity.value = PlayerPrefs.GetFloat("bloomVal");
        }
    }
    */
}
