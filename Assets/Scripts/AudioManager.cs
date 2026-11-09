using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public struct SoundEffect
    {
        public string eventName;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;
    }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundEffect[] soundEffects;

    private void OnEnable()
    {
        // Subscribe to global game events
        GameEvents.OnSemicolonPickup += PlayPickupSound;
        GameEvents.OnSemicolonPlace += PlayPlaceSound;
    }

    private void OnDisable()
    {
        GameEvents.OnSemicolonPickup -= PlayPickupSound;
        GameEvents.OnSemicolonPlace -= PlayPlaceSound;
    }

    private void PlayPickupSound()
    {
        PlayClip("PickupSound");
    }

    private void PlayPlaceSound()
    {
        PlayClip("PlaceSound");
    }

    private void PlayClip(string name)
    {
        foreach (var sound in soundEffects)
        {
            if (sound.eventName == name && sound.clip != null)
            {
                audioSource.PlayOneShot(sound.clip, sound.volume);
                return;
            }
        }
    }
}
