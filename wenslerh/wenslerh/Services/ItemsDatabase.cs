﻿/**
 * This is where the items list is populated from... for now.
 * **/
 
 using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using wenslerh.Models;
using System;
using System.Linq;

namespace wenslerh
{
    public class ItemsDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public async Task Initialize()
        {
            int rowCount = await database.Table<Item>().CountAsync();

            if (rowCount == 0)
            {
                var AllItems = new List<Item>
                {
                    new Item {Name = "Sword", Description= "A really cool sword. ", Strength = 1},
                    new Item {Name = "Shield", Description="A really cool shield. ", Strength = 1},
                    new Item {Name = "Shoes", Description="A really cool pair of shoes. ", Strength = 1},
                    new Item {Name = "Bow", Description="A realy cool bow.", Strength = 1},
                    new Item {Name = "Lance", Description="A really cool lance. ", Strength = 1},
                    new Item {Name  = "Axe", Description="A really cool axe. " , Strength = 1},
                };

                foreach (Item item in AllItems)
                {
                    await database.InsertAsync(item);
                }
            }
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(String id)
        {
            return database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != "")
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
    }
}
