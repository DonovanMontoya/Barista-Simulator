using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoffeeOrderer : MonoBehaviour
{
    public List<string> orderRequirements = new List<string>();
    public List<Ingredients> enumRequirements = new List<Ingredients>();
    public string drinkName;

    // Possible Ingrediants and what is in the cup itself
    public IDictionary<Ingredients, int> ingredientTable = new Dictionary<Ingredients, int>();
    //Holds the data for what should be in the recipe -- used to check if correct.
    public IDictionary<Ingredients, int> recipeTable = new Dictionary<Ingredients, int>();

    public TextMeshProUGUI robotsOrderText;
    public GameObject latterOrderImage;
    public GameObject espressoOrderImage;
    public WhatInCupDisplayHandler cupHandler;
    [SerializeField] GameManager gameManager;
    public int DrinkIndexNum;
    [SerializeField] string gameMode;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        ingredientTable.Add(Ingredients.EspressoDouble, 0);
        ingredientTable.Add(Ingredients.SteamedMilk, 0);
        ingredientTable.Add(Ingredients.EspressoSingle, 0);


        cupHandler.UpdateList();
        switch (gameMode)
        {
            case "learning":
                SelectLiniarOrder();
                break;
            case "freeplay":
                SelectRandomOrder();
                break;
        }

        foreach (KeyValuePair<Ingredients, int> kvp in ingredientTable)
        {
            Debug.Log(kvp.Key);
            Debug.Log(kvp.Value);
        }
    }

    public void SelectRandomOrder()
    {
        espressoOrderImage.SetActive(false);
        latterOrderImage.SetActive(false);

        Random rand = new Random();
        int DrinkIndexNum = Random.Range(0, 2);

        if (DrinkIndexNum == 0)
        {
            drinkName = "Latte";
            //Looking to see if the order image will be enough here.
            //robotsOrderText.text = "Robot Order Prefference: Espresso With Milk";
            latterOrderImage.SetActive(true);
            recipeTable[Ingredients.EspressoDouble] = 1;
            recipeTable[Ingredients.SteamedMilk] = 1;
            recipeTable[Ingredients.EspressoSingle] = 0;
            Debug.Log(drinkName);
        }

        if (DrinkIndexNum == 1)
        {
            drinkName = "Espresso-Shot";
            //Looking to see if the order image will be enough here.
            //robotsOrderText.text = "Robot Order Prefference: An Espresso";
            espressoOrderImage.SetActive(true);
            recipeTable[Ingredients.EspressoDouble] = 0;
            recipeTable[Ingredients.SteamedMilk] = 0;
            recipeTable[Ingredients.EspressoSingle] = 1;
            Debug.Log(drinkName);
        }
    }
    public void SelectLiniarOrder()
    {
        espressoOrderImage.SetActive(false);
        latterOrderImage.SetActive(false);
        
        drinkName = "Espresso-Shot";
        gameManager.currentTask = "getGrind";
        espressoOrderImage.SetActive(true);
        recipeTable[Ingredients.EspressoDouble] = 0;
        recipeTable[Ingredients.SteamedMilk] = 0;
        recipeTable[Ingredients.EspressoSingle] = 1;
        Debug.Log(drinkName);
    }
}
