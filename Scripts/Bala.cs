using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private float dmg = 1f;
    private int daño;

    public void SetDmg(int daño)
    {
        this.daño = daño;
    }

    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slime"))
        {
            other.GetComponent<Enemigo>().DarDmg(dmg);
            Destroy(gameObject);
        }
    }
}
