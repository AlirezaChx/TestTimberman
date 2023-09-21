using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private TextMeshProUGUI bestScoreTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;

    private void Start()
    {
        
    }

    public void OnReplay()
    {
        gameController.ReStartGame();
        Hide();
    }

    public void Show()
    {
        scoreTxt.text = gameController.GetScore()+"";
        bestScoreTxt.text = gameController.GetBestScore()+"";
        
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
