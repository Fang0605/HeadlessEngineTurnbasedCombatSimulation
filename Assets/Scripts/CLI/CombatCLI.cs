using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCLI : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void MainCLI()
    {
        var args = System.Environment.GetCommandLineArgs();
        string fighter1Arg = null;
        string fighter2Arg = null;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-fighter1" && i + 1 < args.Length) fighter1Arg = args[i + 1];
            if (args[i] == "-fighter2" && i + 1 < args.Length) fighter2Arg = args[i + 1];
        }

        if (fighter1Arg == null || fighter2Arg == null)
        {
            Debug.LogError("Usage: -fighter1 Name:HP:DMG -fighter2 Name:HP:DMG");
            Application.Quit();
            return;
        }

        Fighter f1 = ParseFighter(fighter1Arg);
        Fighter f2 = ParseFighter(fighter2Arg);

        CombatLog.Init("cli_combat");
        TurnBasedEngine.RunCombatAndLog(f1, f2);
        CombatLog.End();

        Debug.Log("Combat log written to: " + CombatLog.GetLogPath());
        Application.Quit();
    }

    static Fighter ParseFighter(string arg)
    {
        var parts = arg.Split(':');
        string name = parts[0];
        int hp = int.Parse(parts[1]);
        int dmg = int.Parse(parts[2]);
        return new Fighter(name, hp, dmg);
    }
}
