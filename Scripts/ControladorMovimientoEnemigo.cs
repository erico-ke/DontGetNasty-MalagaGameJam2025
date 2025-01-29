using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContraladorMovimientoEnemigo : MonoBehaviour
{
    public float velocidad = 1;
    public Transform controladorSuelo;
    public float distancia;
    public bool moviendoDerecha = false;
    public Rigidbody2D rb; // Corregido: Rigidbody2D con "i" en lugar de "RigidBody2D"

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    public void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

        if (informacionSuelo == false)
        {
            Girar();
        }
    }

    public void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); // Corregido cálculo de rotación
        velocidad *= -1;
    }

}
