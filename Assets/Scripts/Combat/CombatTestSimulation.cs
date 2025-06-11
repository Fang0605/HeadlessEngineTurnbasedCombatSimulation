public class CombatTestSimulation
{
    private CombatLogBuilder log = new();

    public void Run()
    {
        var p1 = new Fighter("Wolf", 30, 5);
        var p2 = new Fighter("Hunter", 25, 7);

        log.Log($"Battle Start: {p1.Name} vs {p2.Name}");

        int turn = 0;
        while (!p1.IsDead && !p2.IsDead)
        {
            turn++;
            log.Log($"-- Turn {turn} --");

            if (turn % 2 == 1)
                log.Log(p1.Attack(p2));
            else
                log.Log(p2.Attack(p1));
        }

        log.Log($"Winner: {(p1.IsDead ? p2.Name : p1.Name)}");
    }

    public string GetCombatLog() => log.ToString();
}