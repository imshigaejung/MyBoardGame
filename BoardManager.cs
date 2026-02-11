using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 기본 동작 흐름
/// TileBehaviour에서 변화 감지 -> 보드 매니저로 데이터 전송 -> 보드 매니저에서 판단 & 연산 -> Map 데이터 업데이트
/// -> tileViews의 연결정보를 기반 필요한 타일들에게 업데이트 된 데이터 전송 -> 타일에서 해당 변화 표현
/// 유저 케이스 - 보드
/// 0. 맵 생성
/// 1. 타일 선택
/// 2. 유닛 & 건물 배치 - CardManager 호출
/// 3. 유닛 & 건물 이동
/// 4. 유닛 & 건물에 대한 공격 - BattleManager 호출
/// </summary>

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int mapSize;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private float tileSize = 2f;

    // 맵 데이터를 담는 배열
    private TileData[,] map;
    public TileData[,] Map => map;
    // 생성될 타일의 스크립트에 대한 연결 정보를 담는 딕셔너리
    Dictionary<TileCoordinate, TileBehaviour> tileViews;

    public void Init()
    {
        
    }

    // 맵 생성
    public void GenMap()
    {
        // 기존 맵 정리
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // 데이터를 담을 맵 확보
        map = new TileData[mapSize, mapSize];

        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                // 좌표를 기준으로 맵 데이터 생성
                map[x, y] = new TileData(x, y);

                // 실제 타일 오브젝트 생성
                GameObject tileObj = Instantiate(
                    tilePrefab,
                    new Vector3(x * tileSize, y * tileSize, 0),
                    Quaternion.identity,
                    transform
                );

                // 디버그 용이성을 위해 타일 오브젝트 이름에 좌표값을 붙임
                tileObj.name = $"Tile_{x}_{y}";

                // 오브젝트의 TileBehaviour 스크립트와 연결
                TileBehaviour behaviour = tileObj.GetComponent<TileBehaviour>();
                if (behaviour != null)
                {   
                    // 맵에 저장된 데이터를 오브젝트에 전달
                    behaviour.Init(map[x, y]);
                    // 스크립트 -> 보드매니저 연결
                    behaviour.SetManager(this);

                    // 딕셔너리 형태로 각 타일의 보드매니저 -> 스크립트 연결
                    tileViews[new TileCoordinate(x, y)] = behaviour;
                }

            }
        }
    }

    public void ShowRange(TileCoordinate coordinate, int range, TileState state)
    {
        for (int dx = -range; dx < range; dx++)
        {
            for (int dy = -range; dy < range; dy++)
            {
                int x = dx + coordinate.x;
                int y = dy + coordinate.y;

                if(!IsInMap(x, y)) continue;

                TileData tile = map[x, y];
                tile.tileState = state;
                tileViews[new TileCoordinate(x, y)].Init(tile);            
            }
        }
    }

    // 대상 타일이 지도 내에 존재하는지 확인
    bool IsInMap(int x, int y)
    {
        return x >= 0 && y >= 0 && x < mapSize && y < mapSize;
    }

    // TileBehaviour에서 타일 클릭을 감지했을 때 호출되는 함수
    public void TileSelection(TileData data)
    {
        // 타일에 존재하는 카드 인스턴스 불러오기
        ITileOccupant occupant = data.occupant;
        int attackRange = 0;
        int moveRange = 0;

        // 공격 가능한 개체일 시 사거리 불러오기
        if (occupant is IAttackable attackable)
        {
            attackRange = attackable.attackRange;
        }
        // 이동 가능한 개체일 시 이동거리 불러오기
        if (occupant is IMovable movable)
        {
            moveRange = movable.moveSpeed;
        }

        // 인스턴스가 빈 경우 체크
        if (!data.IsEmpty)
        {   
            // 타일 위에 존재하는 개체가 유닛 혹은 함대일 때 - 공격 가능 & 이동 가능
            if(occupant.Type == OccupantType.Unit || occupant.Type == OccupantType.Fleet)
            {
                ShowRange(data.Coordinate, attackRange, TileState.Attackable);
                ShowRange(data.Coordinate, moveRange, TileState.Movable);
            }
        } 
    }

    public void TileDeselection(TileData data)
    {
        
    }
    public void Deployment()
    {
        
    }

    public void Destruction()
    {
        
    }

    public void Movement()
    {
        
    }
}
