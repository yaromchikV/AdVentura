using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private float jumpForce;
    [SerializeField] private float deathTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);


            var anim = gameObject.GetComponent<Animator>();
            anim.SetTrigger("death");

            var collider = gameObject.GetComponent<BoxCollider2D>();
            collider.enabled = false;

            var moving = GetComponent<WaypointFollower>();
            moving.enabled = false;

            deathSoundEffect.Play();

            Invoke("DestroyObject", deathTime);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);  
    }

}
