using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3; // Aumenta la velocidad de 2 a 5
    public float jumpForce = 10; // Asegúrate de que el valor de jumpForce sea adecuado para tu juego
    public bool isGrounded = false;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("kick");
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
    }

    private void MoveLeft()
    {
        anim.SetFloat("speed", speed);
        Vector2 targetPos = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        transform.position = targetPos;
    }

    private void MoveRight()
    {
        anim.SetFloat("speed", speed);
        Vector2 targetPos = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        transform.position = targetPos;
    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "terreno")
        {
            isGrounded = true;
        }
    }
}
