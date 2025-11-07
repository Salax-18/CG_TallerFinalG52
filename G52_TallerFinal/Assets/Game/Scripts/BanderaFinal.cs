using UnityEngine;

public class BanderaFinal : MonoBehaviour
{
    public GameObject finalPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Llegaste a la meta!");
            GameManager.Instance.StopTimer(); 
            GameManager.Instance.ShowFinalPanel(finalPanel); 
        }
    }
}
