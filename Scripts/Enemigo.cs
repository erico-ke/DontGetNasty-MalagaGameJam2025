using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida = 3;
    [SerializeField] private GameObject efectoMuerte;    
    public void DarDmg(float dmg)
    {
        vida -= dmg;
        if (vida <= 0)
            Destroy(gameObject);
    }

    private void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            DarDmg(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Bala2"))
        {
            DarDmg(3);
            Destroy(other.gameObject);
        }
    }
}
