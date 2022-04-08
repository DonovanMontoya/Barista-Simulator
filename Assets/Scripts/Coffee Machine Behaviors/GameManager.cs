using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    //public XRRayInteractor rHand;
    //public XRRayInteractor lHand;
    [SerializeField] CoffeeOrderer coffeeOrderer;
    [SerializeField] GrinderBehavior grinderBehavior;
    [SerializeField] Interaction interaction;
    [SerializeField] MooMooMilker5000 moomooMilker;
    [SerializeField] GrinderSocket grinderSocket;
    [SerializeField] MachineBehavior machineBehavior;

    public string currentTask;


    public bool holdingWand = false;


        [SerializeField] public GameObject whereToPlaceWandGrinder = new GameObject();
        [SerializeField] public GameObject whereToPlaceWandEsspresso = new GameObject();
        [SerializeField] public GameObject whereToPlaceMilkMug = new GameObject();
        [SerializeField] public GameObject whereToPlaceMugMaster = new GameObject(); //refers to main animated mug
        [SerializeField] public GameObject pressThisButtonE1 = new GameObject();
        [SerializeField] public GameObject pressThisButtonE2 = new GameObject();
        [SerializeField] public GameObject pressThisButtonGrindFine = new GameObject();
        [SerializeField] public GameObject pressThisButtonGrindGrind = new GameObject();
        [SerializeField] public GameObject pressThisButtonMilk = new GameObject();
    

    public void Update()
    {
        //for learning mode, checking what task we are on to implement code.
        switch (currentTask)
        {
            case "getGrind":
                //grinder socket iswandAttached is specific to grinder
                if (grinderSocket.isWandAttached) //is the wand in the espresso machine
                {
                    pressThisButtonGrindFine.SetActive(true); //next step select grind
                }
                if (grinderBehavior.grindValueString == "fine") //if correct grind selected turn off highlight and turn on grind button highlight
                {
                    pressThisButtonGrindFine.SetActive(false);
                    pressThisButtonGrindGrind.SetActive(true);
                }
                if (grinderBehavior.wandHasEspresso) //once the wand has espresso, next task -- getCoffee
                {
                    currentTask = "getCoffee";
                }
                break;
            case "getCoffee":
                getCoffeeSetup();
                //machine behavior iswandAttached is specific to the espresso machine
                if (machineBehavior.isWandAttached && coffeeOrderer.drinkName == "Espresso-Shot") //check if wand is in the espresso machone & if so, turn on correct button highlight
                {
                    pressThisButtonE1.SetActive(true); 
                    pressThisButtonE2.SetActive(false);
                }
                else
                {
                    pressThisButtonE1.SetActive(false);
                    pressThisButtonE2.SetActive(true);
                }
                if (interaction.cupHasEspresso && coffeeOrderer.drinkName == "Espresso-Shot")
                {
                    //Finishes espresso tutorial highlights
                    pressThisButtonE1.SetActive(false); 
                    whereToPlaceMugMaster.SetActive(false);
                }
                if (interaction.cupHasEspresso && coffeeOrderer.drinkName == "Latte") //if the cup has espresso and is a latte move on to milk step
                {
                    currentTask = "getMilk";
                }
                break;
            case "getMilk": 
                getMilkSetup(); //sets up milk step
                if (moomooMilker.hasMilk)//once milk is attained turn off highlight
                {
                    whereToPlaceMilkMug.SetActive(false);
                    pressThisButtonMilk.SetActive(false);
                }
                break;
        }
    }

    public void getCoffeeSetup()
    {
        whereToPlaceWandGrinder.SetActive(false);
        whereToPlaceWandEsspresso.SetActive(true);
        pressThisButtonE1.SetActive(true);
        pressThisButtonGrindGrind.SetActive(false);
        whereToPlaceMugMaster.SetActive(true);
        whereToPlaceMilkMug.SetActive(false);
    }
    public void getMilkSetup()
    {
        whereToPlaceWandGrinder.SetActive(false);
        whereToPlaceWandEsspresso.SetActive(false);
        whereToPlaceMugMaster.SetActive(false);
        pressThisButtonE1.SetActive(false);
        pressThisButtonE2.SetActive(false);
        whereToPlaceMilkMug.SetActive(true);
        pressThisButtonMilk.SetActive(true);
    }
}
