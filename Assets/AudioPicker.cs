using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPicker : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Picker ()
    {
        int i = sounds.Length;
        source.clip = sounds[Random.Range(0,i)];
        source.pitch = Random.Range (0.9f, 1);
        Sound();
    }

    void Sound ()
    {
        source.PlayOneShot(source.clip, 0.7f);
    }

}
