using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStatsSO playerStats;
    CharacterController playerController;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        // Acceder a las estadísticas del jugador a través del ScriptableObject
        Debug.Log("Player Name: " + playerStats.playerName);
        Debug.Log("Player Level: " + playerStats.playerLevel);
        Debug.Log("Max Health: " + playerStats.maxHealth);
        Debug.Log("Max Mana: " + playerStats.maxMana);
        Debug.Log("Player Race: " + playerStats.playerRace);
    }
    public float GetCurrentSpeed()
    {
        return this.playerController.velocity.magnitude;
    }
}