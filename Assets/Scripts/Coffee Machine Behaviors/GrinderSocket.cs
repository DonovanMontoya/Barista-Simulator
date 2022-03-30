using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderSocket : MonoBehaviour
{
    public bool isWandAttached;
    public GameObject wand;
    public GameObject buttonGrind;
    public GameObject buttonFine;
    public GameObject buttonMedium;
    public GameObject buttonCourse;
    public GameObject grindButtonLabel;
    

    void Start()
    {
        buttonGrind.gameObject.SetActive(false);
        grindButtonLabel.gameObject.SetActive(false);

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wand")
        {
            isWandAttached = true;
            buttonGrind.gameObject.SetActive(true);
            grindButtonLabel.gameObject.SetActive(true);
            Debug.Log("Wand Attached and Boolian is " + isWandAttached);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wand")
        {
            isWandAttached = false;
            buttonGrind.gameObject.SetActive(false);
            grindButtonLabel.gameObject.SetActive(false);
            Debug.Log("Wand Removed and Boolian is " + isWandAttached);
        }
    }
}
