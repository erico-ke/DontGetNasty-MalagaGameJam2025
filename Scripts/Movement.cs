using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoConGiro : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public float movimientoHorizontal = 0f;
    private float velocidadDeMovimiento = 700f;
    public float suavizadoDeMovimiento = 0.3f;
    public Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private float fuerzaSalto = 12f;
    public bool estaEnSuelo = false;

    public bool agachado = false;
    public Vector3 normalscale;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        normalscale = transform.localScale;
    }

    void Update()
    {
        if (estaEnSuelo && Input.GetKeyDown(KeyCode.Space)) 
            Salto();
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        if (Input.GetKeyDown(KeyCode.LeftControl)) 
            Agacharse();
    }

    private void FixedUpdate()
    {
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", movimientoHorizontal);
    }

    void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y); 
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
    
        if (mover > 0 && !mirandoDerecha)
            Girar();
        else if(mover < 0 && mirandoDerecha)
            Girar();
    }

    void Agacharse()
    {
            Vector3 reducedscale = new Vector3(normalscale.x , normalscale.y / 2, normalscale.z);

        if (agachado)
        {
            transform.localScale = normalscale;  // Asignar el nuevo tamaño
            velocidadDeMovimiento = 700f;
            fuerzaSalto = 12;
            agachado = false;
        }else{
            transform.localScale = reducedscale;  // Asignar el nuevo tamaño
            velocidadDeMovimiento = 350f;
            fuerzaSalto = 0;
            agachado = true;
        }
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 1);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "suelo"
        if (collision.gameObject.CompareTag("suelo"))
        {
            estaEnSuelo = false;
            Debug.Log("¡El personaje ha salido del suelo!");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "suelo"
        if (collision.gameObject.CompareTag("suelo"))
        {
            estaEnSuelo = true;
            Debug.Log("¡El personaje está en el suelo!");
        }
    }
    public bool EstaEnSuelo()
    {
        return estaEnSuelo;
    }
    void Salto()
    {
        rb2D.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}