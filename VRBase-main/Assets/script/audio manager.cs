using UnityEngine;
using System.Collections;

public class HorrorAudioManager : MonoBehaviour
{
    [Header("Sonidos de Pisadas")]
    public AudioClip[] footstepSounds;
    public float minFootstepInterval = 3f;
    public float maxFootstepInterval = 8f;

    [Header("Sonidos de Rasguños")]
    public AudioClip[] scratchSounds;
    public float minScratchInterval = 5f;
    public float maxScratchInterval = 15f;

    [Header("Configuración de Audio")]
    [Range(0f, 1f)]
    public float footstepVolume = 0.6f;
    [Range(0f, 1f)]
    public float scratchVolume = 0.7f;

    // Fuentes de audio separadas para cada tipo de sonido
    private AudioSource footstepSource;
    private AudioSource scratchSource;

    private void Start()
    {
        // Crear y configurar las fuentes de audio
        footstepSource = gameObject.AddComponent<AudioSource>();
        scratchSource = gameObject.AddComponent<AudioSource>();

        // Configurar las propiedades de las fuentes de audio
        ConfigureAudioSource(footstepSource, footstepVolume, true);
        ConfigureAudioSource(scratchSource, scratchVolume, true);

        // Iniciar las corutinas para reproducir sonidos
        StartCoroutine(PlayRandomFootsteps());
        StartCoroutine(PlayRandomScratches());
    }

    private void ConfigureAudioSource(AudioSource source, float volume, bool spatialize)
    {
        source.spatialize = spatialize;
        source.volume = volume;
        source.playOnAwake = false;
        source.loop = false;
        source.spatialBlend = 1f; // Audio completamente 3D
        source.minDistance = 1f;
        source.maxDistance = 15f;
        source.rolloffMode = AudioRolloffMode.Linear;
    }

    private IEnumerator PlayRandomFootsteps()
    {
        while (true)
        {
            // Esperar un intervalo aleatorio
            float interval = Random.Range(minFootstepInterval, maxFootstepInterval);
            yield return new WaitForSeconds(interval);

            if (footstepSounds.Length > 0)
            {
                // Seleccionar un sonido aleatorio de pisada
                AudioClip randomSound = footstepSounds[Random.Range(0, footstepSounds.Length)];

                // Posición aleatoria alrededor del jugador
                Vector3 randomPosition = GetRandomPositionAround(transform.position, 5f);
                footstepSource.transform.position = randomPosition;

                // Reproducir el sonido
                footstepSource.clip = randomSound;
                footstepSource.Play();
            }
        }
    }

    private IEnumerator PlayRandomScratches()
    {
        while (true)
        {
            // Esperar un intervalo aleatorio
            float interval = Random.Range(minScratchInterval, maxScratchInterval);
            yield return new WaitForSeconds(interval);

            if (scratchSounds.Length > 0)
            {
                // Seleccionar un sonido aleatorio de rasguño
                AudioClip randomSound = scratchSounds[Random.Range(0, scratchSounds.Length)];

                // Posición aleatoria alrededor del jugador
                Vector3 randomPosition = GetRandomPositionAround(transform.position, 8f);
                scratchSource.transform.position = randomPosition;

                // Reproducir el sonido
                scratchSource.clip = randomSound;
                scratchSource.Play();
            }
        }
    }

    private Vector3 GetRandomPositionAround(Vector3 center, float radius)
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        return new Vector3(center.x + randomCircle.x, center.y, center.z + randomCircle.y);
    }

    // Método opcional para ajustar los volúmenes durante el juego
    public void AdjustVolumes(float newFootstepVolume, float newScratchVolume)
    {
        footstepSource.volume = newFootstepVolume;
        scratchSource.volume = newScratchVolume;
    }
}