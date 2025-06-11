using UnityEngine;

public class Fighter
{
    public string Name;
    public int HP;
    public int ATK;
    public bool IsDead => HP <= 0;

    public Fighter(FighterData data)
    {
        Name = data.FighterName.Value;
        HP = data.MaxHP.Value;
        ATK = data.ATK.Value;
    }

    public Fighter(string name, int hP, int aTK)
    {
        Name = name;
        HP = hP;
        ATK = aTK;
    }

    public string Attack(Fighter target)
    {
        target.HP -= ATK;
        return $"{Name} hits {target.Name} for {ATK} damage. {target.Name} HP: {Mathf.Max(0, target.HP)}";
    }
}