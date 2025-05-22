using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanternLight : MonoBehaviour
{
    public Vector3 LightPos;
    public float MinIntensity;
    public float MaxIntensity;
    public float FlickerSpeed;

    private void Update()
    {
        float xModifyer = Random.Range(-1, 1);
        float yModifyer = Random.Range(-1, 1);
        LightPos = new Vector3(transform.position.x + xModifyer, transform.position.y + yModifyer, transform.position.z);

        float noise = Mathf.PerlinNoise(1, Time.time * FlickerSpeed);
        float iModifyer = Mathf.Lerp(MinIntensity, MaxIntensity, noise * Time.deltaTime);
    }
}
