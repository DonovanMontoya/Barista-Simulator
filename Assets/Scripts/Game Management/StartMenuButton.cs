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
        GrinderBehaviorMiniGame.score = 0;
        GrinderBehaviorMiniGame.loseScore = 0;
    }
}
