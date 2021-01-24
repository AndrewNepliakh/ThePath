using System;

[Serializable]
public class Player : Character
{
    public Player() : base()
    {
        
    }

    public Player(string name) : this()
    {
        _stats = new Stats(name);
    }
}