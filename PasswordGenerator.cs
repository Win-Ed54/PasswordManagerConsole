public static class PasswordGenerator
{
    public static string GeneratePassword(
        int length,
        bool includeUppercase,
        bool includeNumbers,
        bool includeSymbols)
    {
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789"; 
        string symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

        string characters = lowercase;

        if (includeUppercase)
        {
            characters += uppercase;
        }

        if (includeNumbers)
        {
            characters += numbers;
        }

        if (includeSymbols)
        {
            characters += symbols;
        }

        Random random = new Random();
        string password = "";
        for(int i = 0; i < length; i++)
        {
            int index = random.Next(characters.Length);
            password += characters[index];

        }

        return password;
    }
}