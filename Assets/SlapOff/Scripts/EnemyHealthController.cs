public class EnemyHealthController : HealthController
{
    protected override void OnHealthDecreasedToZero()
    {
        base.OnHealthDecreasedToZero();
        TurnManager.Instance.OnPlayerWin();
    }
}
