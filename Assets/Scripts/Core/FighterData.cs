using SmartVars.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/FighterData")]
public class FighterData : ScriptableObject
{
    public SmartReference<string> FighterName;
    public SmartReference<int> MaxHP;
    public SmartReference<int> ATK;
}