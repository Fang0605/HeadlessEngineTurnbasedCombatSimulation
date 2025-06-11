//#if UNITY_EDITOR || DEVELOPMENT_BUILD || CLI_TEST
//using System;
//using System.IO;
//using UnityEngine;

//public static class CombatCLIRunner
//{
//    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
//    static void Main()
//    {
//        if (!IsRunningHeadless()) return;

//        Debug.Log("Starting CLI headless combat test...");

//        // 1. Setup dummy combat
//        var battle = new CombatTestSimulation();
//        battle.Run();

//        // 2. Dump log
//        string log = battle.GetCombatLog();
//        string folder = Directory.GetCurrentDirectory(); // this resolves to the .exe folder
//        string path = Path.Combine(folder, "CombatLog.txt");
//        File.WriteAllText(path, log);
//        Debug.Log($"Combat finished. Log saved to: {path}");

//        // Auto-open the log (only on Windows)
//#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
//        System.Diagnostics.Process.Start("explorer.exe", path.Replace("/", "\\"));
//#endif

//        // 3. Exit (if in true headless mode)
//        Application.Quit(0);
//    }

//    static bool IsRunningHeadless()
//    {
//        return Environment.CommandLine.Contains("-batchmode") || Application.isBatchMode;
//    }
//}
//#endif