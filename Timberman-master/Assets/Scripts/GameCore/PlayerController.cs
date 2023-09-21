using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite tombstone;
    [SerializeField] private Sprite timberman;
    [SerializeField] private AudioClip _cutClip;
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private ParticleSystem deathEffect;
    private PauseGame _pauseGame;
    private Animator _animator;
    private AudioSource _audioSource;
    public bool isAlive = true;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //deathEffect = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        //tombstone = GetComponent<Sprite>();
    }

    public void ChangeDirection(string direction)
    {
        if (!isAlive)
        {
            return;
        }
        if (direction == "LEFT")
        {
            var localPosition = gameObject.transform.localPosition;
            localPosition = new Vector3(-2.11f, localPosition.y,
                localPosition.z);
            gameObject.transform.localPosition = localPosition;

            gameObject.transform.rotation = Quaternion.AngleAxis(0,Vector3.up);
        }
        else
        {
            var localPosition = gameObject.transform.localPosition;
            localPosition = new Vector3(2.48f , localPosition.y,
                localPosition.z);
            gameObject.transform.localPosition = localPosition;

            gameObject.transform.rotation = Quaternion.AngleAxis(180,Vector3.up);
        }
    }


    public void PlayCutAnimation()
    {
        _animator.Play("cutAnimation");
        SoundManager.Instance.PlaySound(_cutClip);
    }

    public void PlayerDie()
    {
        GetComponent<SpriteRenderer>().sprite = tombstone;
        SoundManager.Instance.PlaySound(_deathClip);
        _animator.enabled = false;
        deathEffect.Play();
        isAlive = false;
    }

    public void Respawn()
    {
        GetComponent<SpriteRenderer>().sprite = timberman;
        _animator.enabled = true;
        isAlive = true;
    }
}
