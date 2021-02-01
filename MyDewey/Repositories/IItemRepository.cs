﻿using MyDewey.Models;
using System.Collections.Generic;

namespace MyDewey.Repositories
{
    public interface IItemRepository
    {
        void Add(Item item);
        List<Item> GetAllItems();
        List<Item> GetUserItems(int userProfileId);
    }
}