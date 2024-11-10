using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Personajes> personajes;
    public GameObject personajeActual;
    public GameObject hudPrefab; // Prefab del HUD
    private HUD hud; // Referencia al HUD instanciado
    private int Health; // Almacena la salud aqu�

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("GameManager inicializado correctamente.");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        VerificarInstanciaHUD();
    }

    private void OnLevelWasLoaded(int level)
    {
        VerificarInstanciaHUD();
    }

    private void VerificarInstanciaHUD()
    {
        // Verifica que la escena actual sea "SampleScene" y que el HUD no est� ya instanciado
        if (SceneManager.GetActiveScene().name == "SampleScene" && hud == null)
        {
            if (hudPrefab != null)
            {
                GameObject hudObject = Instantiate(hudPrefab);
                hud = hudObject.GetComponent<HUD>();
                if (hud == null)
                {
                    Debug.LogError("HUD no encontrado en el prefab.");
                }
                else
                {
                    // Inicializa el HUD con la salud actual aqu�
                    InicializarVidas(Health); // Aseg�rate de que Health est� definido o sea accesible
                }
            }
            else
            {
                
            }
        }
        else if (SceneManager.GetActiveScene().name != "SampleScene" && hud != null)
        {
            // Si sales de SampleScene, destruye el HUD
            Destroy(hud.gameObject);
            hud = null;
        }
    }


    // M�todo para inicializar el HUD con la cantidad de vidas
    public void InicializarVidas(int cantidadVidas)
    {
        if (hud != null)
        {
            for (int i = 0; i < cantidadVidas; i++)
            {
                hud.ActivarVida(i); // Activa todos los corazones al inicio
            }
        }
        else
        {
            
        }
    }

    // M�todo para actualizar el HUD cuando se pierde vida
    public void ActualizarHUD(int saludActual)
    {
        if (hud != null)
        {
            if (saludActual >= 0 && saludActual < hud.vidas.Length)
            {
                hud.DesactivarVida(saludActual); // Desactiva el coraz�n correspondiente a la vida actual
            }
        }
        else
        {
            
        }
    }
    public void TomarDa�o(int da�o)
    {
        Health -= da�o; // Disminuye la salud
        ActualizarHUD(Health); // Actualiza el HUD con la nueva salud
    }
}
