using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class StartMenuButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Minigame");
        //SceneManager.UnloadScene("Main Menu");
        GrinderBehavior.score = 0;
        GrinderBehavior.loseScore = 0;
    }
}
