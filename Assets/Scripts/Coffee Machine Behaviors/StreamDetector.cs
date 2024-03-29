﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamDetector : MonoBehaviour
{
    public Transform origin = null;
    public GameObject streamPrefab = null;
    private Stream currentStream = null;

    private bool isPouring = false;
    private bool endTimerEnabled = false;

    public float startTime = 1500.0f;
    public float endTime = 1500.0f;


    private void Update()
    {
        if (isPouring)
        {
            startTime -= 0.45f;
        }
        if (startTime <= 0.0f && isPouring)
        {
            StartPour();
        }
        if (endTimerEnabled)
        {
            endTime -= 0.45f;
        }
        if (endTime <= 0.0f)
        {
            EndPour();
        }
    }

    public void InteractButtonStart()
    {
        isPouring = true;
    }

    private void StartPour()
    {
        currentStream = CreateStream();
        currentStream.Begin();
        isPouring = false;
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
        isPouring = false;
        endTimerEnabled = false;
        startTime = 30f;
        endTime = 60f;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        // TODO: if stream is colliding with the cup, then fill it with coffee
    }
}
