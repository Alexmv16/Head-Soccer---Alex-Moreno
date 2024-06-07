using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0, aiScore = 0;
    public float timer = 120f;
    public Text scoreText;
    public string score;

    // Pantallas de victoria y derrota
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // Contador de tiempo
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("Game over");
            EndGame();
        }

        // Verificar si algún jugador alcanzó 5 puntos
        if (playerScore >= 5 || aiScore >= 5)
        {
            EndGame();
        }
    }

    // Método para manejar los goles del jugador
    public void PlayerScoresGoal()
    {
        playerScore++;
        UpdateScoreText();
    }

    // Método para manejar los goles de la IA
    public void AIScoresGoal()
    {
        aiScore++;
        UpdateScoreText();
    }

    // Método para actualizar el texto del marcador
    void UpdateScoreText()
    {
        score = aiScore.ToString() + " - " + playerScore.ToString();
        scoreText.text = score;
    }

    // Método para finalizar el juego
    void EndGame()
    {
        // Mostrar pantalla de victoria o derrota según el puntaje
        if (playerScore >= 5)
        {
            defeatScreen.SetActive(true);
        }
        else
        {
            victoryScreen.SetActive(true);
        }

        // Volver al menú principal después de 3 segundos
        Invoke("ReturnToMainMenu", 3f);
    }

    // Método para volver al menú principal
    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}