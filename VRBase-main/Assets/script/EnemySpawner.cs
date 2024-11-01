using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo que se generará
    public float spawnInterval = 3f; // Intervalo de tiempo en segundos entre cada aparición
    public Transform spawnPoint; // Punto de generación del enemigo
    public float spawnRange = 5f; // Rango aleatorio para el spawn alrededor del punto
    public Transform player; // Referencia al jugador

    void Start()
    {
        // Inicia el proceso de generación de enemigos
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // Bucle infinito para generar enemigos constantemente
        {
            // Genera un enemigo en una posición aleatoria dentro del rango alrededor del spawnPoint
            Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRange;
            spawnPosition.y = spawnPoint.position.y; // Asegura que la altura sea la misma

            // Crea el enemigo
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Asigna la referencia del jugador al nuevo enemigo
            EnemyFollow enemyFollow = newEnemy.GetComponent<EnemyFollow>();
            if (enemyFollow != null)
            {
                enemyFollow.player = player;
            }

            yield return new WaitForSeconds(spawnInterval); // Espera el intervalo antes de la siguiente generación
        }
    }

}
