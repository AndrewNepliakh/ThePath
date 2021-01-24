using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class UserData
{
    public User LastUser;
    public List<User> Users = new List<User>();
}