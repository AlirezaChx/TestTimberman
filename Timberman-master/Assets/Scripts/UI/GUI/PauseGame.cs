using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private GUI _gui;
    [SerializeField] private MainMenu _mainMenu;
    

    public void OnPauseButtonClicked()
    {
        _gameController.PauseTime(_gameController.currentTime);
        _pauseMenu.gameObject.SetActive(true);
        _gui.gameObject.SetActive(false);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        _pauseMenu.gameObject.SetActive(false);
        _gameController.TimePass();
        _gui.gameObject.SetActive(true);
    }

    public void GoToMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        _pauseMenu.gameObject.SetActive(false);
        _gui.gameObject.SetActive(false);
    }
    private void Update()
    {
       // ToggleMuteMusic();
    }
    

}
