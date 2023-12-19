using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Game/Player Stats", order = 1)]
public class PlayerStatsSO : ScriptableObject
{
    public string playerName;
    public int playerLevel = 1;
    public int maxHealth = 100;
    public int maxMana = 50;
    public string playerRace;

    // Otros atributos como fuerza, destreza, etc., según sea necesario
}