using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboPathing : MonoBehaviour
{
    public Transform [] target;
    public float speed;
    private int currentTarget;

    void Update()
    {
        if (transform.position != target[currentTarget].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position,target[currentTarget].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }else currentTarget = currentTarget +1 % target.Length;
    }
}
