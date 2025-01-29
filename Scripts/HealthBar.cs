using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject[] hearts; // Array de objetos de corazones

    void Start()
    {
        // Inicializa la barra de salud
        UpdateHealthBar(7); // Asume que el jugador empieza con 7 corazones
    }

    public void UpdateHealthBar(int currentHealth)
    {
        for (int i = 1; i <= hearts.Length; i++)
        {
            if (i <= currentHealth)
            {
                hearts[i - 1].SetActive(true); // Activa el corazón
            }
            else
            {
                hearts[i - 1].SetActive(false); // Desactiva el corazón
            }
        }
    }
}
