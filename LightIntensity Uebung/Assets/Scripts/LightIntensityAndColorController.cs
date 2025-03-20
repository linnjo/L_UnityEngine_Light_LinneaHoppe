using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityAndColorController : MonoBehaviour
{
    [SerializeField] private GameObject[] pointLights;
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private float maxIntensity = 5;

    public Color startColor = Color.red;
    public Color endColor = Color.green;

    private void Start()
    {
        pointLights = GameObject.FindGameObjectsWithTag("Lightstick");
    }

    private void Update()
    {
        foreach (GameObject light in pointLights)
        {
            Light pointLight = light.GetComponent<Light>();
            pointLight.intensity = 1;

            float distance = Vector3.Distance(gameObject.transform.position, light.transform.position);
            print(distance);
            float intensity = (1 - distance / maxDistance) * maxIntensity;

            if (distance < maxDistance)
            {
                pointLight.intensity = intensity;

                float colorRatio = 1 - (distance / maxDistance);

                pointLight.color = Color.Lerp(startColor, endColor, colorRatio);
            }
            else
            {
                pointLight.intensity = 0;
                pointLight.color = startColor;
            }
        }
    }
}
