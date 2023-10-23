using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;

public class AudioLobby : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxAudioSource;

    [SerializeField]
    private List<AudioClip> sfxClip;
}
