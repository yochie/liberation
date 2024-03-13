using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float dashSpeed;

    [SerializeField]
    private float dashDuration;

    [SerializeField]
    private Rigidbody2D rb;

    //disabled by knockbacker
    private bool inControl;

    private Vector2  dashingDirection;
    private float dashTimeRemaining;

    private Vector2 moveDirection;

    private void Start()
    {
        this.inControl = true;
        this.dashingDirection = Vector2.zero;
        this.dashTimeRemaining = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.inControl)
        {
            if (dashTimeRemaining > 0)
            {                
                this.rb.velocity = this.dashingDirection * this.dashSpeed;
                this.dashTimeRemaining -= Time.fixedDeltaTime;
            }
            else
            {
                this.rb.velocity = this.moveDirection * this.moveSpeed;
            }            
        }
    }

    public void Dash(Vector2 direction)
    {
        if (direction.magnitude == 0)
            return;

        this.dashingDirection = direction;
        this.dashTimeRemaining = this.dashDuration;
    }

    internal void SetMovementDirection(Vector2 direction)
    {
        this.moveDirection = direction;
    }

    public void SetControl(bool inControl)
    {
        this.inControl = inControl;
    }
}
