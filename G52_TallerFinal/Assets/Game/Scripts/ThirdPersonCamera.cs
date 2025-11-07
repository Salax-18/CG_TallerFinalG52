using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Referencias")]
    public Transform target;       

    [Header("Distancia y offset")]
    public Vector3 offset = new Vector3(0f, 2f, -4f);
    public float minZoom = 2f;
    public float maxZoom = 8f;
    public float zoomSpeed = 2f;
    private float currentZoom = 4f;

    [Header("Rotación")]
    public float sensitivity = 2f;   // velocidad de rotación
    public float smoothSpeed = 10f;  // suavidad de movimiento
    private float yaw;               // rotación horizontal
    private float pitch;             // rotación vertical

    void Start()
    {
        currentZoom = Mathf.Abs(offset.z); //zoom
    }

    void LateUpdate()
    {
        if (!target) return;

      
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f); 

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);


        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0f, offset.y, -currentZoom);



        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
