namespace Bookify.Helpers;

public static class UserRoleTypes
{ 
    static UserRoleTypes()
    {
        Admin = "Admin";
        Customer = "Customer";
    }
    public static string Admin { get; set; }
    public static string Customer { get; set; }
}