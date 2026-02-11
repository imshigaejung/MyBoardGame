using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 외부 GameObject에서의 연결점 생성
    public static GameManager Instance;

    // 매니저 연결
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private BoardManager boardManager;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BattleManager battleManager;
    public TurnManager Turn => turnManager;
    public ResourceManager Resource => resourceManager;
    public BoardManager Board => boardManager;
    public CardManager Card => cardManager;
    public BattleManager Battle => battleManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

        public void StartGame()
    {   
        Board.Init();
        Turn.Init();
        Battle.Init();
        Card.Init();
        Resource.Init();

        // ⭐ 모든 매니저 Init 끝난 뒤
        RegisterEvents();
        boardManager.GenMap();
        turnManager.StartFirstTurn();
    }

    void RegisterEvents()
    {
        
    }
}
