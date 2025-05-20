using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhase{
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
