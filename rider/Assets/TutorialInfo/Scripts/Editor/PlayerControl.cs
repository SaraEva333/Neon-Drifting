using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour   
{
    public float speed = 20f;
    private Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rgb.MovePosition(rgb.position + Vector2.right * moveX * speed * Time.deltaTime);
        
    }
}
