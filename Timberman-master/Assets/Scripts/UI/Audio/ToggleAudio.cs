using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _toggleSFX;

    public void Toggle()
    {
        if (_toggleSFX)
        {
            SoundManager.Instance.ToggleSfx();
        }

        if (_toggleMusic)
        {
            SoundManager.Instance.ToggleMusic();
        }
    }
}
