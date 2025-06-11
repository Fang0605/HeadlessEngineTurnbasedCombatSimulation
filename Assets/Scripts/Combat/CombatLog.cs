using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CombatLog
{
    private static string logFilePath;
    private static bool initialized = false;

    public static void Init(string customName = "combat_log")
    {
        string folder = Application.persistentDataPath;
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        logFilePath = Path.Combine(folder, $"{customName}_{timestamp}.txt");
        initialized = true;
        Write("=== Combat Log Started ===");
    }

    public static void Write(string message)
    {
        if (!initialized) Init(); // Auto-init if forgotten

        string timestampedMessage = $"[{System.DateTime.Now:HH:mm:ss}] {message}";
        File.AppendAllText(logFilePath, timestampedMessage + "\n");
        Debug.Log(timestampedMessage); // Optional: still output to console
    }

    public static void End()
    {
        Write("=== Combat Log Ended ===");
    }
}
