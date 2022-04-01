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
    CoffeeOrderer coffeeOrderer;
    GrinderBehavior grinderBehavior;
    Interaction interaction;


    public bool holdingWand = false;



    [SerializeField] GameObject whereToPlaceWandGrinder = new GameObject();
    [SerializeField] GameObject whereToPlaceWandEsspresso = new GameObject();
    [SerializeField] GameObject whereToPlaceMilkMug = new GameObject();


    public void Update()
    {
        //tests to see if this works. If it doesn't work here it wont work elsewhere
        if (rHand.selectTarget.tag == "Wand" | lHand.selectTarget.tag == "Wand")
        {
            holdingWand = true;
        }
        switch (holdingWand)
        {
            case true:

                whereToPlaceWandGrinder.SetActive(true);
                whereToPlaceWandEsspresso.SetActive(false);
                whereToPlaceMilkMug.SetActive(false);
                break;

            case false:

                whereToPlaceWandGrinder.SetActive(false);
                whereToPlaceWandEsspresso.SetActive(true);
                whereToPlaceMilkMug.SetActive(false);
                break;
        }


        ////Checks if player is holding wand
        //if (rHand.selectTarget.tag == "Wand" | lHand.selectTarget.tag == "Wand")
        //{
        //    holdingWand = true;
        //    //Checks if wand has esspresso - if not, enables grinder placement object
        //    if (grinderBehavior.wandHasEspresso == false)
        //    {
        //        whereToPlaceWandGrinder.SetActive(true);
        //        whereToPlaceWandEsspresso.SetActive(false);
        //        whereToPlaceMilkMug.SetActive(false);
        //    }
        //    //Checks if wand has esspresso - if it does, enables espresso machine placement object
        //    else
        //    {
        //        whereToPlaceWandGrinder.SetActive(false);
        //        whereToPlaceWandEsspresso.SetActive(true);
        //        whereToPlaceMilkMug.SetActive(false);
        //    }

        //    //Checks if the machine has run i.e. cup has espresso
        //    if (interaction.machineRan == true)
        //    {
        //        //Checks if the drink will need milk, if so, turn on milk placement object
        //        if (coffeeOrderer.drinkName == "Latte")
        //        {
        //            whereToPlaceWandGrinder.SetActive(false);
        //            whereToPlaceWandEsspresso.SetActive(false);
        //            whereToPlaceMilkMug.SetActive(true);
        //        }
        //    }
        //    //Checks if the drink will need milk, if not, turn off all placement objects
        //    else
        //    {
        //        whereToPlaceWandGrinder.SetActive(false);
        //        whereToPlaceWandEsspresso.SetActive(false);
        //        whereToPlaceMilkMug.SetActive(false);
        //    }
        //}
        ////checks if player is holding wand, if they are not, bool will reflect this.
        //else
        //{
        //    holdingWand=false;
        //}
    }
}
