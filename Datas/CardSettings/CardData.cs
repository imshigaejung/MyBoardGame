using UnityEngine;

public enum CardType {
    Planet,
    Unit,
    Research,
    Policy,
    Building
}


public abstract class CardData : ScriptableObject
{
    [Header("Basic Info")]
    public string cardName;
    [TextArea]
    public string description;
    public Sprite artwork;

    public CardType cardType;
}