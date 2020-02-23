using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.MVC.ViewsComponents
{
    [ViewComponent(Name = "Carrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {
        public int MyProperty { get; set; }

        public CarrinhoViewComponent()
        {
            MyProperty = 10;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(MyProperty);
        }
    }
}
