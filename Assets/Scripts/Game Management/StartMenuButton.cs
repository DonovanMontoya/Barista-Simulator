using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class StartMenuButton : MonoBehaviour
{
    public string buttonTag;
    public void StartGame()
    {
        switch (buttonTag) 
        {
            case "Minigame":
                SceneManager.LoadScene("MiniGame Menu");
                GrinderBehaviorMiniGame.score = 0;
                GrinderBehaviorMiniGame.loseScore = 0;
                break;
            case "FreePlay":
                SceneManager.LoadScene("Main");
                break;
            case "LearnMode":
                SceneManager.LoadScene("Learning Mode");
                break;
        }
    }
}
