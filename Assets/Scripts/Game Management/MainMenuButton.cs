using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenuButton: MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
