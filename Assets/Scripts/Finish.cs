using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private bool isCollected = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] Sprite spriteFinish;
    
    private void Start()
    {   
        finishSound = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        var fruits = GameObject.FindGameObjectsWithTag("Cherry");
        if (fruits != null) 
        {
            int fruitsCount = fruits.Length;
            if (fruitsCount == 0) 
            {
                isCollected = true;
                ChangeSprite();
            }
        }
    }

    private void ChangeSprite() 
    {
        spriteRenderer.sprite = spriteFinish; 
        animator.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted && isCollected)
        {
            finishSound.Play();
            levelCompleted = true;
            
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
