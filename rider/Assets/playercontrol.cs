using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    public GameObject gameOver;
    public float speed = 100f;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool ground = false;
    private float groundRadius = 0.5f;
    private Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        //float moveX = Input.GetAxis("Horizontal");
        //rgb.MovePosition(rgb.position + Vector2.right * moveX * speed * Time.deltaTime*8);
        if (Input.GetMouseButtonDown(0)&& ground == true)
            rgb.AddForce(Vector2.up * 3000 + Vector2.right * speed*10);
           // rgb.AddForce(Vector2.up * 8000);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            speed -= 30;
        }
        if (collision.tag == "Finish")
        {
            gameOver.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
    
