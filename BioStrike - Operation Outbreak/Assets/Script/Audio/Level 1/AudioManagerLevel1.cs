using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManagerLevel1 : MonoBehaviour
{
    public static AudioManagerLevel1 instance;

    public SoundLevel1[] bgmSound, sfxSound;
    public AudioSource bgmSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        /*
        else
        {
            Destroy(gameObject);
        }*/
    }

     void Start()
    {
        PlayBGM("Theme");
    }

    public void PlayBGM(string nama)
    {
        SoundLevel1 s = Array.Find(bgmSound, x => x.nama == nama);

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
        SoundLevel1 s = Array.Find(sfxSound, x => x.nama == nama);

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
