using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float s;

    // Start is called before the first frame update
    void Start() //скорость движения сцены
    {
   
    }

    void FixedUpdate()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null && gameManager.isSpawningEnabled)
        {
            s = 0.1f;
            transform.position = new Vector3(transform.position.x - s, transform.position.y, 0);
        }
        else
        {
            s = 0;
            transform.position = new Vector3(transform.position.x,transform.position.y, 0);
        }

    }
}
