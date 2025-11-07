using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene1 : MonoBehaviour
{
    public Transform jugador;
    public string nextSceneName = "Scene2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó el punto final. Cargando siguiente escena...");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
