using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerLoader : MonoBehaviour
{
    public AudioManager audioManager;

    private void Awake()
    {
        if(FindObjectOfType<AudioManager>() == null)
        {
            AudioManager.instance = Instantiate(audioManager);
            DontDestroyOnLoad(AudioManager.instance.gameObject);
        }
    }
}
