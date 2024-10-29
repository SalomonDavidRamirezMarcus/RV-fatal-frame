using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class pistola : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public disparo disparo;
    public GameObject shootFX;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable.activated.AddListener(x => Disparando());
        grabInteractable.deactivated.AddListener(x => DejarDisparar());

        
    }

    public void Disparando()
    {
        disparo.Disparar();

    }
    public void DejarDisparar()
    {
        Debug.Log("noDispara");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
