using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoffeeOrderer : MonoBehaviour
{
    public List<string> orderRequirements = new List<string>();
    public List<Ingredients> enumRequirements = new List<Ingredients>();
    public string drinkName;
    public IDictionary<Ingredients, int> ingredientTable = new Dictionary<Ingredients, int>();
    public IDictionary<Ingredients, int> recipeTable = new Dictionary<Ingredients, int>();

    public TextMeshProUGUI robotsOrderText;

    void Start()
    {
        ingredientTable.Add(Ingredients.EspressoDouble, 0);
        ingredientTable.Add(Ingredients.SteamedMilk, 0);
        ingredientTable.Add(Ingredients.EspressoSingle, 0);

        SelectRandomOrder();

        foreach (KeyValuePair<Ingredients, int> kvp in ingredientTable)
        {
            Debug.Log(kvp.Key);
            Debug.Log(kvp.Value);
        }
    }

    void Update()
    {
        
    }

    void SelectRandomOrder()
    {
       
        
        Random rand = new Random();
        int DrinkIndexNum = Random.Range(0, 2);

        if (DrinkIndexNum == 0)
        {
            drinkName = "Latte";
            robotsOrderText.text = "I would Like An Espresso With Milk";
            recipeTable[Ingredients.EspressoDouble] = 1;
            recipeTable[Ingredients.SteamedMilk] = 1;
            recipeTable[Ingredients.EspressoSingle] = 0;
            Debug.Log(drinkName);
        }

        if (DrinkIndexNum == 1)
        {
            drinkName = "Espresso Shot";
            robotsOrderText.text = "I would Like An Espresso";
            recipeTable[Ingredients.EspressoDouble] = 0;
            recipeTable[Ingredients.SteamedMilk] = 0;
            recipeTable[Ingredients.EspressoSingle] = 1;
            Debug.Log(drinkName);
        }
    }
}
