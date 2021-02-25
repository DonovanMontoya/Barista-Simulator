using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GrinderBehavior gB;
    public CoffeeOrderer coffeeOrder;
    public WhatInCupDisplayHandler cupHandler;

    public bool machineRunning = false;
    public List<string> whatsInCupList = new List<string>();

    void Start()
    {
       
    }
    public void pressButtonBool()
    {
        machineRunning = true;
    }

    void Update()
    {
        //foreach (var item in whatsInCupList)
        //{
        //    Debug.Log(item.ToString());
        //}
    }

    public void RunEsspressoMachineSingle()
    {
        if (gB.wandHasEspresso == true)
        {
            Debug.Log("Machine Run - Single");
            //whatsInCupList.Add("Espresso-Single");
            coffeeOrder.ingredientTable[Ingredients.EspressoSingle] += 1;
            cupHandler.UpdateList();
            OffEsspressoMachine();
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
           //whatsInCupList.Add("Espresso-Double");
            coffeeOrder.ingredientTable[Ingredients.EspressoDouble] += 1;
            cupHandler.UpdateList();
            OffEsspressoMachine();


            //foreach (var item in whatsInCupList)
            //  {
            //      Debug.Log(item.ToString());
            //  }
            //Debug.Log(coffeeOrder.ingredientTable.Values);
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
