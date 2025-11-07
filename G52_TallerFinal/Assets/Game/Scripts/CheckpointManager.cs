using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 respawnPosition;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        respawnPosition = transform.position; // Punto inicial
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró al trigger con: " + other.name);

        if (other.CompareTag("Checkpoint"))
        {
            respawnPosition = other.transform.position;
            Debug.Log("Checkpoint actualizado: " + respawnPosition);
        }

        if (other.CompareTag("Lava"))
        {
            Debug.Log("¡Tocó la lava!");
            Respawn();
        }
    }

    private void Respawn()
    {
        controller.enabled = false;
        transform.position = respawnPosition;
        controller.enabled = true;

        Debug.Log("Jugador reapareció");
    }
}
