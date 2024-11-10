using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public int da�o = 1; // Da�o que har� al personaje
    public float tiempoEntreDa�os = 1.0f; // Tiempo de espera entre da�os consecutivos
    private float tiempoDesdeUltimoDa�o;
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoDesdeUltimoDa�o = 0f;
    }

    private void FixedUpdate()
    {
        // Raycast para verificar si hay suelo
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        // Movimiento del personaje
        if (moviendoDerecha)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y); // Mover a la derecha
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y); // Mover a la izquierda
        }

        // Si no hay suelo, girar
        if (informacionSuelo.collider == null)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); // Girar 180 grados
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
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
