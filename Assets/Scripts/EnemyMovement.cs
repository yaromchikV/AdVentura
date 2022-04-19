using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 previousPosition;
    Vector3 lastMoveDirection;

    Vector3 prevDirection;

    private SpriteRenderer sprite;

    private void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();

        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
        prevDirection = lastMoveDirection;
    }

    private void FixedUpdate() 
    {
        if (transform.position != previousPosition) 
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;

            if (prevDirection != lastMoveDirection)
            {
                sprite.flipX = true;
            }
        }

        var direction = transform.position - previousPosition;
        var localDirection = transform.InverseTransformDirection(direction);
        previousPosition = transform.position;
    }
}
