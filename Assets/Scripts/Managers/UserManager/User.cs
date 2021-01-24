using System;
using System.Linq;

[Serializable]
public class User
{
    private int _id;
    private Character _character;
    public int ID
    {
        get
        {
            if (_id > 0) return _id;
            GetID();
            return _id;
        }
        set
        {
            if (value > 0) _id = value;
            else
            {
                GetID();
            }
        }
    }

    public Character Character
    {
        get => _character;
        set { _character = value ?? new Player();}
    }


    public User()
    {
        GetID();
        _character = new Player();
    }
    
    private void GetID()
    {
        var id = 1;
        var ids = UserManager.Users.Select(x => x._id).ToList();
        var ascendingOrder = ids.OrderBy(x => x);
        foreach (var x in ascendingOrder) if(x == id) id++;
        _id = id;
    }
}