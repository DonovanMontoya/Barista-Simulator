using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class WinScreenButton: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
