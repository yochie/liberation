using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Mover mover;

    private Transform target;

    private void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetDir = (target.position - this.transform.position).normalized;
        this.mover.SetMovementDirection(targetDir);
    }
}
