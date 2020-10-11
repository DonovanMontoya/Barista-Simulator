using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderBehavior : MonoBehaviour
{
    //public string[] grinderValue = {"Fine", "Course", "Medium"};
    public static int grindValue;
    public GameObject currentGrindTextFine;
    public GameObject currentGrindTextMedium;
    public GameObject currentGrindTextCourse;

    private void Start()
    {
        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(false);
    }
    public void ChangeGrind(int val)
    {
        grindValue = val;
    }

    public void SetGrindValueFine()
    {
        ChangeGrind(10);
        currentGrindTextFine.SetActive(true);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(false);
        Debug.Log("Grinder Set To Fine, Or grinderValue " + grindValue);
    }

    public void SetGrindValueMedium()
    {
        ChangeGrind(20);
        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(true);
        currentGrindTextCourse.SetActive(false);
        Debug.Log("Grinder Set To Medium, Or grinderValue " + grindValue);
    }

    public void SetGrindValueCourse()
    {
        ChangeGrind(30);
        currentGrindTextFine.SetActive(false);
        currentGrindTextMedium.SetActive(false);
        currentGrindTextCourse.SetActive(true);
        Debug.Log("Grinder Set To Course, Or grinderValue " + grindValue);
    }
    public void Grind()
    {
        Debug.Log("Grinder is Grinding, grinderValue is " + grindValue);
    }
}
