using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedEngine : MonoBehaviour
{
    private List<CombatEntity> entities = new List<CombatEntity>();
    private int currentTurnIndex = 0;
    private int turnIndex = 0;

    public static void RunCombatAndLog(Fighter f1, Fighter f2)
    {
        var entity1 = new CombatEntity(f1.Name, f1.HP, f1.ATK);
        var entity2 = new CombatEntity(f2.Name, f2.HP, f2.ATK);

        int turn = 0;
        while (entity1.IsAlive && entity2.IsAlive)
        {
            if (turn % 2 == 0)
            {
                entity1.Attack(entity2, turn);
            }
            else
            {
                entity2.Attack(entity1, turn);
            }
            turn++;
        }

        CombatLog.Write("Battle Over!");
    }

    void Start()
    {
        Debug.Log("Turn-Based Engine Started.");

        entities.Add(new CombatEntity("Werewolf", 100, 15));
        entities.Add(new CombatEntity("Hunter", 80, 20));

        CombatLog.Init("wolf_sim");
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (!IsBattleOver())
        {
            yield return new WaitForSeconds(1f);

            var attacker = entities[currentTurnIndex];
            var target = entities[(currentTurnIndex + 1) % entities.Count];

            if (attacker.IsAlive)
            {
                attacker.Attack(target, turnIndex);
            }
            turnIndex++;
            currentTurnIndex = (currentTurnIndex + 1) % entities.Count;
        }

        Debug.Log("Battle Over!");
        Application.Quit(0);
    }

    private bool IsBattleOver()
    {
        int alive = 0;
        foreach (var e in entities)
            if (e.IsAlive) alive++;

        return alive <= 1;
    }
}
