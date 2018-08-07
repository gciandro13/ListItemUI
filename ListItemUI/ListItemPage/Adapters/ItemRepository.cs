using System;
using System.Collections.Generic;
using System.Linq;
using ListItemUI.ListItemPage.DomainLogic;
using ListItemUI.ListItemPage.ViewModels;

namespace ListItemUI.ListItemPage.Adapters
{
    public class ItemRepository : IItemRepository
    {
        private IDBRepository _idbrepo;

        public ItemRepository(IDBRepository idbrep)
        {
            _idbrepo = idbrep;
        }

        public IItem getItem(string key)
        {
            var foundItem = this.GetItems().SingleOrDefault(r => r.Index.ToString() == key);
            //return foundItem;       // TEST MARCO
            return new Item(foundItem.Label, foundItem.Number, foundItem.Quantity, foundItem.Comment, foundItem.Index, this);
        }

        public IEnumerable<IItem> GetItems()
        {
            var retList = new List<IItem>();

            for(int j = 0; j < 5; j++)
            {
                //TODO: cambiare cosa visualizziamo dell'item
                Item i = new Item("label",2,3,"comment",j,this);
                
                retList.Add(i);
            }
            return retList;
        }
    }
}
