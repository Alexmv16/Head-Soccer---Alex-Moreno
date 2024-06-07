using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalScreenManager : MonoBehaviour
{
    void Start()
    {
        // Opcional: Desactivar el panel después de algunos segundos
        StartCoroutine(ShowGoalScreen());
    }

    private IEnumerator ShowGoalScreen()
    {
        yield return new WaitForSeconds(2); // Mostrar el mensaje por 2 segundos
        SceneManager.LoadScene("GameScene"); // Cambiar a la escena del juego
    }
}
