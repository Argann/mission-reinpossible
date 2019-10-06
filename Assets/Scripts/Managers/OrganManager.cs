public static class OrganManager
{
    private static int hp = 10;

    public static void Reset()
    {
        hp = 999;
    }

    public static int HP {
        get => hp;
        set {
            int oldValue = value;
            hp = value;

            EventManager.OnOrganHit.Invoke(new GameEventPayload(){
                {"HitAmount", oldValue - hp}
            });
            
            if (hp <= 0)
            {
                EventManager.OnOrganDeath.Invoke(new GameEventPayload());
            }

        }
    }
}