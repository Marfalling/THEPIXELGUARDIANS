using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;

    private FinnMovement finnMovement;

    private void Start()
    {
        finnMovement = GameObject.FindGameObjectWithTag("PersonajeJugador").GetComponent<FinnMovement>();
        finnMovement.MuerteJugador += ActivarMenu; 
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
        Time.timeScale = 0; // Pausar el juego
    }
    // Start is called before the first frame update
    public void Reiniciar()
    {
        Time.timeScale = 1; // Restablecer la escala de tiempo al valor normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void MenuInicial(string nombre)
    {
        Time.timeScale = 1; // Restablecer la escala de tiempo al valor normal
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
