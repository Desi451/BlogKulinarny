﻿using BlogKulinarny.Data.Helpers;
using BlogKulinarny.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogKulinarny.Data.Services.Users
{
    public class UserRecipesService : IUserRecipesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRecipesService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ChangesResult> CreateRecipe(Recipe recipe)
        {
            try
            {
                _dbContext.recipes.Add(recipe);
                await _dbContext.SaveChangesAsync();
                return new ChangesResult(true, "Pomyslnie dodano przepis");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ChangesResult(false, "wykryto wyjatek");
            }
        }

        public async Task<ChangesResult> UpdateRecipe(Recipe recipe)
        {
            try
            {
                _dbContext.recipes.Update(recipe);
                await _dbContext.SaveChangesAsync();
                return new ChangesResult(true, "Pomyslnie edytowano przepis");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ChangesResult(false, "wykryto wyjatek");
            }
        }

        public async Task<ChangesResult> DeleteRecipe(int recipeId)
        {
            try
            {
                Recipe recipe = await _dbContext.recipes.FirstOrDefaultAsync(u => u.id == recipeId);
                if (recipe != null)
                {
                    _dbContext.recipes.Remove(recipe);
                    await _dbContext.SaveChangesAsync(); // Zapisz zmiany w bazie danych

                    // jeszcze trzeba tutaj dodac usuwanie wszystkich elementow przepisu

                    return new ChangesResult(true, "Pomyslnie usunieto przepis");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ChangesResult(false, "wykryto wyjatek");
            }

            return new ChangesResult(false, "wystapil blad");
        }
    }
}