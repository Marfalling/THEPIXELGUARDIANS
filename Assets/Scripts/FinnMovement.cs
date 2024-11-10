using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinnMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    [SerializeField] private int Health;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    public event EventHandler MuerteJugador; // Evento público para el Game Over

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        // Inicializa el HUD con la salud actual
        GameManager.Instance.InicializarVidas(Health);
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void TomarDaño(int daño)
    {
        Health -= daño;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActualizarHUD(Health);
        }
        else
        {
            Debug.LogError("GameManager o HUD no inicializado correctamente.");
        }

        if (Health <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Animator.SetTrigger("death"); // Activa la animación de muerte
        float duracionAnimacion = Animator.GetCurrentAnimatorStateInfo(0).length; // Duración de la animación de muerte
        float tiempoExtra = 0.5f; // Tiempo extra que quieres agregar (en segundos)

        Invoke("NotificarMuerte", duracionAnimacion + tiempoExtra); // Llama a NotificarMuerte después de que termine la animación y un poco más
    }

    private void NotificarMuerte()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty); // Activa el evento de muerte
        Destroy(gameObject); // Destruye el objeto si es necesario
    }
}
