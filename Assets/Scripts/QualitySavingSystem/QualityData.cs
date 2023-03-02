using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QualityData
{
    public float bloomValue,vignetteValue,chromValue,grainValue,lensValue;
    
    public QualityData (QualityAdjustment qualityAdjustment){
        bloomValue = qualityAdjustment.bloom.intensity.value;
        vignetteValue = qualityAdjustment.vignette.intensity.value; 
        chromValue = qualityAdjustment.chromaticAberration.intensity.value; 
        grainValue = qualityAdjustment.grain.intensity.value; 
        lensValue = qualityAdjustment.lensDistortion.intensity.value;  
    }
}
