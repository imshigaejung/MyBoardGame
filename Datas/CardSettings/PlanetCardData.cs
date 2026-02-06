using UnityEngine;

[CreateAssetMenu(
    fileName = "New Planet Card",
    menuName = "Cards/Planet Card"
)]
public class PlanetCardData : CardData
{
    [Header("Planet Stats")]
    [Range(0, 10)]
    public int occupation;

    [Range(0, 10)]
    public int development;

    [Header("Production")]
    public int energyOutput;
    public int materialOutput;
    public int creditOutput;

    [Header("Capacity")]
    public int energyStorage;
    public int materialStorage;
    
    [Header("Slots")]
    public bool hasBuilding;
}
