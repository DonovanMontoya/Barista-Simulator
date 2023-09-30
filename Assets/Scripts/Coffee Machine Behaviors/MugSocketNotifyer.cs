using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugSocketNotifyer : MonoBehaviour
{
    public bool isMugAttached;
    public GameObject Mug;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mug")
        {
            isMugAttached = true;

            Debug.Log("Mug Attached and Boolian is " + isMugAttached);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mug")
        {
            isMugAttached = false;

            Debug.Log("Mug Removed and Boolian is " + isMugAttached);
        }
    }
}
