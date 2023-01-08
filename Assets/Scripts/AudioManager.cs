using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource menuMusic, levelSelectMusic;
    public AudioSource[] backgroundMusic;

    public AudioSource[] SFX;

    private int currentSoundTruck;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StopMusic()
    {
        menuMusic.Stop();
        levelSelectMusic.Stop();
        backgroundMusic[currentSoundTruck].Stop();
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayLevelSelectMusic()
    {
        StopMusic();
        levelSelectMusic.Play();
    }

    public void PlayBackgroundMusic()
    {
        StopMusic();

        currentSoundTruck = Random.Range(0, backgroundMusic.Length);

        backgroundMusic[currentSoundTruck].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        SFX[sfxToPlay].Stop();
        SFX[sfxToPlay].Play();
    }
}
