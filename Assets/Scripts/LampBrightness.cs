using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class LampBrightness : MonoBehaviour
{
   public Light2D lampLight;
   //FFAD66

   public ParticleSystem ps;

    //Lamp Control attributes 
   private float minLightIntensity = 0.7f;
   private float maxLightIntensity = 3f;
    private float lampFadeDuration = 3f; 




    public void decreaseIntensity()
   {
      lampLight.intensity = minLightIntensity;
   }

   /*public void changeLampColor()
   {
      lampLight.color = new Color(101, 167, 226);
   }*/

   public void decreaseRadius()
   {
      lampLight.pointLightInnerRadius = 0;
      lampLight.pointLightOuterRadius = 6.5f;
   }


   public void increaseIntensity()
   {
        //lampLight.intensity = maxLightIntensity;
        StartCoroutine(fadeLightIntensityUp());
   }

   public void increaseRadius()
   {
      lampLight.pointLightInnerRadius = 0.3f;
      lampLight.pointLightOuterRadius = 12f;
   }

   public void increaseParticles()
   {
      var psEmission = ps.emission;
      psEmission.rateOverTime = 1000;
   }

    private IEnumerator fadeLightIntensityUp()
    {
        float startIntensity = lampLight.intensity;
        float timeElapsed = 0;

        while(timeElapsed < lampFadeDuration) 
        {
            lampLight.intensity = Mathf.Lerp(startIntensity, maxLightIntensity, timeElapsed / lampFadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        lampLight.intensity = maxLightIntensity;
    }



}
