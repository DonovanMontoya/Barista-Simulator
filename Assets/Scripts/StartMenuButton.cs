﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Minigame");
        //SceneManager.UnloadScene("Main Menu");
    }
}
