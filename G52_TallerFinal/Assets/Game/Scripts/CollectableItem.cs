using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("10 PUNTOS");
            GameManager.Instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
