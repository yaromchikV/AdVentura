using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;

    private bool isCollected = false;
    
    private Animator animator;

    private void Start()
    {   
        finishSound = GetComponent<AudioSource>();
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
                animator.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted && isCollected)
        {
            finishSound.Play();
            levelCompleted = true;

            SaveEndGamePrefs();
            Invoke("CompleteGame", 2f);
        }
    }

    private void CompleteGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SaveEndGamePrefs()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.Save();
    }
}
