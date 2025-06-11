using UnityEngine;

public class CombatCLI : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void MainCLI()
    {
        var args = System.Environment.GetCommandLineArgs();
        string fighter1Name = null;
        string fighter2Name = null;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-fighter1" && i + 1 < args.Length) fighter1Name = args[i + 1];
            if (args[i] == "-fighter2" && i + 1 < args.Length) fighter2Name = args[i + 1];
        }

        if (string.IsNullOrEmpty(fighter1Name) || string.IsNullOrEmpty(fighter2Name))
        {
            Debug.LogError("Usage: -fighter1 Name -fighter2 Name");
            Application.Quit();
            return;
        }

        // Load assets from Resources
        FighterData fighter1Data = Resources.Load<FighterData>($"Fighters/{fighter1Name}");
        FighterData fighter2Data = Resources.Load<FighterData>($"Fighters/{fighter2Name}");

        Debug.Log($"Fighter 1 Name: {fighter1Name}");
        Debug.Log($"Fighter 2 Name: {fighter2Name}");

        if (fighter1Data == null || fighter2Data == null)
        {
            Debug.LogError($"Could not load FighterData for: {fighter1Name} or {fighter2Name}");
            Application.Quit();
            return;
        }

        // Create Fighter from data
        Fighter f1 = new Fighter(fighter1Data);
        Fighter f2 = new Fighter(fighter2Data);

        CombatLog.Init("cli_combat");
        TurnBasedEngine.RunCombatAndLog(f1, f2);
        CombatLog.End();

        Debug.Log("Combat log written to: " + CombatLog.GetLogPath());
        Application.Quit();
    }
}
