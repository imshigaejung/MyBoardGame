using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TurnManager turnManager;
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] CardManager cardManager;
    [SerializeField] BoardManager boardManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartGame()
    {
        turnManager.StartFirstTurn();
    }
}
