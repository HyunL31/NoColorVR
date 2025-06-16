using MimicSpace;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public enum GamePhase // Game phase enumeration
    {
        StartMenu,
        Level1,
        Menu,
        Level2,
        Ending
    }

    public GamePhase gamePhase { get; set; } // Game phase enumeration

    [SerializeField] private GameObject player; // Reference to player object
    [SerializeField] private GameObject lamp; // Reference to lamp object
    [SerializeField] private GameObject mimic; // Reference to mimic enemy

    [SerializeField] private BloodEffectUI bloodEffectUI; // UI for damage effect
    private Vector3 playerPosition; // Saved player respawn position

    private void Awake()
    {
        ChangeGamePhase(1); // Start in StartMenu phase
    }

    public void ChangeGamePhase(int p)
    {
        switch (p)
        {
            case 1:
                gamePhase = GamePhase.StartMenu;
                Time.timeScale = 0;
                break;
            case 2:
                gamePhase = GamePhase.Level1;
                Time.timeScale = 1f;
                break;
            case 3:
                gamePhase = GamePhase.Menu;
                break;
            case 4:
                gamePhase = GamePhase.Level2;
                // Enable mimic enemy components
                mimic.GetComponent<Movement>().enabled = true;
                mimic.GetComponent<AudioSource>().enabled = true;
                mimic.transform.GetChild(0).GetComponent<AttackChecker>().enabled = true;
                Time.timeScale = 1f;
                break;
            case 5:
                gamePhase = GamePhase.Ending;
                break;
        }
    }

    // Save current player position as respawn point
    public void SavePoint()
    {
        playerPosition = new Vector3(37.4f, 151f, 14.461f);
    }

    public void ResetLevel()
    {
        // Move player to saved position
        player.transform.position = playerPosition;

        // Temporarily disable lamp physics to move it
        lamp.GetComponent<Rigidbody>().isKinematic = true;
        lamp.transform.position = playerPosition + Vector3.forward * 0.5f;
        lamp.GetComponent<Rigidbody>().isKinematic = false;

        CharacterManager.Instance.characterData.Health = 30; // reset health
        bloodEffectUI.CalculateDamage(); // update damage UI
    }
}