﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehavior : MonoBehaviour
{
    public bool isWandAttached;
    public GameObject wand;
    public GameObject buttonLeft;
    public GameObject buttonRight;

    void Start()
    {
        buttonLeft.gameObject.SetActive(false);
        buttonRight.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wand")
        {
            isWandAttached = true;
            buttonLeft.gameObject.SetActive(true);
            buttonRight.gameObject.SetActive(true);
            Debug.Log("Wand Attached and Boolian is " + isWandAttached);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wand")
        {
            isWandAttached = false;
            buttonLeft.gameObject.SetActive(false);
            buttonRight.gameObject.SetActive(false);
            Debug.Log("Wand Removed and Boolian is " + isWandAttached);
        }
    }
}
