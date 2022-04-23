using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private bool isTrigger = false;

    private float timer = 0.0f;
    [SerializeField] private float time;
    [SerializeField] private float timeAfterStop = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isTrigger)
        {
            timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds > time)
            {
                animator.enabled = false;   
                if (timer - time > timeAfterStop)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
