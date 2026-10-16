using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PasswordApp.Pages;

public class CheckModel : PageModel
{
    [BindProperty]
    public string Password { get; set; }

    public IActionResult OnGet()
    {
        Password = string.Empty;
        TempData["Poruka"] = string.Empty;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        TempData["Poruka"] = string.Empty;
        if(string.IsNullOrEmpty(Password))
        {
            TempData["Poruka"] = $"Lozinka „{Password}” nije ispravna .";
        }
        else if(Password.Length < 8)
        {
            TempData["Poruka"] = $"Lozinka „{Password}” je prekratka, mora imati barem 8 znakova.";
        }
        else if(!Password.Any(char.IsUpper))
        {
            TempData["Poruka"] = $"Lozinka „{Password}” ne sadrži nijedno veliko slovo!";
        }
        else if(!Password.Any(char.IsLower))
        {
            TempData["Poruka"] = $"Lozinka „{Password}” ne sadrži nijedno malo slovo!";
        }
        else
        {
            TempData["Poruka"] = $"Lozinka „{Password}” je ispravna .";
        }
        return Page();
    }
}
