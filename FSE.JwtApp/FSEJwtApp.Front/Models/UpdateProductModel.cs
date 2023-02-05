using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FSEJwtApp.Front.Models
{
	public class UpdateProductModel
	{
		[Required(ErrorMessage = "Urun Id bos gecilemez")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Urun adi bos gecilemez")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Stok bos gecilemez")]
		public int Stock { get; set; }
		[Required(ErrorMessage = "Fiyat bos gecilemez")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Kategori secimi yapiniz.")]
		public int CategoryId { get; set; }
		public SelectList? Categories { get; set; }
	}
}
