using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject objects;
    void Start()
    {
        InvokeRepeating("CreateObjects", 0, 1.73f);

    }

    
    void CreateObjects()
    {
        Instantiate(objects, new Vector3(-5.8f, 3.89f, 0), Quaternion.identity);
    }
}
