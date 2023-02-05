using Microsoft.AspNetCore.Mvc;

namespace FSEJwtApp.Front.ViewComponents
{
	public class NavbarViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
