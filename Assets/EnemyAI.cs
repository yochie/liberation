using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Mover mover;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetDir = (target.position - this.transform.position).normalized;
        this.mover.MoveInDir(targetDir);
    }
}
