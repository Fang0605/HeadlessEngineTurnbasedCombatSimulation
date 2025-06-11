using UnityEngine;

public class Fighter
{
    public string Name;
    public int HP;
    public int ATK;
    public bool IsDead => HP <= 0;

    public Fighter(string name, int hp, int atk)
    {
        Name = name;
        HP = hp;
        ATK = atk;
    }

    public string Attack(Fighter target)
    {
        target.HP -= ATK;
        return $"{Name} hits {target.Name} for {ATK} damage. {target.Name} HP: {Mathf.Max(0, target.HP)}";
    }
}