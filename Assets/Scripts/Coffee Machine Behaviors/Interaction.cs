using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GrinderBehavior gB;
    [SerializeField] public CoffeeOrderer coffeeOrder;
    public WhatInCupDisplayHandler cupHandler;
    [SerializeField] GameManager gameManager;

    public GameObject cupLiquid;

    public Color Espresso;

    public bool cupHasEspresso;

    public bool machineRunning = false;
    public bool machineRan = false;
    public List<string> whatsInCupList = new List<string>();

    public void pressButtonBool()
    {
        machineRunning = true;
    }

    public void Update()
    {
        if (coffeeOrder.drinkName == "getMilk" && cupHasEspresso)
        {
            gameManager.whereToPlaceWandEsspresso.SetActive(false);
            gameManager.whereToPlaceWandGrinder.SetActive(false);
        }
        if (coffeeOrder.drinkName == "Espresso-Shot" && cupHasEspresso)
        {
            gameManager.whereToPlaceMilkMug.SetActive(false);
            gameManager.whereToPlaceWandEsspresso.SetActive(false);
            gameManager.whereToPlaceWandGrinder.SetActive(false);      
        }
    }

    public void RunEsspressoMachineSingle()
    {
        if (gB.wandHasEspresso == true)
        {
            Debug.Log("Machine Run - Single");
            coffeeOrder.ingredientTable[Ingredients.EspressoSingle] += 1;
            cupHandler.UpdateList();
            cupHasEspresso = true;
            OffEsspressoMachine();
            machineRan = true;
            //shows liquid visual object

            var liquidRenderer = cupLiquid.GetComponent<Renderer>();
            liquidRenderer.material.SetColor("_Color", Espresso);
            cupLiquid.SetActive(true);
        }
        else
        {
            Debug.Log("Wand Has no Espresso");
        }
    }

    public void RunEsspressoMachineDouble()
    {
        if (gB.wandHasEspresso == true)
        {
           Debug.Log("Machine Run - Double");
            coffeeOrder.ingredientTable[Ingredients.EspressoDouble] += 1;
            cupHandler.UpdateList();
            cupHasEspresso = true;
            OffEsspressoMachine();
            machineRan= true;
            //shows liquid visual object

            var liquidRenderer = cupLiquid.GetComponent<Renderer>();
            liquidRenderer.material.SetColor("_Color", Espresso);
            cupLiquid.SetActive(true);

            foreach (KeyValuePair<Ingredients, int> kvp in coffeeOrder.ingredientTable)
            {
                Debug.Log(kvp.Key);
                Debug.Log(kvp.Value);
            }
        }
        else
        {
            Debug.Log("Wand Has no Espresso");
        }
    }

    public void OffEsspressoMachine()
    {
        Debug.Log("Machine Off");
        machineRunning = false;
        
    }
}
