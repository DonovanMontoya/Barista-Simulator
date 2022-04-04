using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public XRRayInteractor rHand;
    public XRRayInteractor lHand;
    [SerializeField] CoffeeOrderer coffeeOrderer;
    [SerializeField] GrinderBehavior grinderBehavior;
    [SerializeField] Interaction interaction;
    [SerializeField] MooMooMilker5000 moomooMilker;

    public string currentTask;


    public bool holdingWand = false;



    [SerializeField] public GameObject whereToPlaceWandGrinder = new GameObject();
    [SerializeField] public GameObject whereToPlaceWandEsspresso = new GameObject();
    [SerializeField] public GameObject whereToPlaceMilkMug = new GameObject();
    [SerializeField] public GameObject whereToPlaceMugMaster = new GameObject();
    [SerializeField] public GameObject pressThisButtonE1 = new GameObject();
    [SerializeField] public GameObject pressThisButtonM1 = new GameObject();


    public void Update()
    {
        //for learning mode, checking what task we are on to implement code.
        switch (currentTask)
        {
            case "getGrind":
                if (grinderBehavior.wandHasEspresso)
                {
                    currentTask = "getCoffee";
                }
                break;
            case "getCoffee":
                getCoffeeSetup();
                if (interaction.cupHasEspresso | coffeeOrderer.drinkName == "latte")
                {
                    currentTask = "getCoffee";
                }
                break;
            case "getMilk":
                getMilkSetup();
                if (moomooMilker.hasMilk)
                {
                    whereToPlaceMilkMug.SetActive(false);
                }
                break;
        }
    }

    public void getCoffeeSetup()
    {
        whereToPlaceWandGrinder.SetActive(false);
        whereToPlaceWandEsspresso.SetActive(true);
        pressThisButtonE1.SetActive(true);
        whereToPlaceMilkMug.SetActive(false);
    }
    public void getMilkSetup()
    {
        whereToPlaceWandGrinder.SetActive(false);
        whereToPlaceWandEsspresso.SetActive(false);
        whereToPlaceMilkMug.SetActive(true);
        pressThisButtonE1.SetActive(true);
        pressThisButtonM1.SetActive(true);
    }
}
