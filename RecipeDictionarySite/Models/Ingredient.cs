using System.ComponentModel.DataAnnotations;

namespace RecipeDictionarySite.Models
{
    public class Ingredient
    {
        public System.Guid IngredientID { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Name")]
        public string IngredientName { get; set; }
    }
}