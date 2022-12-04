using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashReducer : MonoBehaviour
{
    [SerializeField] List<Light> lights = new List<Light>();
    [SerializeField] Toggle effectToggle; 

    float fullIntensity = 50;
    float loweredIntensity = 1.5f;

    bool isLightOn;
    bool isEffectOn;

    float timeToNextSwitch = 0;
    float onOffDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (effectToggle.isOn)
        {
            isEffectOn = true;
        }
        else
        {
            isEffectOn = false;
        }


        if (timeToNextSwitch <= Time.time)
        {
            isLightOn = !isLightOn;

            timeToNextSwitch = Time.time + onOffDelay;
        }

        if (isLightOn)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                if (isEffectOn)
                {
                    lights[i].intensity = loweredIntensity;
                }
                else
                {
                    lights[i].intensity = fullIntensity;
                }
            }
        }
        else
        {
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].intensity = 0;
            }
        }
    }
}
