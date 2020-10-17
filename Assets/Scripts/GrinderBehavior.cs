using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GrinderBehavior : MonoBehaviour
{
    public static int grindValue;
    public static int matchGrindValue;
    public static int SetGrindValue;

    public GameObject currentGrindTextFine;
    public GameObject currentGrindTextMedium;
    public GameObject currentGrindTextCourse;
    public GameObject currentGrindTaskColdBrew;
    public GameObject currentGrindTaskEspresso;
    public GameObject currentGrindTaskFrenchPress;
    public GameObject currentGrindTaskLatte;
    public GameObject currentGrindTaskPourOver;
    public GameObject correctTag;
    public GameObject incorrectTag;
    public GameObject buttonReset;
    public GameObject resetTag;
    public GameObject latteDesc;
    public GameObject espressoDesc;
    public GameObject pourOverDesc;
    public GameObject coldBrewDesc;
    public GameObject frenchPressDesc;

    private void Start()
    {
        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(false);
        currentGrindTaskColdBrew.SetActive(false);
        currentGrindTaskEspresso.SetActive(false);
        currentGrindTaskFrenchPress.SetActive(false);
        currentGrindTaskLatte.SetActive(false);
        currentGrindTaskPourOver.SetActive(false);
        correctTag.SetActive(false);
        incorrectTag.SetActive(false);
        buttonReset.SetActive(false);
        resetTag.SetActive(false);
        latteDesc.SetActive(false);
        espressoDesc.SetActive(false);
        pourOverDesc.SetActive(false);
        coldBrewDesc.SetActive(false);
        frenchPressDesc.SetActive(false);

        PickNewGrindTask();
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PickNewGrindTask()
    {
        Random rand = new Random();
        int DrinkIndexNum = Random.Range(0, 4);

        // [0 = Fine] , [1 = Medium] [2 = Course]

        //0 Cold Brew
        if (DrinkIndexNum == 0)
        {
            SetGrindValue = 2;
            currentGrindTaskColdBrew.SetActive(true);
            coldBrewDesc.SetActive(true);
        }
        //1 Espresso
        if (DrinkIndexNum == 1)
        {
            SetGrindValue = 0;
            currentGrindTaskEspresso.SetActive(true);
            espressoDesc.SetActive(true);
        }
        //2 French Press
        if (DrinkIndexNum == 2)
        {
            SetGrindValue = 2;
            currentGrindTaskFrenchPress.SetActive(true);
            frenchPressDesc.SetActive(true);
        }
        //3 Latte
        if (DrinkIndexNum == 3)
        {
            SetGrindValue = 0;
            currentGrindTaskLatte.SetActive(true);
            latteDesc.SetActive(true);
        }
        //4 Pour Over
        if (DrinkIndexNum == 4)
        {
            SetGrindValue = 1;
            currentGrindTaskPourOver.SetActive(true);
            pourOverDesc.SetActive(true);
        }
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

        currentGrindTextFine.SetActive(true);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(false);
        Debug.Log("Grinder Set To Fine, Or grinderValue " + grindValue);
    }

    public void SetGrindValueMedium()
    {
        ChangeGrind(20);
        ChangeMatchValue(1);

        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(true);
        currentGrindTextCourse.SetActive(false);
        Debug.Log("Grinder Set To Medium, Or grinderValue " + grindValue);
    }

    public void SetGrindValueCourse()
    {
        ChangeGrind(30);
        ChangeMatchValue(2);

        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(true);
        Debug.Log("Grinder Set To Course, Or grinderValue " + grindValue);
    }
    public void Grind()
    {
        correctTag.SetActive(false);
        incorrectTag.SetActive(false);

        if (SetGrindValue == matchGrindValue)
        {
            correctTag.SetActive(true);
            buttonReset.SetActive(true);
            resetTag.SetActive(true);
            Debug.Log("CORRECT");
        }
        else
        {
            incorrectTag.SetActive(true);
            buttonReset.SetActive(true);
            resetTag.SetActive(true);
            Debug.Log("FALSE");
        }
        Debug.Log("Grinder is Grinding, grinderValue is " + grindValue);
    }
}
