using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public AudioClip playerShoot;
    public AudioClip asteroidExplosion;
    public AudioClip playerDamage;
    public AudioClip playerExplosion;
    public AudioClip asteroidExplosion2;
    public AudioClip BgMusicGameplay;
    public AudioClip BgMusicTitleScreen;

    private AudioSource SFXaudioSource;

    private AudioSource BgMusicAudioSource;

    public float minPitch = 0.8f; 
    public float maxPitch = 1.2f;
    public float tempoMultiplier = 1.05f;



    private AsteroidSpawner asteroidSpawner;
    

    public void Awake()
    {
        SFXaudioSource = GetComponent<AudioSource>();
        //GameObject child = this.transform.Find("BgMusic").gameObject;
        BgMusicAudioSource = gameObject.transform.Find("BgMusic").gameObject.GetComponent<AudioSource>();

        asteroidSpawner = GetComponent<AsteroidSpawner>();
        


        
        //BgMusicAudioSource.GetComponent<AudioSource>().Play();       

        
    }



    //called in the PlayerController Script
    public void PlayerShoot()
    {
        SFXaudioSource.pitch = Random.Range(minPitch, maxPitch);
        SFXaudioSource.PlayOneShot(playerShoot);
    }

    //called in the PlayerController Script
    public void PlayerDamage()
    {
        
        SFXaudioSource.PlayOneShot(playerDamage);
    }

    //called in the PlayerController Script
    public void PlayerExplosion()
    {
        SFXaudioSource.PlayOneShot(playerExplosion);
    }

    //called in the AsteroidDestroy script
    public void AsteroidExplosion()
    {
        SFXaudioSource.PlayOneShot(asteroidExplosion);
    }

    
    public void BGMusicMainMenu()
    {
        BgMusicAudioSource.clip = BgMusicTitleScreen;
        BgMusicAudioSource.Play();
    }

    public void BGMusicGameplay()
    {
        BgMusicAudioSource.GetComponent<AudioSource>().clip = BgMusicGameplay;
        BgMusicAudioSource.Play();

        if(asteroidSpawner.waveCount != 0)
        {
            for(int i = 0; i < asteroidSpawner.waveCount; i++)
            {
                BgMusicAudioSource.pitch = tempoMultiplier;
                tempoMultiplier += 0.5f;
            }
        }

    }
}
