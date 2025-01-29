using UnityEngine;

public class TiempoDeVida : MonoBehaviour
{
    // Lifetime of the game object in seconds
    [SerializeField] private float TTL;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, TTL);   
    }
}
