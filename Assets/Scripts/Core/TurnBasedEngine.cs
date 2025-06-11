using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedEngine : MonoBehaviour
{
    private List<CombatEntity> entities = new List<CombatEntity>();
    private int currentTurnIndex = 0;
    private int turnIndex = 0;

    void Start()
    {
        Debug.Log("Turn-Based Engine Started.");

        // Create example combatants
        entities.Add(new CombatEntity("Werewolf", 100, 15));
        entities.Add(new CombatEntity("Hunter", 80, 20));

        CombatLog.Init("wolf_sim");
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (!IsBattleOver())
        {
            yield return new WaitForSeconds(1f); // simulate tick

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
        Application.Quit(0); // end headless process
    }

    private bool IsBattleOver()
    {
        int alive = 0;
        foreach (var e in entities)
            if (e.IsAlive) alive++;

        return alive <= 1;
    }
}
