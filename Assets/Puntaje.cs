using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "SCORE: 0"; // Inicializa el texto con "SCORE: 0"
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        textMesh.text = "SCORE: " + puntos.ToString("0"); // Actualiza el texto con "SCORE:" seguido del puntaje
    }
}
