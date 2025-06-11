using UnityEngine;

public class CombatEntity
{
    public string Name;
    public int Health;
    public int AttackPower;

    public bool IsAlive => Health > 0;

    public CombatEntity(string name, int hp, int atk)
    {
        Name = name;
        Health = hp;
        AttackPower = atk;
    }

    public void Attack(CombatEntity target, int turnIndex)
    {
        if (!IsAlive || !target.IsAlive) return;

        target.Health -= AttackPower;
        CombatLog.Write($"{Name} attacks {target.Name} for {AttackPower} damage. {target.Name} HP: {target.Health}");
        CombatLog.Write($"Turn {turnIndex} - {Name} attacked {target.Name} for {AttackPower} damage.");

    }
}
