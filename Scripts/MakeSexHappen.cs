using UnityEngine;

public class MakeSexHappen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidad = 1;
    public Transform controladorSuelo;
    public float distancia;
    public bool moviendoDerecha = false;
    public Rigidbody2D rb;

    private void Update()
    {
                rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Nextlvl"))
        {
            // Cambia a la escena especificada
            Girar();
        }
        // Verifica si el objeto que colisiona es el Player
    }
   
    public void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); // Corregido cálculo de rotación
        velocidad *= -1;
    }

}
