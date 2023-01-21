using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Versta24.Models
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        [Required(ErrorMessage = "Введите город назначения")]
        [RegularExpression("^([а-яёА-ЯЁ\u0080-\u024F]+(?:. |-| |'))*[а-яёА-ЯЁ\u0080-\u024F]*$", ErrorMessage = "Недопустимые символы")]
        public string DstCity { get; set; }
        [Required(ErrorMessage = "Введите адрес назначения")]
        public string DstAddress { get; set; }
        [Required(ErrorMessage = "Введите город отрпавления")]
		[RegularExpression("^([а-яёА-ЯЁ\u0080-\u024F]+(?:. |-| |'))*[а-яёА-ЯЁ\u0080-\u024F]*$", ErrorMessage = "Недопустимые символы")]
		public string SrcCity { get; set; }
        [Required(ErrorMessage = "Введите адрес отправления")]
        public string SrcAddress { get; set; }
        [Required(ErrorMessage = "Введите вес в килограммах")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Не может быть отрицательным или нулевым")]
        [Column(TypeName = "decimal(9,3)")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Введите дату забора груза")]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }
    }
}
