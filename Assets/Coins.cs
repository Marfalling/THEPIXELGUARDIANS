using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{


    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntaje puntaje;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PersonajeJugador")
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(this.gameObject);
        }
    }
}
