using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Movimiento : MonoBehaviour
{
    public float moveDistance = 10f;  
    public float speed = 3f;
    public Vector3 direction = Vector3.right; 

    private Vector3 startPos;
    private Vector3 worldDirection;

    private void Start()
    {
        startPos = transform.position;
        worldDirection = transform.TransformDirection(direction.normalized);
    }

    private void Update()
    {
        
        float offset = Mathf.PingPong(Time.time * speed, moveDistance);
        transform.position = startPos + worldDirection * (offset - moveDistance / 2f);
    }

    private void OnDrawGizmosSelected()
    {
      
        Gizmos.color = Color.yellow;
        Vector3 dir = Application.isPlaying ? worldDirection : transform.TransformDirection(direction.normalized);
        Gizmos.DrawLine(transform.position - dir * moveDistance / 2f, transform.position + dir * moveDistance / 2f);
    }
}
