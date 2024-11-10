using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image[] vidas; // Aseg�rate de asignar esto en el Inspector.

    // M�todo para desactivar un coraz�n seg�n el �ndice de vida
    public void DesactivarVida(int index)
    {
        if (index >= 0 && index < vidas.Length && vidas[index] != null)
        {
            vidas[index].enabled = false; // Desactiva el coraz�n en la posici�n especificada
        }
        else
        {
            Debug.LogError("El �ndice de vida es inv�lido o no est� asignado en HUD.");
        }
    }

    // M�todo para activar todos los corazones al inicio del juego
    public void ActivarVida(int index)
    {
        if (index >= 0 && index < vidas.Length && vidas[index] != null)
        {
            vidas[index].enabled = true; // Activa el coraz�n en la posici�n especificada
        }
        else
        {
            
        }
    }
}
