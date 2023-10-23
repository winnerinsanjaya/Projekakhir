using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManagerLobby : MonoBehaviour
{
    public static AudioManagerLobby instance;

    public SoundLobby[] sfxSound;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(string nama)
    {
        SoundLobby s = Array.Find(sfxSound, x => x.nama == nama);

        if (s == null)
        {
            Debug.Log("Sfx 404");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
