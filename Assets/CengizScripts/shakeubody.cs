using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class shakeubody : MonoBehaviour
{
    public static shakeubody Instance { get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    private float timer;

    private void Awake()

    {

        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensivitat, float time)
    {

        CinemachineBasicMultiChannelPerlin diese = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        diese.m_AmplitudeGain = intensivitat;
        timer = time;
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                CinemachineBasicMultiChannelPerlin diese = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                diese.m_AmplitudeGain = 0f;

            }
        }
    }
}
