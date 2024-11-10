using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject John;
    public float movementSpeed = 2.0f; // Velocidad de movimiento hacia el jugador
    private float LastShoot;
    [SerializeField] private float Health;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (John == null) return;

        // Calcular la dirección hacia el jugador
        Vector3 direction = John.transform.position - transform.position;

        // Hacer que el Grunt siempre mire hacia el jugador
        if (direction.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Moverse hacia el jugador solo si está a más de cierta distancia
        float distance = direction.magnitude;
        if (distance > 1.0f)
        {
            transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        }

        // Disparar si el jugador está en el rango de disparo
        if (distance < 5.0f && Time.time > LastShoot + 2.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }


    private void Shoot()
    {
        Vector3 direction = (transform.localScale.x == 1.0f) ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void TomarDaño(float daño)
    {
        Health -= daño;

        if (Health <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("death");
        Invoke("DestruirObjeto", 0.5f);
    }

    private void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
