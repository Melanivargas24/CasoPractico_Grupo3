using CasoPractico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CasoPractico.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SnakeGameContext _context;

        public IndexModel(SnakeGameContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int Score { get; set; }

        [BindProperty]
        public int Duration { get; set; } // duraci�n de la partida en segundos

        public string Username { get; set; } = "Player"; // Suponemos que el usuario es un visitante no autenticado

        public IActionResult OnPostGameOver(int score, int duration)
        {
            // Guardar el historial del juego
            var gameHistory = new GameHistory
            {
                Username = Username,
                Score = score,
                Duration = duration,
                GameDate = DateTime.Now
            };

            _context.GameHistories.Add(gameHistory);
            _context.SaveChanges();

            // Redirigir a la p�gina principal con el resultado
            return RedirectToPage("GameResult", new { score = score, duration = duration });
        }
    }
}

