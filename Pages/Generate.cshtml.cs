using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PasswordApp.Pages
{
    public class GenerateModel : PageModel
    {
        [BindProperty]
        public List<string> Passwords { get; set; } = new List<string>();
        public void OnGet()
        {
            for (int i = 0; i < 10; i++)
            {
                Passwords.Add(GeneratePassword());
            }
        }

        private string GeneratePassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";
            Random random = new Random();
            int passwordLength = random.Next(8, 16);
            List<char> passwordChars = new List<char>();

            for (int i = 0; i < passwordLength; i++)
            {
                char randomChar = validChars[random.Next(validChars.Length)];
                passwordChars.Add(randomChar);
            }

            return string.Join("", passwordChars);
        }
    }
}
