using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SummitWeather.Models;

namespace SummitWeather.Data
{
    public class LocationDB
    {
        readonly SQLiteConnection database;

        public LocationDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<SavedLocation>();
        }

        public List<SavedLocation> GetItems()
        {
            return database.Table<SavedLocation>().ToList();
        }

       

        public int SaveItem(SavedLocation item)
        {
            if (item.ID != 0)
            {
                return database.Update(item);
            }
            else
            {
                return database.Insert(item);
            }
        }

    }
}
