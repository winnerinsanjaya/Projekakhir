using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene("Level 1");
    }
}
