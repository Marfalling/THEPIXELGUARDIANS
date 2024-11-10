using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image[] vidas; // Asegúrate de asignar esto en el Inspector.

    // Método para desactivar un corazón según el índice de vida
    public void DesactivarVida(int index)
    {
        if (index >= 0 && index < vidas.Length && vidas[index] != null)
        {
            vidas[index].enabled = false; // Desactiva el corazón en la posición especificada
        }
        else
        {
            Debug.LogError("El índice de vida es inválido o no está asignado en HUD.");
        }
    }

    // Método para activar todos los corazones al inicio del juego
    public void ActivarVida(int index)
    {
        if (index >= 0 && index < vidas.Length && vidas[index] != null)
        {
            vidas[index].enabled = true; // Activa el corazón en la posición especificada
        }
        else
        {
            
        }
    }
}
