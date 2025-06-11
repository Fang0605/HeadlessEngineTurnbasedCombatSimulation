public class TurnBasedEngineInstance
{
    private Fighter fighter1;
    private Fighter fighter2;

    public TurnBasedEngineInstance(Fighter fighter1, Fighter fighter2)
    {
        this.fighter1 = fighter1;
        this.fighter2 = fighter2;
    }

    public CombatLog Simulate()
    {
        var log = new CombatLog();

        // Example simulation logic
        CombatLog.Write($"{fighter1.Name} attacks {fighter2.Name}");
        CombatLog.Write($"{fighter2.Name} attacks back");
        // Determine winner, log turns, etc.
        CombatLog.Write("Simulation complete");

        return log;
    }
}