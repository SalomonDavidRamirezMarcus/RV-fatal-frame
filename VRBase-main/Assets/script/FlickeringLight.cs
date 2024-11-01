using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light horrorLight;      // Luz que parpadeará
    public float minIntensity = 0f; // Intensidad mínima durante el parpadeo
    public float maxIntensity = 1f; // Intensidad máxima durante el parpadeo
    public float flickerSpeed = 0.1f; // Velocidad del parpadeo
    public bool randomFlicker = true; // Define si el parpadeo será aleatorio

    void Start()
    {
        // Inicia el parpadeo de la luz
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            // Si es parpadeo aleatorio, cambia la intensidad aleatoriamente
            if (randomFlicker)
            {
                horrorLight.intensity = Random.Range(minIntensity, maxIntensity);
                yield return new WaitForSeconds(Random.Range(flickerSpeed, flickerSpeed * 2));
            }
            else
            {
                // Parpadeo con una intensidad fija entre apagado y encendido
                horrorLight.enabled = !horrorLight.enabled;
                yield return new WaitForSeconds(flickerSpeed);
            }
        }
    }
}
