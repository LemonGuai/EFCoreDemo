using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
	public class League
	{
		public int Id { get; set; }

		[Required]//不为空,必须
		[MaxLength(100)]//表示该属性长度不能超过100
		public string Name { get; set; }

		[Required,MaxLength(50)]
		public string Country { get; set; }
	}
}
