using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeDictionarySite.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "ImageURL")]
        public string ImageURL { get; set; }
        [Display(Name = "PreparationSteps")]
        public List<PreparationStep> PreparationSteps { get; set; }
        [Display(Name = "Ingredients")]
        public List<Ingredient> Ingredients { get; set; }
        [Display(Name = "TimeToCook")]
        public TimeSpan TimeToCook { get; set; }
        [Display(Name = "NumHit")]
        public Int64 NumHit { get; set; }
    }
}
