using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using Oculus.Platform.Models;


public class GrinderBehavior : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public GrinderSocket gS;
    public GameObject currentGrindTextFine;
    public GameObject currentGrindTextMedium;
    public GameObject currentGrindTextCourse;
    public GameObject espressoWand;
    public GameObject espressoWandEspresso;
    public static int grindValue;
    public static int matchGrindValue;
    public static int SetGrindValue;

    // trigger just for tutorial level
    public string grindValueString;

    public bool wandHasEspresso = false;

    private void Start()
    {
        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(false);

    }
    public void ChangeGrind(int val)
    {
        grindValue = val;
    }

    public void ChangeMatchValue(int val)
    {
        matchGrindValue = val;
    }
    public void SetGrindValueFine()
    {
        ChangeGrind(10);
        ChangeMatchValue(0);
        grindValueString = "fine";

        currentGrindTextFine.SetActive(true);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(false);
        // Debug.Log("Grinder Set To Fine, Or grinderValue " + grindValue);
    }

    public void SetGrindValueMedium()
    {
        ChangeGrind(20);
        ChangeMatchValue(1);
        grindValueString = "medium";

        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(true);
        currentGrindTextCourse.SetActive(false);
        // Debug.Log("Grinder Set To Medium, Or grinderValue " + grindValue);
    }

    public void SetGrindValueCourse()
    {
        ChangeGrind(30);
        ChangeMatchValue(2);
        grindValueString = "course";

        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(true);
        // Debug.Log("Grinder Set To Course, Or grinderValue " + grindValue);
    }
    public void Grind()
    {
        if (gS.isWandAttached == true)
        {
            if (wandHasEspresso == false)
            {
                wandHasEspresso = true;
                espressoWandEspresso.SetActive(true);
                gameManager.currentTask = "getCoffee";
                Debug.Log("Does the Wand have espresso after push: " + wandHasEspresso);
            }
            else
            {
                Debug.Log("Wand already has Espresso");
            }
        }
        else
        {
            wandHasEspresso = false;
            Debug.Log("Does the Wand have espresso after push: " + wandHasEspresso);
        }
    }
}