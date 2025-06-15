using MimicSpace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public enum GamePhase
    {
        StartMenu,
        Level1,
        Menu,
        Level2,
        Ending
    }

    public GamePhase gamePhase { get; set; }

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lamp;
    [SerializeField] private GameObject mimic;

    [SerializeField] private BloodEffectUI bloodEffectUI;

    private Vector3 playerPosition;
    private Vector3 mimicPosition;

    private void Awake()
    {
        ChangeGamePhase(1);
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

    public void SavePoint()
    {
        playerPosition = new Vector3(37.4f, 151.6f, 14.461f);
    }

    public void ResetLevel()
    {
        player.transform.position = playerPosition;
        lamp.transform.position = playerPosition + Vector3.forward*0.5f;
        CharacterManager.Instance.characterData.Health = 30;
        bloodEffectUI.CalculateDamage();
    }
}