using System;

[Serializable]
public abstract class Character
{
    protected Stats _stats;
    protected Properties _properties;
    protected Equipment _equipment;
    protected Inventory _inventory;

    public Stats Stats
    {
        get => _stats;
        set => _stats = value ?? new Stats();
    }

    protected Character()
    {
        _stats = new Stats();
        _properties = new Properties();
        _equipment = new Equipment();
        _inventory = new Inventory();
    }
}
