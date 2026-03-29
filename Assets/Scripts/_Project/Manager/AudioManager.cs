using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance => _instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;
    [SerializeField] private AudioClip _shootClip;
    [SerializeField] private AudioClip _deathClip;

    public AudioClip ShootClip => _shootClip;
    public AudioClip DeathClip => _deathClip;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayEffectClip(AudioClip clip)
    {
        if (clip != null)
        {
            _effectSource.PlayOneShot(clip);
        }
    }

    public void PlayDeathClip()
    {
        PlayEffectClip(DeathClip);
    }
    public void StopMusic()
    {
        if (_musicSource != null)
        {
            _musicSource.Stop();
        }
    }
}
