using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistola : MonoBehaviour
{

    public XRGrabInteractable grabInteract;

    public Disparo disparo;

    public GameObject shootFx;


    private void Start()
    {
        grabInteract.activated.AddListener(x => Disparando());
        grabInteract.deactivated.AddListener(x => DejarDisparar());
    }
    public void DejarDisparar()
    {
        Debug.Log("Disparandon't");
    }
    public void Disparando()
    {
        disparo.Disparar();
    }
}
