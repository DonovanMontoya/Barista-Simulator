using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool machineRunning = false;
    void Start()
    {
       
    }
    public void pressButtonBool()
    {
        machineRunning = true;
    }

    void Update()
    {
        //if (machineRunning)
        //{
        //    RunEsspressoMachine();
        //    Debug.Log("Turning on Machine");
        //}
    }

    public void RunEsspressoMachineSingle()
    {

        Debug.Log("Machine Run - Single");
        OffEsspressoMachine();
    }

    public void RunEsspressoMachineDouble()
    {
        Debug.Log("Machine Run - Double");
        OffEsspressoMachine();
    }

    public void OffEsspressoMachine()
    {
        Debug.Log("Machine Off");
        machineRunning = false;
    }
}
