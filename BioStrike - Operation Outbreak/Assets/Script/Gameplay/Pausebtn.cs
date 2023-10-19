using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausebtn : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseScreen;

    [SerializeField]
    private GameObject PlayScreen;
    public void PauseGame()
    {
        Time.timeScale = 0;
        PlayScreen.SetActive(false);
        PauseScreen.SetActive(true);
        AudioManager.instance.PlaySFX("Pause");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PlayScreen.SetActive(true);
        PauseScreen.SetActive(false);
        AudioManager.instance.PlaySFX("Pause");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
        AudioManager.instance.PlaySFX("Pause");
    }
}
