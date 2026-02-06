using UnityEngine;

public enum ProductionType
{
    Unit,
    Research
}

[CreateAssetMenu(
    fileName = "New Building Card",
    menuName = "Cards/Building Card"
)]
public class BuildingCardData : CardData
{
    [Header("Costs")]
    public ResourceCost buildCost;
    public ResourceCost upkeepCost;
    public int buildTime;

    [Header("Stats")]
    public int maxHull;

    [Header("isActive")]
    public bool isActive;
}

public class ProductionBuildingCardData : BuildingCardData
{
    [Header("ProductionType")]
    public ProductionType productionType;
}

public class ResourceBuildingCardData : BuildingCardData
{
    [Header("Production")]
    public ResourceType resourceType;
    public int productionRate;
}