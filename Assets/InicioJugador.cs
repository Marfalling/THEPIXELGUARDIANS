using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{

 
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");

        // Clonar el personaje seleccionado
        GameObject nuevoPersonaje = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);

        // Guardar el personaje clonado en el GameManager para usarlo en la nueva escena
        GameManager.Instance.personajeActual = nuevoPersonaje;
        nuevoPersonaje.tag = "PersonajeJugador";
      
    }
}
