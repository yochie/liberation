using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;

    private CinemachineBasicMultiChannelPerlin noise;
    private void Start()
    {
        this.noise = this.vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    internal void Trigger(float durationSeconds, float amplitude, float frequency)
    {

        this.StartCoroutine(ShakeCoroutine(durationSeconds, amplitude, frequency));        
    }

    private IEnumerator ShakeCoroutine(float durationSeconds, float amplitude, float frequency)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(durationSeconds);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}
