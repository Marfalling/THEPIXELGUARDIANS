using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int da�o = 1; // Cambi� da�o a int

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto colisionado es el jugador
        if (collision.CompareTag("Player"))
        {
            // Obt�n el script FinnMovement del jugador
            FinnMovement jugador = collision.GetComponent<FinnMovement>();

            if (jugador != null)
            {
                // Llama al m�todo TomarDa�o en FinnMovement
                jugador.TomarDa�o(da�o); // Ahora esto es v�lido
            }
        }
    }
}
