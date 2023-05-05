using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private HealthDisplayController healthDisplayController;

    private float _health;

    public float Health => _health;

    private void Awake()
    {
        _health = startHealth;
    }

    public void GetDamage(float damageAmount)
    {
        _health -= damageAmount;
        _health = Mathf.Clamp(_health, 0, _health);
        if (_health <= 0.0f)
        {
            OnHealthDecreasedToZero();
        }
        healthDisplayController.DisplayHealth();
    }

    protected virtual void OnHealthDecreasedToZero()
    {
        
    }
}
