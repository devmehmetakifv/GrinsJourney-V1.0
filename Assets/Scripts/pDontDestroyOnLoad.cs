using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pDontDestroyOnLoad : MonoBehaviour
{
    public static pDontDestroyOnLoad pinstance;
    private void MakeSingleton(){
        if(pinstance != null){
            Destroy(gameObject);
        }
        else{
            pinstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Awake(){
        MakeSingleton();
    }
}
