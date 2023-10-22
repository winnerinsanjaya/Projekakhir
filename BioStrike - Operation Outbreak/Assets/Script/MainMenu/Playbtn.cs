using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbtn : MonoBehaviour
{

    [SerializeField]
    private GameObject ButtonContainer;

    public void PlayGame()
    {
        Time.timeScale = 1;
        AudioManager.instance.PlaySFX("UI");
        SceneManager.LoadScene("Intro");
    }
}
