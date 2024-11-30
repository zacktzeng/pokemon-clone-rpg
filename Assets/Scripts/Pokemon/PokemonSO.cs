using UnityEngine;

/// <summary>
/// PokemonSO store the static data for each Pokemon, including
/// name, description, front sprite, back sprite,
/// primary type, secondary type, learnable moves
/// max HP, attack, defense, special attack, special defense, and speed.
/// These fields will be exposed via properties.
/// </summary>
[CreateAssetMenu(fileName = "New Pokemon SO", menuName = "Pokemon SO")]
public class PokemonSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _backSprite;
    [SerializeField] private PokemonType _primaryType;
    [SerializeField] private PokemonType _secondaryType;
    [SerializeField] private int _maxHP;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _spAttack;
    [SerializeField] private int _spDefense;
    [SerializeField] private int _speed;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public Sprite FrontSprite { get { return _frontSprite; } }
    public Sprite BackSprite { get { return _backSprite; } }
    public PokemonType PrimaryType { get { return _primaryType; } }
    public PokemonType SecondaryType { get { return _secondaryType; } }
    public int MaxHP { get { return _maxHP; } }
    public int Attack { get { return _attack; } }
    public int Defense { get { return _defense; } }
    public int SpAttack { get { return _spAttack; } }
    public int SpDefense { get { return _spDefense; } }
    public int Speed { get { return _speed; } }
}

/// <summary>
/// PokemonType is an enum that represents the type of a Pokemon.
/// The None type is used for the optional secondary type.
/// </summary>
[System.Serializable]
public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy
}
