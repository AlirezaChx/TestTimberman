using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TrunkManager _trunkManager;
    [SerializeField] private GUI _gui;
    [SerializeField] private GameOver _gameOver;

    private float totalTime = 5.0f;
    public float currentTime;
    private int score = 0;
    private int bestScore = 0;
    public int GetScore()
    {
        return score;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    private void Start()
    {
        currentTime = totalTime;
        _gui.SetScore(score);
    }

    private void Update()
    {
        TimePass();
    }

    void GameOver()
    {
        _playerController.PlayerDie();
        Debug.Log("YouLose");
        if (score>bestScore)
        {
            bestScore = score;
        }
        
        _gameOver.Show();
    }
    public void TimePass()
    {
        currentTime -= Time.deltaTime;
        _gui.SetBarProgress(currentTime / totalTime);
        if (currentTime <= 0 && _playerController.isAlive)
        { 
            GameOver();
        }
    }

    public float PauseTime(float currentTime)
    {
        Time.timeScale = 0;
        this.currentTime = currentTime;

        return currentTime;
    }
   
    public void OnTap(string direction)
    {
        if (_playerController.isAlive == false)
        {
            return;
        }
        _playerController.ChangeDirection(direction);
        _playerController.PlayCutAnimation();
        if (direction == _trunkManager.GetFirstTrunkDirection())
        {
            StartCoroutine(CutDownTree(direction));
            score++;
            currentTime += 0.25f;
            _gui.SetScore(score);
        }
        else
        {
            StartCoroutine(CutDownTree(direction));
            score++;
            currentTime += 0.25f;
            _gui.SetScore(score);
        }

        if (direction == _trunkManager.GetFirstTrunkDirection())
        {
            GameOver();
        }
    }

    IEnumerator CutDownTree(string direction)
    {
        _trunkManager.CutTrunk(direction);
        Debug.Log(direction);
        yield return new WaitForSeconds(0.25f);
    }

    public void ReStartGame()
    {
        score = 0;
        _gui.SetScore(score);
        
        currentTime = totalTime;
        _gui.SetBarProgress(0.5f);
        
        _playerController.Respawn();
        _trunkManager.ResetTrunk();
        
        _gui.gameObject.SetActive(true);
        _gameOver.gameObject.SetActive(false); }
}
