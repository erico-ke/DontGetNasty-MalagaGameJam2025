using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidadBala;
    public int dañoBala = 1;


    void Update()
    {
        transform.Translate(Vector2.right * velocidadBala * Time.deltaTime);
    }

}
