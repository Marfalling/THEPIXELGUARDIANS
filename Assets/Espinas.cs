using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    public int daño = 1; // Daño que hará al personaje
    public float tiempoEntreDaños = 1.0f; // Tiempo de espera entre daños consecutivos
    private float tiempoDesdeUltimoDaño;

    private void Start()
    {
        // Inicializa el tiempo desde el último daño
        tiempoDesdeUltimoDaño = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("PersonajeJugador"))
        {
            // Comprueba si ha pasado suficiente tiempo desde el último daño
            if (Time.time >= tiempoDesdeUltimoDaño + tiempoEntreDaños)
            {
                FinnMovement jugador = collision.gameObject.GetComponent<FinnMovement>();

                if (jugador != null)
                {
                    jugador.TomarDaño(daño);
                    tiempoDesdeUltimoDaño = Time.time; // Actualiza el tiempo del último daño
                }
            }
        }
    }
}