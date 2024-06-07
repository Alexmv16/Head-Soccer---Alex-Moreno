using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
