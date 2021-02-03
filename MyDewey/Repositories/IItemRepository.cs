using MyDewey.Models;
using System.Collections.Generic;

namespace MyDewey.Repositories
{
    public interface IItemRepository
    {
        void Add(Item item);
        void ApproveCheckout(Checkout checkout);
        void Checkin(Checkout checkout);
        void DeclineCheckout(Checkout checkout);
        List<Item> GetAllItems();
        List<Request> GetCheckoutRequests(int userProfileId);
        List<Item> GetNonUserItems(int userProfileId);
        List<Item> GetUserItems(int userProfileId);
        void RequestCheckout(int userProfileId, int itemId);
        void VerifyCheckin(Checkout checkout);
    }
}