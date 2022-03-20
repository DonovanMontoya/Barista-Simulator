using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamDetector : MonoBehaviour
{
    public Transform origin = null;
    public GameObject streamPrefab = null;

    private bool isPouring = false;
    private Stream currentStream = null;

    private void Update()
    {

    }

    private void StartPour()
    {
        currentStream = CreateStream();
        currentStream.Begin();
    }
    private void EndPour()
    {

    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}
