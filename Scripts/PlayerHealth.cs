using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 7;  // Salud máxima del jugador
    public int currentHealth;  // Salud actual del jugador
    public HealthBar healthBar; // Referencia al script HealthBar

    private void Start()
    {
        currentHealth = maxHealth;  // Inicia la salud en su valor máximo
        healthBar.UpdateHealthBar(currentHealth); // Actualiza la barra de salud
    }


    void Update()
    {
        healthBar.UpdateHealthBar(currentHealth); // Actualiza la barra de salud
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tileSucia"))
        {
            Debug.Log("El jugador ha tomado daño");
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("BalaEnemigo1"))
        {
            Debug.Log("El jugador ha tomado daño");
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
         if (collision.gameObject.CompareTag("Slime"))
        {
            Debug.Log("El jugador ha tomado daño");
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("El jugador ha muerto");
            Destroy(collision.gameObject);
            SceneManager.LoadScene(3);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.UpdateHealthBar(currentHealth); // Actualiza la barra de salud
        if (currentHealth <= 0)
        {
            Debug.Log("El jugador ha muerto");
            SceneManager.LoadScene("GameOver");
        }
    }
}
