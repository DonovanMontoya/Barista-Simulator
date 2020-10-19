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
    public static int score;
    public static int loseScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseScoreText;

    public GameObject currentGrindTextFine;
    public GameObject currentGrindTextMedium;
    public GameObject currentGrindTextCourse;
    public GameObject currentGrindTaskColdBrew;
    public GameObject currentGrindTaskEspresso;
    public GameObject currentGrindTaskFrenchPress;
    public GameObject currentGrindTaskLatte;
    public GameObject currentGrindTaskPourOver;
    public GameObject currentGrindEspressoVerte;
    public GameObject currentGrindCappuccino;
    public GameObject currentGrindIcedCoffee;
    public GameObject currentGrindMocha;
    public GameObject currentGrindAmericano;

    public GameObject correctTag;
    public GameObject incorrectTag;
    public GameObject buttonReset;
    public GameObject resetTag;
    public GameObject latteDesc;
    public GameObject espressoDesc;
    public GameObject pourOverDesc;
    public GameObject coldBrewDesc;
    public GameObject frenchPressDesc;
    public GameObject espressoVerteDesc;
    public GameObject capDesc;
    public GameObject icedCoffeeDesc;
    public GameObject mochaDesc;
    public GameObject americanoDesc;

    
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
        currentGrindEspressoVerte.SetActive(false);
        correctTag.SetActive(false);
        incorrectTag.SetActive(false);
        buttonReset.SetActive(false);
        resetTag.SetActive(false);
        latteDesc.SetActive(false);
        espressoDesc.SetActive(false);
        pourOverDesc.SetActive(false);
        coldBrewDesc.SetActive(false);
        frenchPressDesc.SetActive(false);
        espressoVerteDesc.SetActive(false);
        currentGrindCappuccino.SetActive(false);
        capDesc.SetActive(false);
        icedCoffeeDesc.SetActive(false);
        currentGrindIcedCoffee.SetActive(false);
        currentGrindMocha.SetActive(false);
        mochaDesc.SetActive(false);
        americanoDesc.SetActive(false);
        currentGrindAmericano.SetActive(false);

        PickNewGrindTask();
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        scoreText.text = score.ToString();
        loseScoreText.text = loseScore.ToString();
        if (score == 10)
        {
           // Debug.Log("WIN");
            SceneManager.LoadScene("WinScreen");
        }
        if (loseScore == 10)
        {
           // Debug.Log("LOSE");
            SceneManager.LoadScene("LoseScreen");
        }
    }

    public void PickNewGrindTask()
    {
        var used = new HashSet<int>() {};
        Random rand = new Random();
        int DrinkIndexNum = Random.Range(0, 9 - used.Count);

        Debug.Log(DrinkIndexNum);
        Debug.Log(used);

        // [0 = Fine] , [1 = Medium] [2 = Course]

        //0 Cold Brew
        if (DrinkIndexNum == 0)
        {
            SetGrindValue = 2;
            currentGrindTaskColdBrew.SetActive(true);
            coldBrewDesc.SetActive(true);
            used.Add(0);
        }
        //1 Espresso
        if (DrinkIndexNum == 1)
        {
            SetGrindValue = 0;
            currentGrindTaskEspresso.SetActive(true);
            espressoDesc.SetActive(true);
            used.Add(1);
        }
        //2 French Press
        if (DrinkIndexNum == 2)
        {
            SetGrindValue = 2;
            currentGrindTaskFrenchPress.SetActive(true);
            frenchPressDesc.SetActive(true);
            used.Add(2);
        }
        //3 Latte
        if (DrinkIndexNum == 3)
        {
            SetGrindValue = 0;
            currentGrindTaskLatte.SetActive(true);
            latteDesc.SetActive(true);
            used.Add(3);
        }
        //4 Pour Over
        if (DrinkIndexNum == 4)
        {
            SetGrindValue = 1;
            currentGrindTaskPourOver.SetActive(true);
            pourOverDesc.SetActive(true);
            used.Add(4);
        }
        //5 Espresso Verte
        if (DrinkIndexNum == 5)
        {
            SetGrindValue = 0;
            currentGrindEspressoVerte.SetActive(true);
            espressoVerteDesc.SetActive(true);
            used.Add(5);
        }
        //6 Cappuccino
        if (DrinkIndexNum == 6)
        {
            SetGrindValue = 0;
            currentGrindEspressoVerte.SetActive(true);
            espressoVerteDesc.SetActive(true);
            used.Add(6);
        }
        //7 Iced Coffee
        if (DrinkIndexNum == 7)
        {
            SetGrindValue = 1;
            currentGrindIcedCoffee.SetActive(true);
            icedCoffeeDesc.SetActive(true);
            used.Add(7);
        }
        //8 Espresso Mocha
        if (DrinkIndexNum == 8)
        {
            SetGrindValue = 0;
            currentGrindMocha.SetActive(true);
            mochaDesc.SetActive(true);
            used.Add(8);
        }
        //9 Americano
        if (DrinkIndexNum == 9)
        {
            SetGrindValue = 1;
            currentGrindAmericano.SetActive(true);
            americanoDesc.SetActive(true);
            used.Add(9);
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
       // Debug.Log("Grinder Set To Fine, Or grinderValue " + grindValue);
    }

    public void SetGrindValueMedium()
    {
        ChangeGrind(20);
        ChangeMatchValue(1);

        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(true);
        currentGrindTextCourse.SetActive(false);
       // Debug.Log("Grinder Set To Medium, Or grinderValue " + grindValue);
    }

    public void SetGrindValueCourse()
    {
        ChangeGrind(30);
        ChangeMatchValue(2);

        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(true);
       // Debug.Log("Grinder Set To Course, Or grinderValue " + grindValue);
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
            score += 1;
           // Debug.Log("CORRECT");
        }
        else
        {
            incorrectTag.SetActive(true);
            buttonReset.SetActive(true);
            resetTag.SetActive(true);
            loseScore += 1;
           // Debug.Log("FALSE");
        }
       // Debug.Log("Grinder is Grinding, grinderValue is " + grindValue);
    }
}
