
using System;
using System.Linq;
using ListItemUI.ListItemPage.Adapters;
using ListItemUI.ListItemPage.ViewModels;
using static ListItemUI.ListItemPage.DomainLogic.Item;

namespace ListItemUI.ListItemPage.DomainLogic
{


    public interface IItem
    {

        string Label { get; }
        int Number { get; }
        string Comment { get; set; }
        bool isSelected();
        double Quantity { get; set; }
        int Index { get; set; }
        void select();
    }

    public class Item : IItem
    {
        private readonly IItemRepository _itemrepo;
        private bool _selectedState;

                                           
        public Item(string label,int number, double quantity, string comment, int index, IItemRepository itemrepo)
        {
            Label = label;
            Number = number;
            Comment = comment;
            Quantity = quantity;
            Index = index;
            _selectedState = false;
            _itemrepo = itemrepo;
            // printIt();
        }



        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }


        private int _index;

        public int Index
        {
            get { return _index; }

            set { _index = value; }
        }


        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }


        private double _quantity;

        public double Quantity
        {
            get { return _quantity;}
            set { _quantity = value; }
        }

        public bool isSelected()
        {
            return _selectedState;
        }


     

        public void select()
        {
            if (_selectedState)
            {
                _selectedState = true;
            }
            else _selectedState = false;
        }
    }

    public class ItemChangedEventHandlerArgs
    {
        public IItem ChangedItem { get; }

        public ItemChangedEventHandlerArgs(IItem changedItem)
        {
            ChangedItem = changedItem;
        }

    }
}
