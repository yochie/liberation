using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlasher : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private float durationSeconds;

    [SerializeField]
    private Color flashColor;

    [SerializeField]
    private AnimationCurve curve;

    private Color baseColor;

    private void Start()
    {
        this.baseColor = this.sprite.color;
    }

    internal void Trigger()
    {
        this.StartCoroutine(this.FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {

        this.sprite.color = this.flashColor;
        float ellapsedSeconds = 0;
        while (ellapsedSeconds < this.durationSeconds)
        {
            float curveEval = this.curve.Evaluate(ellapsedSeconds / durationSeconds);
            this.sprite.color = Color.Lerp(this.flashColor, this.baseColor, curveEval);
            ellapsedSeconds += Time.deltaTime;
            yield return null;
        }
        this.sprite.color = this.baseColor;
    }
}
