using Microsoft.EntityFrameworkCore;
using RazorPagesExample.Business.Models;
using RazorPagesExample.Persistence;
using RazorPagesExample.Persistence.Entities;

namespace RazorPagesExample.Business.Services
{
    /// <summary>
    /// Managing Pets
    /// </summary>
    public class PetService
    {
        private readonly DataContext _dbContext;
        private readonly PetFactory _factory;

        public PetService(DataContext dbContext, PetFactory factory)
        {
            _dbContext = dbContext;
            _factory = factory;
        }

        /// <summary>
        /// List pet
        /// </summary>
        public async Task<List<PetViewModel>> ListPet(long userId)
        {
            var pets = await _dbContext.Pets.Where(u => u.UserId == userId).ToListAsync();
            return pets.Select(u => _factory.Create(u)).ToList();
        }

        /// <summary>
        /// Read pet by id
        /// </summary>
        public async Task<Pet> ReadPetById(long petId)
        {
            return await _dbContext.Pets.FindAsync(petId);
        }

        /// <summary>
        /// Create pet
        /// </summary>
        public async Task<bool> Create(PetCreateViewModel request)
        {
            try
            {
                var pet = _factory.Create(request);
                _dbContext.Pets.Add(pet);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update pet
        /// </summary>
        public async Task<bool> Update(PetUpdateViewModel request)
        {
            try
            {
                var pet = await ReadPetById(request.Id);

                _dbContext.Entry(pet).State = EntityState.Modified;

                pet.Name = request.Name;
                pet.Age = request.Age;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Delete pet
        /// </summary>
        public async Task<bool> Delete(long userId)
        {
            var pet = await _dbContext.Pets.FindAsync(userId);
            if (pet != null)
            {
                _dbContext.Pets.Remove(pet);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
