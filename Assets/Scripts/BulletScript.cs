using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GruntScript grunt = collision.GetComponent<GruntScript>();
        FinnMovement finnMovement = collision.GetComponent<FinnMovement>();

        if (grunt != null)
        {
            grunt.TomarDa�o(1);  // Inflige da�o al Grunt
        }

        if (finnMovement != null)
        {
            finnMovement.TomarDa�o(1);  // Inflige da�o a Finn
        }

        DestroyBullet();  // Destruye la bala al colisionar
    }
}
