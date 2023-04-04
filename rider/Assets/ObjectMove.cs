using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float s;

    // Start is called before the first frame update
    void Start()
    {
        s = 0.13f;

    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - s, transform.position.y, 0);
        if (transform.position.x <=-17.5f)
        {

        }
    }

}
