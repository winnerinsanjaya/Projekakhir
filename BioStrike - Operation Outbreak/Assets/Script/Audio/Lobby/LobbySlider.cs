using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySlider : MonoBehaviour
{
    public Slider bgmSlider, sfxSlider;

    public void SFXVolume()
    {
        AudioManagerLobby.instance.SFXVolume (sfxSlider.value);
    }

    public void BGMVolume()
    {
        AudioManagerLobby.instance.BGMVolume(bgmSlider.value);
    }
}
