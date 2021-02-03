using MyDewey.Models;
using System.Collections.Generic;

namespace MyDewey.Repositories
{
    public interface IItemRepository
    {
        void Add(Item item);
        void AddToCheckoutQueue(int checkoutId);
        void ApproveCheckout(int checkoutId, int itemId);
        void Checkin(int checkoutId);
        void DeclineCheckout(int checkoutId);
        List<Item> GetAllItems();
        List<Request> GetCheckoutRequests(int userProfileId);
        List<Item> GetNonUserItems(int userProfileId);
        List<Item> GetUserItems(int userProfileId);
        void RequestCheckout(int userProfileId, int itemId);
        void VerifyCheckin(int checkoutId, int itemId);
    }
}