using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private GameObject personaje;

    void Start()
    {
        // Buscar el personaje clonado por su tag
        personaje = GameObject.FindGameObjectWithTag("PersonajeJugador");

        if (personaje == null)
        {
            Debug.LogError("No se encontr� ning�n objeto con el tag 'PersonajeJugador'");
        }
    }

    void Update()
    {
        if (personaje != null)
        {
            Vector3 position = transform.position;
            position.x = personaje.transform.position.x; // Sigue la posici�n en el eje X
            transform.position = position;
        }
    }
}
