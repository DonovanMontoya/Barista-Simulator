using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MooMooMilker5000 : MonoBehaviour
{
    public Interaction interaction;
    public CoffeeOrderer coffeeOrder;
    public WhatInCupDisplayHandler cupHandler;

    public Animator anim;


    public void AddSteamedMilk()
    {
        anim.SetTrigger("StartSqeeze");
        coffeeOrder.ingredientTable[Ingredients.SteamedMilk] += 1;

        cupHandler.UpdateList();

            foreach (KeyValuePair<Ingredients, int> kvp in coffeeOrder.ingredientTable)
        {
            Debug.Log(kvp.Key);
            Debug.Log(kvp.Value);
        }
    }
}
