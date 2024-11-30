using UnityEngine;

/// <summary>
/// Pokemon has a private PokemonSO field. It exposes the stats of the Pokemon
/// modified by the level via properties.
/// Properties include max HP, attack, defense, special attack, special defense, speed,
/// HP, and Pokemon level.
/// The modification of stats by level follows the official Pokemon games formula.
/// The forumla to calculate level-modified stats are as follows:
/// HP = floor(0.01 x (2 x Base + IV + floor(0.25 x EV)) x Level) + Level + 10
/// Other Stats = (floor(0.01 x (2 x Base + IV + floor(0.25 x EV)) x Level) + 5) x Nature
/// </summary>
public class Pokemon
{
    public Pokemon(PokemonSO pPokemonSO, int pLevel)
    {
        _pokemonSO = pPokemonSO;
        _level = pLevel;
    }

    private PokemonSO _pokemonSO;
    private int _level;

    // Properties
    public PokemonSO PokemonSO { get { return _pokemonSO; } }
    public int Level { get { return _level; } }
    public int MaxHP { get { return Mathf.FloorToInt(0.01f * _pokemonSO.MaxHP * _level) + _level + 10; } }
    public int Attack { get { return Mathf.FloorToInt(0.01f * _pokemonSO.Attack * _level) + 5; } }
    public int Defense { get { return Mathf.FloorToInt(0.01f * _pokemonSO.Defense * _level) + 5; } }
    public int SpAttack { get { return Mathf.FloorToInt(0.01f * _pokemonSO.SpAttack * _level) + 5; } }
    public int SpDefense { get { return Mathf.FloorToInt(0.01f * _pokemonSO.SpDefense * _level) + 5; } }
    public int Speed { get { return Mathf.FloorToInt(0.01f * _pokemonSO.Speed * _level) + 5; } }
}
