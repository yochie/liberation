using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    //disabled by knockbacker
    private bool inControl;

    private Vector2 controlledDir;

    private void Start()
    {
        this.inControl = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inControl)
            this.rb.velocity = this.controlledDir * this.moveSpeed;
    }

    internal void MoveInDir(Vector2 direction)
    {
        this.controlledDir = direction;
    }

    public void SetControl(bool inControl)
    {
        this.inControl = inControl;
    }
}
