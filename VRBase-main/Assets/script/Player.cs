using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class PlayerTriggerHandler : MonoBehaviour
{
    public int playerHealth = 100; // Vida inicial del jugador
    public AudioClip collisionSound; // Sonido a reproducir cuando un enemigo atraviesa el trigger
    private AudioSource audioSource;

    public Image flashImage; // La imagen que parpadea en la pantalla
    public Color flashColor = Color.red; // Color del parpadeo
    public float flashDuration = 0.2f; // Duración del parpadeo
    private Canvas canvas; // Referencia al Canvas

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No se ha asignado un componente AudioSource.");
        }

        // Asegúrate de que la imagen comience como transparente
        if (flashImage != null)
        {
            flashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0);
        }

        // Busca el Canvas por su tag
        canvas = GameObject.FindGameObjectWithTag("canvas")?.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false); // Asegúrate de que esté inicialmente desactivado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al trigger tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            if (audioSource != null && collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            // Reduce la vida del jugador
            playerHealth -= 25;
            Debug.Log("Vida del jugador: " + playerHealth);

            // Inicia el parpadeo de la pantalla
            StartCoroutine(FlashScreen());

            // Activa el Canvas
            StartCoroutine(ActivateCanvas());

            // Verifica si la vida llegó a 0 o menos
            if (playerHealth <= 0)
            {
                GameOver();
            }

            // Destruye el objeto con el tag "Enemy"
            Destroy(other.gameObject, 0.1f); // Usa un retraso para permitir que el sonido se reproduzca
        }
    }

    private IEnumerator FlashScreen()
    {
        // Cambia el color de la imagen a color de parpadeo
        flashImage.color = flashColor;
        yield return new WaitForSeconds(flashDuration);

        // Regresa la imagen a transparente
        flashImage.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0);
    }

    private IEnumerator ActivateCanvas()
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(true); // Activa el Canvas
            yield return new WaitForSeconds(1f); // Espera 1 segundo
            canvas.gameObject.SetActive(false); // Desactiva el Canvas
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // Carga la escena de Game Over
        SceneManager.LoadScene("GameOverScene"); // Cambia "GameOverScene" por el nombre de tu escena de Game Over
    }
}