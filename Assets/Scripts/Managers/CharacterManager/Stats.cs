using System;

[Serializable]
public class Stats
{
    private string _nickNickName;
    private int _level;
    private int _experience;
    private int _strength;
    private int _agility;
    private int _endurance;
    private int _perception;

    public string NickName
    {
        get => _nickNickName;
        set { _nickNickName = string.IsNullOrEmpty(value) ? "Player" : value; }
    }

    
    public Stats()
    {
        _nickNickName = "Player";
        _level = 0;
        _experience = 0;
        _strength = 3;
        _agility = 3;
        _endurance = 3;
        _perception = 3;
    }

    public Stats(string nickNickName) : this()
    {
        _nickNickName = nickNickName;
    }
}