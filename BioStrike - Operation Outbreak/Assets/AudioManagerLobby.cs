using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Kontol : MonoBehaviour
{
    public static Kontol instance;

    public SoundLobby[] bgmSound, sfxSound;
    public AudioSource bgmSource, sfxSource;

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

    public void PlayBGM(string nama)
    {
        SoundLobby s = Array.Find(bgmSound, x => x.nama == nama);

        if (s == null)
        {
            Debug.Log("Bgm 404");
        }
        else
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
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
