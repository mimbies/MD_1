using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LampBrightness : MonoBehaviour
{
   public Light2D lampLight;
   //FFAD66


   public void decreaseIntensity()
   {
      lampLight.intensity = 0.7f;
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
      lampLight.intensity = 3;
   }
}
