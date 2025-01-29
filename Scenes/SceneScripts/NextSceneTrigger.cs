using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create

    [SerializeField] private int nextSceneNbr; // Nombre de la próxima escena

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el Player
        if (collision.gameObject.CompareTag("Nextlvl"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(nextSceneNbr);
        }
    }
}
