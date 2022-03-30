using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LoseScreenButton: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
