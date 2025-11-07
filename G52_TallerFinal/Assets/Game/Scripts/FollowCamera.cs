using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (!target) return;

        // Mantener posición fija detrás del jugador
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Mirar siempre hacia el jugador
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
