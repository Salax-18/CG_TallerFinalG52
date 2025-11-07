using UnityEngine;

public class SonidoManager : MonoBehaviour
{
    private static SonidoManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}

