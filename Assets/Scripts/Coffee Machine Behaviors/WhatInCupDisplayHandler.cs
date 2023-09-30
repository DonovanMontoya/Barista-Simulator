using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhatInCupDisplayHandler : MonoBehaviour
{
    public TextMeshProUGUI whatsInCupList;
    public CoffeeOrderer coffeeOrder;
    bool hasLiquid = false;

    private void Start()
    {
        UpdateList();
    }

    public void UpdateList()
    {
        string steamedMilk = coffeeOrder.ingredientTable.ContainsKey(Ingredients.SteamedMilk) ? coffeeOrder.ingredientTable[Ingredients.SteamedMilk].ToString() : "0";
        string doubleEspresso = coffeeOrder.ingredientTable.ContainsKey(Ingredients.EspressoDouble) ? coffeeOrder.ingredientTable[Ingredients.EspressoDouble].ToString() : "0";
        string singleEspresso = coffeeOrder.ingredientTable.ContainsKey(Ingredients.EspressoSingle) ? coffeeOrder.ingredientTable[Ingredients.EspressoSingle].ToString() : "0";

        whatsInCupList.text = "Steamed Milk: " + steamedMilk +
         " Double Espresso: " + doubleEspresso +
        " Single Espresso: " + singleEspresso;
    }

}
