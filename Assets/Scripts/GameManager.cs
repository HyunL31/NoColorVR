using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhase {
        StartMenu,
        FreeMove,
        Menu,
        Puzzle,
        Ending
    }

    private GamePhase gamePhase { get; set; }

    [SerializeField] private CharacterManager characterManager;

    private void Awake()
    {
        gamePhase = GamePhase.StartMenu;
    }
}