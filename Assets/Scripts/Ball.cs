using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    GameManager gm;
    Vector2 startPos;
    Rigidbody2D rb;
    public GameObject goalScreen;
    public AudioClip goalSound; // Nuevo campo para el sonido de gol
    private AudioSource audioSource; // Referencia al componente AudioSource

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        goalScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>(); // Obtener la referencia al componente AudioSource
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PortaPlayer")
        {
            gm.PlayerScoresGoal();
            rb.velocity = Vector2.zero;
            transform.position = startPos;
            ShowGoalScreen();
            PlayGoalSound(); // Reproducir el sonido de gol
        }
        else if (collision.gameObject.name == "PortaEnemy")
        {
            gm.AIScoresGoal();
            rb.velocity = Vector2.zero;
            transform.position = startPos;
            ShowGoalScreen();
            PlayGoalSound(); // Reproducir el sonido de gol
        }
    }

    void ShowGoalScreen()
    {
        goalScreen.SetActive(true);
        StartCoroutine(HideGoalScreen());
    }

    IEnumerator HideGoalScreen()
    {
        yield return new WaitForSeconds(2);
        goalScreen.SetActive(false);
    }

    // Método para reproducir el sonido de gol
    void PlayGoalSound()
    {
        audioSource.PlayOneShot(goalSound); // Reproducir el sonido de gol una sola vez
    }
}
