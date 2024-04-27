using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _tracks;
    [SerializeField] private AudioSource _source;
    
    
    void Awake()
    {
        PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        _source.clip = _tracks[Random.Range(0, _tracks.Length)];
        _source.Play();
        Invoke("PlayNextTrack", _source.clip.length);

    }

    
}
