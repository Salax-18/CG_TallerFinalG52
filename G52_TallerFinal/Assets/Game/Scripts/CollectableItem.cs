using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [Header("Configuración del ítem")]
    public int points = 10;
    public bool isGoodItem = true;

    [Header("Sonido")]
    public AudioClip collectSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isGoodItem)
            {
                GameManager.Instance.AddPoints(points);
                Debug.Log("Has ganado +" + points + " puntos!");
            }
            else
            {
                GameManager.Instance.SubtractPoints(points);
                Debug.Log("Has perdido -" + points + " puntos!");
            }

            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

           
            Destroy(gameObject, collectSound != null ? collectSound.length : 0f);
        }
    }
}