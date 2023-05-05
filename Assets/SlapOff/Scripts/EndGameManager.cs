using System;
using BNG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject gameUIGameObject;
    
    private bool _isButtonReadyToUse;
    
    // Start is called before the first frame update
    void Start()
    {
        TurnManager.Instance.onPlayerWin.AddListener(OnPlayerWin);
        TurnManager.Instance.onPlayerLose.AddListener(OnPlayerLose);
    }

    private void OnPlayerWin()
    {
        _isButtonReadyToUse = true;
        
        gameUIGameObject.SetActive(false);
        winPanel.SetActive(true);
    }

    private void OnPlayerLose()
    {
        _isButtonReadyToUse = true;
        
        gameUIGameObject.SetActive(false);
        losePanel.SetActive(true);
    }

    private void RestartLevel()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void Update()
    {
        if (_isButtonReadyToUse)
        {
            if (InputBridge.Instance.AButton)
            {
                _isButtonReadyToUse = false;
                RestartLevel();
            }
        }
    }
}
