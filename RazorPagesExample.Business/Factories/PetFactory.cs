using RazorPagesExample.Business.Models;
using RazorPagesExample.Persistence.Entities;

namespace RazorPagesExample.Business
{

    /// <summary>
    /// Pet object mapping
    /// </summary>
    public class PetFactory
    {
        public virtual PetViewModel Create(Pet pet)
        {
            if (pet is null) return null;

            return new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                UserId = pet.UserId,
                Type = Create(pet.Type),
            };
        }
        public virtual Pet Create(PetCreateViewModel pet)
        {
            if (pet is null) return null;

            return new Pet
            {
                Name = pet.Name,
                Age = pet.Age,
                UserId = pet.UserId,
                Type = Create(pet.Type),
            };
        }

        public virtual PetTypeViewModel Create(PetType pet)
        {
            return (PetTypeViewModel)pet;
        }

        public virtual PetType Create(PetTypeViewModel pet)
        {
            return (PetType)pet;
        }

    }
}
