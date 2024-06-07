using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public float rangedDefence, speed; // Rango de defensa y velocidad de movimiento
    public Transform defence; // Posición de defensa
    public GameObject Ball; // Referencia al objeto de la bola
    Rigidbody2D rb; // Componente Rigidbody2D

    public float jumpForce; // Fuerza de salto
    public bool isGrounded = false; // Variable que indica si está en el suelo

    void Start()
    {

        Ball = GameObject.FindGameObjectWithTag("Ball"); // Encontrar la bola por etiqueta
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {

        Move(); // Llamar al método de movimiento
        Jump(); // Llamar al método de salto
    }

    private void Move()
    {

        if (Mathf.Abs(Ball.transform.position.x + transform.position.x) > rangedDefence)
        {

            if (Ball.transform.position.x > transform.position.x)
            {
                transform.Translate(Time.deltaTime * speed, 0,0); // Mover hacia la derecha
            }
            else if (Ball.transform.position.x < transform.position.x)
            {
                transform.Translate(-Time.deltaTime * speed, 0, 0); // Mover hacia la izquierda
            }
            else if (Ball.transform.position.x == transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + 1.5f, transform.position.y); // Mover ligeramente a la derecha
            }
        }
        else
        {

            if (transform.position.x < defence.position.x)
            {
                transform.Translate(Time.deltaTime * speed, 0, 0); // Mover hacia la posición de defensa
            }
            else
            {
                transform.Translate(0, 0, 0); // No hacer nada
            }
        }
    }

    private void Jump()
    {

        float dist = Vector2.Distance(Ball.transform.position, transform.position); // Calcular distancia con la bola

        if (dist < 1f && isGrounded == true)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplicar fuerza de salto
            isGrounded = false; // Actualizar estado de estar en el suelo
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "terreno")
        {
            isGrounded = true; // Actualizar estado de estar en el suelo al colisionar con terreno
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "terreno")
        {
            isGrounded = false; // Actualizar estado de estar en el suelo al salir de la colisión con terreno
        }
    }
}
