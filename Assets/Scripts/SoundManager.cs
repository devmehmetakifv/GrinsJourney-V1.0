using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound,collectSound, deathSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        collectSound = Resources.Load<AudioClip>("collectSound");
        deathSound = Resources.Load<AudioClip>("deathSound");

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlaySound(string clip){
        switch(clip){
            case "jumpSound":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "collectSound":
                audioSource.PlayOneShot(collectSound);
                break;
            case "deathSound":
                audioSource.PlayOneShot(deathSound);
                break;
        }
    }
}
