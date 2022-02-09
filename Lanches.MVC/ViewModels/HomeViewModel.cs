using Lanches.MVC.Models;

namespace Lanches.MVC.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
