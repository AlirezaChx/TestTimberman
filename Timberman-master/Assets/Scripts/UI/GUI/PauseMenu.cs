using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _deafault, _pressed;

    private void Start()
    {
        _image.sprite = _deafault;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.transform.DOShakeScale(0.1f, new Vector3(0.2f,0.2f,0.2f), 1, 45f);
        _image.sprite = _image.sprite == _deafault ? _pressed : _deafault;
    }
}
