using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject balaFuerte;

    private int dañoActual = 1;
    private GameObject balaActual;
   public Animator animator;
    void Start()
    {
        balaActual = bala;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Disparar();

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            CambiarArma();
        if (dañoActual == 3)
        {
            animator.SetBool("Duro", true);    
        }else
        {
            animator.SetBool("Duro", false);
        }
        
    }

    private void Disparar()
    {
        GameObject nuevaBala = Instantiate(balaActual, controladorDisparo.position, controladorDisparo.rotation);
        nuevaBala.GetComponent<Bala>().SetDmg(dañoActual);
    }

    private void CambiarArma()
    {
        if (balaActual == bala)
        {
            balaActual = balaFuerte;
            dañoActual = 3;
        }
        else
        {
            balaActual = bala;
            dañoActual = 1;
        }
    }
}
