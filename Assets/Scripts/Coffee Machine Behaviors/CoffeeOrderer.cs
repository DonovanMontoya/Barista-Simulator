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
    public GameObject steamerOrderImage;

    public WhatInCupDisplayHandler cupHandler;
    public int DrinkIndexNum;

    [SerializeField] GameManager gameManager;
    [SerializeField] public string gameMode;

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
            case "learning - 2":
                SelectLiniarOrder();
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

        int DrinkIndexNum = Random.Range(0, 3);

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

        if (DrinkIndexNum == 2) //its just steamed milk... idk, thought I would clearify... k.. Thanks for reading this.
        {
            drinkName = "Steamer";
            recipeTable[Ingredients.EspressoDouble] = 0;
            recipeTable[Ingredients.SteamedMilk] = 1;
            recipeTable[Ingredients.EspressoSingle] = 0;
            steamerOrderImage.SetActive(true);
            Debug.Log(drinkName);
        }
    }
    public void SelectLiniarOrder()
    {
        switch (gameMode)
        {
            case "learning":
                espressoOrderImage.SetActive(false);
                latterOrderImage.SetActive(false);

                drinkName = "Espresso-Shot";
                gameManager.currentTask = "getGrind";
                espressoOrderImage.SetActive(true);
                recipeTable[Ingredients.EspressoDouble] = 0;
                recipeTable[Ingredients.SteamedMilk] = 0;
                recipeTable[Ingredients.EspressoSingle] = 1;
                Debug.Log(drinkName);
                break;
            case "learning - 2":
                espressoOrderImage.SetActive(false);
                latterOrderImage.SetActive(false);
                drinkName = "Latte";
                gameManager.currentTask = "getGrind";
                latterOrderImage.SetActive(true);
                recipeTable[Ingredients.EspressoDouble] = 1;
                recipeTable[Ingredients.SteamedMilk] = 1;
                recipeTable[Ingredients.EspressoSingle] = 0;
                Debug.Log(drinkName);
                break;
        }
    }

    public void SelectNextOrder()
    {

        espressoOrderImage.SetActive(false);
        latterOrderImage.SetActive(false);

        drinkName = "Latte";
        gameManager.currentTask = "getGrind";
        latterOrderImage.SetActive(true);
        recipeTable[Ingredients.EspressoDouble] = 1;
        recipeTable[Ingredients.SteamedMilk] = 1;
        recipeTable[Ingredients.EspressoSingle] = 0;
        Debug.Log(drinkName);
    }
}
