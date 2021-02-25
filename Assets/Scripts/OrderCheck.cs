using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OrderCheck : MonoBehaviour
{
    public CoffeeOrderer coffeeOrder;
    public WhatInCupDisplayHandler cupHandler;
    public TextMeshProUGUI robotsOrderText;
    public TextMeshProUGUI correctCoffeesText;

    public bool isPairCorrect = false;
    public int correctCoffies;

    public void Start()
    {
        CoffeeData data = SaveSystem.loadTotalCoffees();
        correctCoffies = data.correctCoffees;
    }

    public void CheckDrink()
    {
     // We assume the order is correct so that we can compair easier
        bool isDrinkCorrect = true;
        
     // This Loop compairs the ingrediants between the order and order requirements
        foreach (var ingredient in coffeeOrder.recipeTable.Keys)
        {
            if (coffeeOrder.recipeTable[ingredient] != coffeeOrder.ingredientTable[ingredient])
            {
                isDrinkCorrect = false;
                robotsOrderText.text = "I may not have taste buds, but my analysis says this is incorrect...";
            }
            Debug.Log(ingredient);
        }
        Debug.Log(isDrinkCorrect);

        if (isDrinkCorrect == true)
        {
            robotsOrderText.text = "Thats Perfect! Thank you human.";
            correctCoffies += 1;
        }
            SaveTotalCorrectCoffees();
    }

    public void EmptyCup()
    {
        coffeeOrder.ingredientTable[Ingredients.EspressoSingle] = 0;
        coffeeOrder.ingredientTable[Ingredients.EspressoDouble] = 0;
        coffeeOrder.ingredientTable[Ingredients.SteamedMilk] = 0;

        cupHandler.UpdateList();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void SaveTotalCorrectCoffees()
    {
        SaveSystem.SaveTotalCoffees(this);
    }
}
