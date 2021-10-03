using System.Collections.Generic;

public static class UserManager
{
    private static User _currentUser;
    private static List<User> _users = new List<User>();
    public static List<User> Users => _users;
    public static User CurrentUser => _currentUser;

    public static void Init(UserData userData)
    {
        _currentUser = userData.LastUser;
        _users = userData.Users;
    }
}