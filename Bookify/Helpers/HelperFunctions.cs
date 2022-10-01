namespace Bookify.Helpers;

public static class HelperFunctions
{
    public static string GenerateRandomString()
    {
        return new Random().Next().ToString();
    }
}