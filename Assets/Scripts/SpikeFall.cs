using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer = 0.0f;

    [SerializeField] private float time = 5.0f;

    void Start()
    {
        rb = gameObject.transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var fruit = GameObject.Find("CherryActive");
        if (fruit == null) 
        {
            timer += Time.deltaTime;
            float seconds = timer % 60;
            if (seconds > time) 
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
