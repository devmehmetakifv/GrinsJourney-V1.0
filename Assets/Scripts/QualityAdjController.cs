using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityAdjController : MonoBehaviour
{
    QualityAdjustment qualityAdjustment;
    // Start is called before the first frame update
    void Start()
    {
        qualityAdjustment = GameObject.Find("QualityAdj").GetComponent<QualityAdjustment>();
    }

    public void SetMainQuality(int qual){
        switch(qual){
            case 0:
                qualityAdjustment.QualityUltra();
                QualitySettings.SetQualityLevel(0);
            break;
    
            case 1:
                qualityAdjustment.QualityVeryHigh();
                QualitySettings.SetQualityLevel(1);
            break;

            case 2:
                qualityAdjustment.QualityHigh();
                QualitySettings.SetQualityLevel(2);
            break;

            case 3:
                qualityAdjustment.QualityMedium();
                QualitySettings.SetQualityLevel(3);
            break;

            case 4:
                qualityAdjustment.QualityLow();
                QualitySettings.SetQualityLevel(4);
            break;

            case 5:
                qualityAdjustment.QualityVeryLow();
                QualitySettings.SetQualityLevel(5);
            break;
        }
    }
}
