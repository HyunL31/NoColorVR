using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private GameObject levelClearUI;
    [SerializeField] private SceneController sceneController;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.gamePhase == GameManager.GamePhase.Level1 && levelClearUI!=null)
        {
            gameManager.ChangeGamePhase(3);
            if (levelClearUI != null)
                levelClearUI.SetActive(true);
            gameManager.SavePoint();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player") && gameManager.gamePhase == GameManager.GamePhase.Level2 && sceneController!=null)
        {
            gameManager.ChangeGamePhase(5);
            sceneController.EndTitle();
            Destroy(gameObject);
        }

    }
}
