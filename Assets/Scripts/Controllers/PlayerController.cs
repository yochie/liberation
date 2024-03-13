using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private Animator gunAnimator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private BulletShooter shooter;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Mover mover;

    private float facingDir;

    private Vector3 movementDirection;

    private void Start()
    {
        this.facingDir = -1;
    }

    private void FixedUpdate()
    {
        //this.transform.position += movement * this.speed * Time.fixedDeltaTime;
        this.mover.SetMovementDirection(this.movementDirection);
    }

    private void Update()
    {
        Vector3 newMovementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        this.movementDirection = newMovementDirection;

        this.animator.SetBool("running", this.movementDirection.magnitude > 0);

        //update sprite direction
        float facingDirection;
        if (newMovementDirection.x == 0)
            facingDirection = 0;
        else
            facingDirection = newMovementDirection.x > 0 ? 1 : -1;
        this.FaceDir(facingDirection);


        bool shooting = Input.GetMouseButtonDown(0);
        if (shooting)
        {
            this.gunAnimator.SetTrigger("shoot");
            this.shooter.Shoot();
        }

        bool dashing = Input.GetKeyDown("space");
        if (dashing)
        {
            this.mover.Dash(this.movementDirection);
        }
    }

    private void FaceDir(float dir)
    {
        if (dir == 0)
            return;

        if (this.facingDir != dir)
            this.spriteRenderer.flipX = !this.spriteRenderer.flipX;
        this.facingDir = dir;

    }
}
