using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;
    Light myLight;
    float defaultAngle;
    float defaultIntensity;
    private void Start()
    {
        myLight = GetComponent<Light>();
        defaultAngle = myLight.spotAngle;
        defaultIntensity = myLight.intensity;

    }

    private void Update()
    {
        DecreasingLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreasingLightAngle()
    {
        if (myLight.spotAngle>minimumAngle)
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
    public void Charge()
    {
        myLight.spotAngle = defaultAngle;
        myLight.intensity = defaultIntensity;
    }
}
