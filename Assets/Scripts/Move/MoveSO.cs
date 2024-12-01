using UnityEngine;

/// <summary>
/// MoveSO stores the static data about a move, including
/// name, description, power, max pp, and type.
/// These private fields will be exposed via properties.
/// </summary>
[CreateAssetMenu(fileName = "New Move SO", menuName = "Scriptable Objects/Move SO")]
public class MoveSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private PokemonType _type;
    [SerializeField] private int _power;
    [SerializeField] private int accuracy;
    [SerializeField] private int _maxPP;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Power { get { return _power; } }
    public int MaxPP { get { return _maxPP; } }
    public int Accuracy { get { return accuracy; } }
    public PokemonType Type { get { return _type; } }
}
