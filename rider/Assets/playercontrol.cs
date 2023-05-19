using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{

    public bool isDead=false;
    public GameObject gameOver;
    public float speed = 1000f;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool ground = false;
    private float groundRadius = 0.5f;
    private Rigidbody2D rgb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        //rgb.MovePosition(rgb.position + Vector2.right * moveX * speed * Time.deltaTime*8);
        if (Input.GetMouseButtonDown(0) && ground == true) //проверка находится ли игрок на земле перед врыжком, чтобы не было бесконечного прыжка
           rgb.AddForce(Vector2.up * 3000  + Vector2.right * 350); //реализация прыжка, с движением вперед во время него, чтобы перепрыгнуть препятсвие
                                                                          // rgb.AddForce(Vector2.up * 8000);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            float moveX = -0.5f;
            rgb.MovePosition(rgb.position + Vector2.right * moveX  * Time.deltaTime * 30);
        }


        if (collision.tag == "Finish" && !isDead)
        {
            isDead = true;
            gameOver.SetActive(true);

            if (gameManager != null)
            {
                gameManager.isSpawningEnabled = false;
                gameManager.StopMovement();
            }
        }
    }
    public void Restart()

    {
       SceneManager.LoadScene("SampleScene");
    }
  
}

    
