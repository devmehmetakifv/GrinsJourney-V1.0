using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource bgMusic;
    public QualityAdjustment qualityAdjustment;
    private Bloom fakeBloom;
    private Vignette fakeVignette;
    private ChromaticAberration fakeChrom;
    private Grain fakeGrain;
    private LensDistortion fakeLens;


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
        updateToggleMusic();
        updateQualityAdjustment();
    }
    
    public void updateToggleMusic(){
        bgMusic.mute = intToBool(PlayerPrefs.GetInt("toggleMusic"));
    }
    public void updateQualityAdjustment(){
        var qualityData = QualitySaveSystem.LoadQuality();
        /*qualityAdjustment.bloom.intensity.value = data.bloomValue;
        qualityAdjustment.vignette.intensity.value = data.vignetteValue; 
        qualityAdjustment.chromaticAberration.intensity.value = data.chromValue; 
        qualityAdjustment.grain.intensity.value = data.grainValue; 
        qualityAdjustment.lensDistortion.intensity.value = data.lensValue;*/
        qualityAdjustment.postProcessingVolume.profile.TryGetSettings<Bloom>(out fakeBloom);
        fakeBloom.intensity.value = qualityData.bloomValue;

        qualityAdjustment.postProcessingVolume.profile.TryGetSettings<Vignette>(out fakeVignette);
        fakeVignette.intensity.value = qualityData.vignetteValue;

        qualityAdjustment.postProcessingVolume.profile.TryGetSettings<ChromaticAberration>(out fakeChrom);
        fakeChrom.intensity.value = qualityData.chromValue;

        qualityAdjustment.postProcessingVolume.profile.TryGetSettings<Grain>(out fakeGrain);
        fakeGrain.intensity.value = qualityData.grainValue;

        qualityAdjustment.postProcessingVolume.profile.TryGetSettings<LensDistortion>(out fakeLens);
        fakeLens.intensity.value = qualityData.lensValue;
    }
    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
