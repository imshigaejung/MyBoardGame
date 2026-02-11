using UnityEngine;
using System;

public class TurnManager : MonoBehaviour
{
    public int currentTurn { get; private set; }
    public int actionPoints { get; private set; }
    public int actionPointsGen { get; private set; }

    public event Action OnTurnStart;
    public event Action OnTurnEnd;

    public void Init()
    {
        
    }

    // 첫 턴 시작 & 변수 초기화
    public void StartFirstTurn()
    {
        currentTurn = 1;
        actionPointsGen = 5;
        StartTurn();
    }

    // 턴 시작
    void StartTurn()
    {
        actionPoints += actionPointsGen;
        OnTurnStart?.Invoke();
    }

    // 턴 종료
    public void EndTurn()
    {
        actionPoints = 0;
        OnTurnEnd?.Invoke();
        currentTurn++;
        StartTurn();
    }

    //행동 시 행동력을 1 소모하는 함수
    public bool ConsumeAction(int amount = 1)
    {
        if (actionPoints < amount)
            return false;

        actionPoints -= amount;
        return true;
    }

    //매턴 행동력 획득량을 늘리는 함수
    public void IncActionPointsGen(int amount = 1)
    {
        actionPointsGen += amount;
    }
}