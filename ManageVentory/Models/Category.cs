using System.ComponentModel.DataAnnotations;

namespace ManageVentory.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Description { get; set; } = String.Empty;

        [Required] //DAta anotation: Meaning the name is required for the object to be created
        public string Name { get; set; } = String.Empty;
    }
}
