using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private CinemachineBasicMultiChannelPerlin cinemachinePerlin;
    public float shakeIntensity = 5f;
    public float shakeDuration = 0.5f;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachinePerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera()
    {
        cinemachinePerlin.m_AmplitudeGain = shakeIntensity;
        shakeTimer = shakeDuration;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                cinemachinePerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}