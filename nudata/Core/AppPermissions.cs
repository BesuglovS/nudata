namespace nudata.Core
{
    public static class AppPermissions
    {
        public static bool Check(string permission)
        {
            return StartupForm.Permissions.Contains(permission);
        }
    }
}
