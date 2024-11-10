using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    public int da�o = 1; // Da�o que har� al personaje
    public float tiempoEntreDa�os = 1.0f; // Tiempo de espera entre da�os consecutivos
    private float tiempoDesdeUltimoDa�o;

    private void Start()
    {
        // Inicializa el tiempo desde el �ltimo da�o
        tiempoDesdeUltimoDa�o = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("PersonajeJugador"))
        {
            // Comprueba si ha pasado suficiente tiempo desde el �ltimo da�o
            if (Time.time >= tiempoDesdeUltimoDa�o + tiempoEntreDa�os)
            {
                FinnMovement jugador = collision.gameObject.GetComponent<FinnMovement>();

                if (jugador != null)
                {
                    jugador.TomarDa�o(da�o);
                    tiempoDesdeUltimoDa�o = Time.time; // Actualiza el tiempo del �ltimo da�o
                }
            }
        }
    }
}