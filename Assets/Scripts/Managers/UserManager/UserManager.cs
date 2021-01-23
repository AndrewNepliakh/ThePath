public static class UserManager
{
    private static User _user;
    public static User User => _user;

    public static void Init(SaveData saveData)
    {
        _user = new User(saveData.UserData);
    }
}