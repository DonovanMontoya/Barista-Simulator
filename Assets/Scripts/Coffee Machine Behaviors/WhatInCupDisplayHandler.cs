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
        whatsInCupList.text = "Steamed Milk: " + coffeeOrder.ingredientTable[Ingredients.SteamedMilk].ToString() +
         " Double Espresso: " + coffeeOrder.ingredientTable[Ingredients.EspressoDouble].ToString() +
        " Single Espresso: " + coffeeOrder.ingredientTable[Ingredients.EspressoSingle].ToString();

    }

}
