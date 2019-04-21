using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualWeb.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }        
        public string PictureUri { get; set; }       
    }
}