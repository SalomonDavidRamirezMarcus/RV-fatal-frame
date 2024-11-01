using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float rotationSpeed = 5f; // Velocidad de rotación, ajustable desde el Inspector

    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("No se ha asignado el objeto jugador en el Inspector.");
        }
        else
        {
            Debug.Log("Enemigo está siguiendo a: " + player.name);
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Rotación para mirar al jugador
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // Movimiento constante hacia el jugador
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}