using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public UnityEvent onEnemyTurnStarted;
    public UnityEvent onEnemyTurnEnded;
    public UnityEvent onPlayerTurnStarted;
    public UnityEvent onPlayerTurnEnded;
    public UnityEvent onPlayerWin;
    public UnityEvent onPlayerLose;
    
    #region Singleton
    public static TurnManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public void OnEnemyTurnStarted()
    {
        onEnemyTurnStarted?.Invoke();
    }

    public void OnEnemyTurnEnded()
    {
        onEnemyTurnEnded?.Invoke();
    }

    public void OnPlayerTurnStarted()
    {
        onPlayerTurnStarted?.Invoke();
    }

    public void OnPlayerTurnEnded()
    {
        onPlayerTurnEnded?.Invoke();
    }

    public void OnPlayerWin()
    {
        onPlayerWin?.Invoke();
        Debug.Log("Player win");
    }

    public void OnPlayerLose()
    {
        onPlayerLose?.Invoke();
        Debug.Log("Player lose");
    }
}
