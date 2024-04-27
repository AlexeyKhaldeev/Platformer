using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAuduoController : MonoBehaviour
{
    [SerializeField] private HeroInputController _input; 
    [SerializeField] private AudioSource _stepAudio; 
    
    void Update()
    {
        if (Mathf.Abs(_input.HAxisValue) > 0.0f && !_stepAudio.isPlaying)
        {
            _stepAudio.Play();
        }

        else if (_input.HAxisValue ==0.0f)
        {
            _stepAudio.Pause();
        }
    }
}
