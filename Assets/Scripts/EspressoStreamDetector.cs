using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspressoStreamDetector : MonoBehaviour
{
    public Transform origin = null;
    public GameObject streamPrefab = null;

    private bool endTimerEnabled = false;

    private Stream currentStream = null;

    public float endTimer = 60;


    private void Update()
    {
        if (endTimerEnabled)
        {
            endTimer -= 0.45f;
        }
        if (endTimer <= 0.0f)
        {
            EndPour();
        }
    }

    public void StartPour()
    {
        currentStream = CreateStream();
        currentStream.Begin();
        EndTimer();
    }

    private void EndTimer()
    {
        endTimerEnabled = true;
    }

    private void EndPour()
    {
        currentStream.End();
        currentStream = null;
        //resets these for re-use
        endTimerEnabled = false;
        endTimer = 60f;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}
