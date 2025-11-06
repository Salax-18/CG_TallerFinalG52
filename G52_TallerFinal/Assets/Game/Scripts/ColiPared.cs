using UnityEngine;

public class ColiPared : MonoBehaviour
{
    private bool haChocado = false;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Rojo") && !haChocado)
        {
            haChocado = true; 
            Debug.Log("Has chocado con una pared. Pierdes puntos.");
            GameManager.Instance.SubtractPoints(5);

          
            Invoke(nameof(ReactivarColision), 1f);
        }
    }

    private void ReactivarColision()
    {
        haChocado = false;
    }
}
