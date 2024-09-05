using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;


    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;
    // public AudioClip[] stepclips;

    public bool isMute = false;
    public float volume = .1f;
    public static SoundManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetSoundEffectVolume(volume);
        PlayMusic(global::Sounds.MUSIC);
    }

    public void SetSoundEffectVolume(float newVolume)
    {
        volume = newVolume;
        soundEffect.volume = volume;
    }
    public void SetMusicVolume(float newVolume)
    {
        volume = newVolume;
        soundMusic.volume = volume;
    }

    /*public void PlayStep()
    {
        AudioClip clip = GetRandomClip();
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }

    }*/

    /*private AudioClip GetRandomClip()
    {
        return stepclips[UnityEngine.Random.Range(0, stepclips.Length)];
    }
*/
    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Sound Couldnt be loaded");
        }

    }
    public void Play(Sounds sound)
    {
        if (isMute)
            return;


        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Sound Couldnt be loaded");
        }
    }



    public void Mute(bool status)
    {
        isMute = status;
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        if (sound == global::Sounds.PLAYER_MOVE)
        {
            SoundType item = Sounds[UnityEngine.Random.Range(3, 6)];
            return item.soundClip;
        }

        else
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);

            if (item != null)
                return item.soundClip;
            return null;
        }
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    BUTTON_CLICK,
    PLAYER_MOVE,
    PLAYER_DEATH,
    ENEMY_DEATH,
    MUSIC,
    PAIN,
    PLAYER_WON,
    KEY_SOUND,

}
