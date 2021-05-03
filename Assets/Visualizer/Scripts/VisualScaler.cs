using UnityEngine;


public class VisualScaler : MonoBehaviour
{
    public float scale;
    public int bin;

    void Update()
    {
        //original scaler visualizer
        /*
        var val = VisualizeSoundManager.Instance.bins[bin] * scale;
        transform.localScale = new Vector3(1,val, 1);
        */

        //color randomizer
        Color val = new Color
            (VisualizeSoundManager.Instance.bins[bin] * Random.value * scale, 
            VisualizeSoundManager.Instance.bins[bin] * Random.value * scale, 
            VisualizeSoundManager.Instance.bins[bin] * Random.value * scale);
        //color changer
        GetComponent<Renderer>().material.color = val;
        
    }
}

