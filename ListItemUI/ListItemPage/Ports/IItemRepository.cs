using System.Collections.Generic;
using ListItemUI.ListItemPage.DomainLogic;
using static ListItemUI.ListItemPage.Adapters.ItemRepository;

namespace ListItemUI.ListItemPage.ViewModels
{
    public interface IItemRepository
    {
        IEnumerable<IItem> GetItems();
        IItem getItem(string key);

    }
}