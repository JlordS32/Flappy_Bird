using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }

    // References
    AudioSource _soundSource;
    AudioSource _musicSource;

    void Awake()
    {
        _soundSource = GetComponent<AudioSource>();
        _musicSource = transform.GetChild(0).GetComponent<AudioSource>();   // BG Music Component must be nested under manager.

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _soundSource.PlayOneShot(clip);
    }
}
