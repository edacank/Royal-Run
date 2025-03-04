using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedupParticleSystem;
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;

    CinemachineVirtualCamera cinemachineCamera;
    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void ChangeCameraFOV(float speedAmount) 
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));

        if(speedAmount > 0)
        {
            speedupParticleSystem.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.m_Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount *  zoomSpeedModifier, minFOV, maxFOV);
       // Mathf.Lerp();
       float elapsedTime = 0f;
       while(elapsedTime < zoomDuration)
       {
        float t = elapsedTime /zoomDuration;
        elapsedTime += Time.deltaTime;
        cinemachineCamera.m_Lens.FieldOfView =  Mathf.Lerp(startFOV, targetFOV, t);
        yield return null;
       }
    }
}
