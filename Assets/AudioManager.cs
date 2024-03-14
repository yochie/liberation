using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton { get; private set; }

    [SerializeField]
    private AudioSource effectsSource;

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private float effectPitchShiftRange;

    [SerializeField]
    private List<AudioClip> songList;

    private void Awake()
    {
        if (AudioManager.Singleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            AudioManager.Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        this.musicSource.loop = false;
        StartCoroutine(this.LoopMusicCoroutine(this.songList));
    }

    public void PlaySoundEffect(AudioClip soundEffect)
    {
        if (soundEffect == null)
            return;
        this.effectsSource.pitch = UnityEngine.Random.Range(1 - this.effectPitchShiftRange, 1 + this.effectPitchShiftRange);
        this.effectsSource.PlayOneShot(soundEffect);
    }

    internal void SetVolume(float value, VolumeType volumeType)
    {
        switch (volumeType)
        {
            case VolumeType.music:
                this.musicSource.volume = value;
                return;
            case VolumeType.SFX:
                this.effectsSource.volume = value;
                return;
        }
    }

    internal float GetEffectsVolume()
    {
        return this.effectsSource.volume;
    }

    internal float GetMusicVolume()
    {
        return this.musicSource.volume;
    }

    public void PlaySong(AudioClip songClip)
    {
        this.musicSource.Stop();
        this.musicSource.clip = songClip;
        this.musicSource.Play();
    }

    private IEnumerator LoopMusicCoroutine(List<AudioClip> songQueue)
    {
        while (true)
        {
            foreach (AudioClip song in songQueue)
            {
                Debug.LogFormat("Starting next song in queue : {0}", song.name);
                this.PlaySong(song);
                float timeBetweenSongs = 1f;
                yield return new WaitForSeconds(song.length + timeBetweenSongs);
            }
        }
    }
}
