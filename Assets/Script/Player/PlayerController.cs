using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStatsSO playerStats;
    CharacterController playerController;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        // Acceder a las estad�sticas del jugador a trav�s del ScriptableObject
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