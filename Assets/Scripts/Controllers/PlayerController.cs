using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float deathAnimationDuration;
    
    [SerializeField]
    private Animator gunAnimator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private BulletShooter gun;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Mover mover;

    private float facingDir;

    private Vector3 movementDirection;

    private bool dead;
    private bool paused;

    private void Start()
    {
        this.facingDir = -1;
        this.dead = true;
    }

    private void FixedUpdate()
    {
        //this.transform.position += movement * this.speed * Time.fixedDeltaTime;
        this.mover.SetMovementDirection(this.movementDirection);
    }

    private void Update()
    {
        if(!this.dead || PauseController.GameIsPaused)
        {
            this.movementDirection = Vector3.zero;
            return;
        }

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
            this.gun.Shoot();
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

    internal void Die()
    {
        this.dead = false;
        this.gun.gameObject.SetActive(false);
        this.animator.SetTrigger("die");
        this.StartCoroutine(this.WaitForDeathAnimationCoroutine());
    }

    private IEnumerator WaitForDeathAnimationCoroutine()
    {
        yield return new WaitForSeconds(this.deathAnimationDuration);
        GameController.Singleton.EndGame();
    }
}
