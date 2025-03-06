using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace CasoPractico.Pages
{
    public class GameOverModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Score { get; set; }

        public void OnGet()
        {
            // No se requiere l�gica adicional, solo mostrar el puntaje
        }
    }
}
