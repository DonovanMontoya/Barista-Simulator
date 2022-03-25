using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MooMooMilker5000 : MonoBehaviour
{
    public Interaction interaction;
    public CoffeeOrderer coffeeOrder;
    public WhatInCupDisplayHandler cupHandler;

    public Color latteColor;
    public Color milkColor;

    public Animator anim;

    
    public void AddSteamedMilk()
    {
        anim.SetTrigger("StartSqeeze");
        coffeeOrder.ingredientTable[Ingredients.SteamedMilk] += 1;

        cupHandler.UpdateList();
        var liquidRenderer = interaction.cupLiquid.GetComponent<Renderer>();

        if (coffeeOrder.ingredientTable[Ingredients.EspressoDouble] >= 1)
        {
            liquidRenderer.material.SetColor("_Color", latteColor);
        }
        else
        {
            liquidRenderer.material.SetColor("_Color", milkColor);
            interaction.cupLiquid.SetActive(true);
        }
            foreach (KeyValuePair<Ingredients, int> kvp in coffeeOrder.ingredientTable)
        {
            Debug.Log(kvp.Key);
            Debug.Log(kvp.Value);
        }
    }
}
