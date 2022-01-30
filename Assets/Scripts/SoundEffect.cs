using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static AudioClip playerDeath, splash, congrat, enemyDeath;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerDeath= Resources.Load<AudioClip> ("PlayerDeath");
        splash= Resources.Load<AudioClip> ("Splash");
        congrat= Resources.Load<AudioClip> ("Congrat");
        enemyDeath= Resources.Load<AudioClip> ("EnemyDeath");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {  
    }


    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "playerDeath":
            audioSrc.PlayOneShot(playerDeath);
            break;

            case "enemyDeath":
            audioSrc.PlayOneShot(enemyDeath);
            break;

            case "splash":
            audioSrc.PlayOneShot(splash);
            break;

            case "congrat":
            audioSrc.PlayOneShot(congrat);
            break;
        }
    }
}
