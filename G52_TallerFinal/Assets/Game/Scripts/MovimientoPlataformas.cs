using UnityEngine;

public class MovimientoPlataformas : MonoBehaviour
{
    [Header("Movimiento Vertical")]

    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 2f;


    private void Start()
    {
        startPoint = transform.position;

        endPoint = startPoint + new Vector3(0, 1, 0);
    }

    private void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPoint, endPoint, time);
    }
}
