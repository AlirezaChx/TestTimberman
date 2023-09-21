using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private GameController _gameController;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void OnPlay()
    {
        _gameController.ReStartGame();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnExit()
    {
        Application.Quit();
        Debug.Log("App Closed!");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOShakeScale(0.1f, new Vector3(0.2f,0.2f,0.2f), 1, 45f);
    }
}
