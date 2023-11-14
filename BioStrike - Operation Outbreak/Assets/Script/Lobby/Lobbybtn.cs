using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobbybtn : MonoBehaviour
{

    [SerializeField]
    private GameObject LobbyScreen;

    [SerializeField]
    private GameObject SoundSettingScreen;

    [SerializeField]
    private GameObject MoveSettingScreen;


    public void Start()
    {
        AudioManagerLobby.instance.bgmSource.Stop();
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        AudioManagerLobby.instance.bgmSource.Stop();
        AudioManagerLobby.instance.PlaySFX("UI");
        SceneManager.LoadScene("CutSceneProlog");
    }

    public void GoToCredit()
    {
        Time.timeScale = 1;
        AudioManagerLobby.instance.bgmSource.Stop();
        SceneManager.LoadScene("Credit");
        AudioManagerLobby.instance.PlaySFX("UI");
    }

    public void Backlobby()
    {
        LobbyScreen.SetActive(true);
        SoundSettingScreen.SetActive(false);
        MoveSettingScreen.SetActive(false);
        Time.timeScale = 1;
        AudioManagerLobby.instance.PlaySFX("UI");
    }

    public void SoundSetting()
    {
        LobbyScreen.SetActive(false);
        SoundSettingScreen.SetActive(true);
        MoveSettingScreen.SetActive(false);
        Time.timeScale = 0;
     //   AudioManagerLobby.instance.PlayBGM("Lobby");
        AudioManagerLobby.instance.PlaySFX("UI");
    }

    public void MoveSetting()
    {
        LobbyScreen.SetActive(false);
        SoundSettingScreen.SetActive(false);
        MoveSettingScreen.SetActive(true);
        Time.timeScale = 0;
        AudioManagerLobby.instance.PlaySFX("UI");
    }

    
}
