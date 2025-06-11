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

        if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
        {
            folder = Path.Combine(Directory.GetCurrentDirectory(), "CombatLogs");
            Directory.CreateDirectory(folder);
            Debug.LogWarning("Using fallback log directory: " + folder);
        }

        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        logFilePath = Path.Combine(folder, $"{customName}_{timestamp}.txt");
        initialized = true;
        Write("=== Combat Log Started ===");
    }

    public static void Write(string message)
    {
        if (!initialized) Init(); 

        string timestampedMessage = $"[{System.DateTime.Now:HH:mm:ss}] {message}";
        File.AppendAllText(logFilePath, timestampedMessage + "\n");
        Debug.Log(timestampedMessage); 
    }

    public static void End()
    {
        Write("=== Combat Log Ended ===");
    }

    public static string GetLogPath()
    {
        if (!initialized)
            Init(); 

        return logFilePath;
    }
}
