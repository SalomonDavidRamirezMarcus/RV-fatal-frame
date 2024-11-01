using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    public XRGrabInteractable grabInteract; // Referencia al componente XRGrabInteractable
    public GameObject xrOrigin; // Referencia al XR Origin (jugador)
    public float teleportDistance = 1.0f; // Distancia de teletransporte (1 metro por defecto)

    private void Start()
    {
        // Agrega listeners para los eventos de interacci�n
        grabInteract.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDestroy()
    {
        // Elimina los listeners para evitar referencias nulas
        grabInteract.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Calcula la nueva posici�n un metro hacia adelante en la direcci�n en la que el XR Origin est� mirando
        Vector3 forwardDirection = xrOrigin.transform.forward;
        Vector3 newPosition = xrOrigin.transform.position + forwardDirection.normalized * teleportDistance;

        // Mueve el XR Origin a la nueva posici�n
        xrOrigin.transform.position = newPosition;

    }
}

