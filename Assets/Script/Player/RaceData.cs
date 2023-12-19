using UnityEngine;

[CreateAssetMenu(fileName = "RaceData", menuName = "Game/Race Data", order = 1)]
public class RaceData : ScriptableObject
{
    public string raceName;
    public int baseHealth = 100;
    public int baseAttackDamage = 10;
    public int baseMana = 50;
}
