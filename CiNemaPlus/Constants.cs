/*
        Programmeur :   Michael LeBlanc | Samuel Chiasson 
        Date        :   11 mai 2026 
        But         :   Movies
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiNemaPlus
{
    public static class Constants
    {
        public const string MoviesApiKey = "38eafce929e74b00001e5590d43f3a79";
        public const string BaseUrl = "https://api.themoviedb.org/3/";

        //SQLite
        public const string DatabaseFilename = "CiNemaPlusSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        //Open database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        //Create database if it doesnt exist
        SQLite.SQLiteOpenFlags.Create |
        //Multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
