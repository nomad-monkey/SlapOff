using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private HealthController enemyHealthController;

    private SlapManager _slapManagerInstance;

    private void Start()
    {
        _slapManagerInstance = SlapManager.Instance;
        _slapManagerInstance.OnSlapEvent.AddListener(Attack);
    }

    private void Attack()
    {
        var damageAmount = _slapManagerInstance.Score;
        enemyHealthController.GetDamage(damageAmount);
    }
}
