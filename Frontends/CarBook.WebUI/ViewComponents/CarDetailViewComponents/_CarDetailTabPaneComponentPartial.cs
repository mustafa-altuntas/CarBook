using Carbook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailTabPaneComponentPartial : ViewComponent
	{
	
		public async Task<IViewComponentResult> InvokeAsync(int carId)
		{
			return View();
		}
	}
}
