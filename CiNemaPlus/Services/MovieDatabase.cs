using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiNemaPlus.Models;
using SQLite;

namespace CiNemaPlus.Services
{
    public class MovieDatabase
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await database.CreateTableAsync<Movie>();
        }

        public async Task<List<Movie>> GetItemsAsync()
        {
            await Init();
            return await database.Table<Movie>().ToListAsync();
        }

        public async Task<Movie> GetItemAsync(int id)
        {
            await Init();
            return await database.Table<Movie>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Movie movie)
        {
            await Init();
            if (movie.Id != 0)
                return await database.UpdateAsync(movie);
            else
                return await database.InsertAsync(movie);
        }

        public async Task<int> DeleteItemAsync(Movie movie)
        {
            await Init();
            return await database.DeleteAsync(movie);
        }
    }
}