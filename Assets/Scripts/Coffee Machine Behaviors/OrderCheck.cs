using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text;

public class OrderCheck : MonoBehaviour
{
    [SerializeField] public CoffeeOrderer coffeeOrder;
    [SerializeField] public Animator roboAnim;
    [SerializeField] GameObject mugLiquid;

    public WhatInCupDisplayHandler cupHandler;
    public TextMeshProUGUI robotsOrderText;
    public TextMeshProUGUI correctCoffeesText;


    CoffeeOrderer coffeeController;

    public bool isPairCorrect = false;
    public int correctCoffies;

    public void Start()
    {
        CoffeeData data = SaveSystem.loadTotalCoffees();
        correctCoffies = data.correctCoffees;
    }

    public void CheckOrder()
    {
        bool isDrinkCorrect = true;
        int hasWrongIngredient = 0;
        StringBuilder orderTextBuilder = new StringBuilder();

        foreach (var ingredient in coffeeOrder.recipeTable.Keys)
        {
            int ingredientCount = 0;
            if (coffeeOrder.ingredientTable.TryGetValue(ingredient, out ingredientCount))
            {
                if (ingredientCount != coffeeOrder.recipeTable[ingredient])
                {
                    isDrinkCorrect = false;
                    hasWrongIngredient++;
                    orderTextBuilder.AppendLine($"I may not have taste buds, but my analysis says {ingredient} is incorrect...");
                    roboAnim.ResetTrigger("correctOrder");
                    roboAnim.SetTrigger("wrongOrder");
                }
            }
        }

        if (isDrinkCorrect && hasWrongIngredient <= 0)
        {
            orderTextBuilder.AppendLine("Thats Perfect! Thank you human.");
            roboAnim.ResetTrigger("wrongOrder");
            roboAnim.SetTrigger("correctOrder");
            correctCoffies += 1;
        }

        robotsOrderText.text = orderTextBuilder.ToString().TrimEnd();
        SaveTotalCorrectCoffees();
    }

    public void EmptyCup()
    {
        coffeeOrder.ingredientTable[Ingredients.EspressoSingle] = 0;
        coffeeOrder.ingredientTable[Ingredients.EspressoDouble] = 0;
        coffeeOrder.ingredientTable[Ingredients.SteamedMilk] = 0;

        cupHandler.UpdateList();

        mugLiquid.SetActive(false);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void SetNextDrink()
    {
        SceneManager.LoadScene("Learning Mode Part2");
    }

    public void SaveTotalCorrectCoffees()
    {
        SaveSystem.SaveTotalCoffees(this);
    }
}