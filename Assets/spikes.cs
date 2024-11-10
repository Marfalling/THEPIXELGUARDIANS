using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int daño = 1; // Cambié daño a int

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto colisionado es el jugador
        if (collision.CompareTag("Player"))
        {
            // Obtén el script FinnMovement del jugador
            FinnMovement jugador = collision.GetComponent<FinnMovement>();

            if (jugador != null)
            {
                // Llama al método TomarDaño en FinnMovement
                jugador.TomarDaño(daño); // Ahora esto es válido
            }
        }
    }
}
