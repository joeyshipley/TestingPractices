using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.Infrastructure
{
    public static class ModelStateExtensions
    {
        public static List<ValidationResult> Validate(this BaseEntity entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, serviceProvider: null, items: null);
            Validator.TryValidateObject(entity, context, results, true);
            return results;
        }
    }
}