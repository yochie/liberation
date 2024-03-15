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

    //starts at beginning of dash
    [SerializeField]
    private float dashCooldownDuration;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    //disabled by knockbacker
    private bool inControl;

    private bool dashing;
    private Vector2  dashingDirection;
    private float dashTimeRemaining;
    private float dashCooldownRemaining;

    private Vector2 moveDirection;

    private void Start()
    {
        this.inControl = true;
        this.dashingDirection = Vector2.zero;
        this.dashTimeRemaining = 0;
        this.dashing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!this.inControl)
            return;

        bool wasDashingAtPreviousFrame = this.dashing;
        if (this.dashTimeRemaining > 0)
        {
            this.rb.velocity = this.dashingDirection * this.dashSpeed;
            if (!wasDashingAtPreviousFrame)
            {
                //first dash frame
                this.dashing = true;
                this.animator.SetBool("dashing", true);
                this.dashCooldownRemaining = this.dashCooldownDuration;
            }
            else
            {
                this.dashTimeRemaining -= Time.fixedDeltaTime;
                this.dashCooldownRemaining -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if (wasDashingAtPreviousFrame)
            {
                //first frame out of dash
                this.dashing = false;
                this.animator.SetBool("dashing", false);
            }

            this.rb.velocity = this.moveDirection * this.moveSpeed;
            this.dashCooldownRemaining -= Time.fixedDeltaTime;
        }
    }

    //Note : doesn't set dashing bool since we want to track whether actual movement has started for timing purposes
    public void Dash(Vector2 direction)
    {
        if (direction.magnitude == 0 || this.dashCooldownRemaining > 0)
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
