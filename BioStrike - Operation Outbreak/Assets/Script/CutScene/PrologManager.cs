using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologManager : MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene("Level 1");
    }
}
