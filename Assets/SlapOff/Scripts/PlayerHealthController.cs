public class PlayerHealthController : HealthController
{
    protected override void OnHealthDecreasedToZero()
    {
        base.OnHealthDecreasedToZero();
        TurnManager.Instance.OnPlayerLose();
    }
}
