using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightScaler : MonoBehaviour
{
    [SerializeField]
    private float defaultHeight = 1.8f;
    [SerializeField]
    private Camera camera;
    
    private void Resize()
    {
        float headHeight = camera.transform.position.y;
        float scale = defaultHeight / headHeight;
        transform.localScale = Vector3.one * scale;
    }

    void OnEnable()
    {
        Resize();
    }
}
