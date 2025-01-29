using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
	public Transform controladorDisparo;
	public float distanciaLinea;
	public LayerMask capaJugador;
	public bool jugadorEnRango;

	public GameObject balaEnemigo;
	public float tiempoEntreDisparos = 0.3f;
	public float tiempoUltimoDisparo = 0;
	public float tiempoEsperaDisparo = 0.3f;
	void Update()
	{
		jugadorEnRango = Physics2D.Linecast(controladorDisparo.position, transform.right * distanciaLinea, capaJugador);
		if (jugadorEnRango)
		{
			if (Time.time > tiempoEntreDisparos + tiempoUltimoDisparo)
			{
				tiempoUltimoDisparo = Time.time;
				Invoke(nameof(Disparar), tiempoEsperaDisparo);
			}
		}
	}

	private void Disparar()
	{
		Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
	}
}
