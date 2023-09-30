using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoffeeData
{
    public int correctCoffees;
    public CoffeeData(OrderCheck orderData)
    {
        correctCoffees = orderData.correctCoffies;
    }
}