using System.ComponentModel.DataAnnotations;

namespace FSEJwtApp.Front.Models
{
	public class CreateCategoryModel
	{
		[Required(ErrorMessage ="Kategory adi gereklidir.")]
		public string Definition { get; set; } = null!;
	}
}
