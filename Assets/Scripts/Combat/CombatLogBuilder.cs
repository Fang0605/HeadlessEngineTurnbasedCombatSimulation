using System;
using System.Text;

public class CombatLogBuilder
{
    private StringBuilder sb = new();

    public void Log(string line)
    {
        sb.AppendLine($"[{DateTime.Now:HH:mm:ss}] {line}");
    }

    public override string ToString() => sb.ToString();
}