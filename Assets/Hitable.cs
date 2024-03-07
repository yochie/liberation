using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{

    [SerializeField]
    private float maxHP;

    [SerializeField]
    private ScreenShaker screenShaker;

    [SerializeField]
    private bool shakeScreenWhenHit;

    [SerializeField]
    private float shakeDurationSeconds;

    [SerializeField]
    private float shakeAmplitude;

    [SerializeField]
    private float shakeFrequency;

    [SerializeField]
    private SpriteFlasher spriteFlasher;

    [SerializeField]
    private Knockbacker knockbacker;

    [SerializeField]
    private float kbDurationSeconds;

    [SerializeField]
    private bool isPlayer;

    private float currentHP;

    private bool canBeHit;

    private void Start()
    {
        this.currentHP = this.maxHP;
        this.canBeHit = true;
    }

    public void TakeHit(float damage, Vector2 hitFromPos)
    {
        Debug.Log("takehit");

        if (!this.canBeHit)
            return;

        this.currentHP = Mathf.Clamp(this.currentHP - damage, 0, this.maxHP);

        if (this.spriteFlasher != null)
            this.spriteFlasher.Trigger();

        if (this.knockbacker != null)
            this.knockbacker.Trigger(hitFromPos, this.kbDurationSeconds);

        if(this.screenShaker != null)
            this.screenShaker.Trigger(this.shakeDurationSeconds, this.shakeAmplitude, this.shakeFrequency);

        if(this.currentHP <= 0)
        {
            this.canBeHit = false;
            this.StartCoroutine(DieCoroutine());
        }
    }

    private IEnumerator DieCoroutine()
    {

        Debug.Log("gie");
        float despawnDelay = 1f;
        yield return new WaitForSeconds(despawnDelay);
        if (this.isPlayer)
        {
            GameController.Singleton.EndGame();
        } else
        {
            //TODO: fade out before destruction
            Destroy(this.gameObject);
        }
    }

    internal float GetMaxHP()
    {
        return this.maxHP;
    }

    internal float GetCurrentHP()
    {
        return this.currentHP;
    }
}
