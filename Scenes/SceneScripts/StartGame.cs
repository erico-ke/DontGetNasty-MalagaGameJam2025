using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar escenas
using System.Collections;
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGameButton()
    {
        Debug.Log("Start Game Button Pressed");
        SceneManager.LoadScene(1); // Carga la escena "Level1"
    }
        public void ExitGameButton()
    {
        Debug.Log("Exit Game Button Pressed");
        Application.Quit(); // Sale del juego
    }
}
