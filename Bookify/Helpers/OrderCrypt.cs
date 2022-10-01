namespace Bookify.Helpers;

public static class OrderCrypt
{
    public static string Encrypt(string encryptString)
    {
        var b = System.Text.Encoding.ASCII.GetBytes(encryptString);  
        var encrypted = Convert.ToBase64String(b);  
        return encrypted;  
    }
    public static string Decrypt(string encryptedString)  
    {
        string decrypted;  
        try
        {
            var b = Convert.FromBase64String(encryptedString);
            decrypted = System.Text.Encoding.ASCII.GetString(b);
        }  
        catch (FormatException fe)   
        {  
            decrypted = "";
            Console.WriteLine(fe.Message);
        }  
        return decrypted;  
    } 
}