using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo, ajustada para ser más lenta

    void Update()
    {
        if (player != null) // Asegura que el jugador esté asignado
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Movimiento constante hacia el jugador
            transform.position += direction * speed * Time.deltaTime;
        }
    }
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
}
