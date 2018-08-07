using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListItemUI.ListItemPage.DomainLogic;

namespace ListItemUI.ListItemPage.ViewModels
{
    /* View Model del singolo item (programma/riga di distinta). */

    public class ItemViewModel : ViewModelBase
    {
        private List<DetailViewModel> _lclDetailViewModel;

        public List<DetailViewModel> LclDetailViewModel
        {
            get { return _lclDetailViewModel; }
            set { _lclDetailViewModel = value; }
        }

        private string _comment;

        public string Comment
        {
            get { return _localItem.Comment; }
            set { _localItem.Comment = value; }
        }

        public int Index
        {
            get { return _localItem.Index; }
            private set { _localItem.Index = value; }
        }

        public IItem LocalItem
        {
            get { return _localItem; }
            set { _localItem = value; }
        }

        public string Label
        {
            get { return _localItem.Label;}
          
        }

        public int Number
        {
            get { return _localItem.Number ; }
        }

        public double Quantity
        {
            get { return _localItem.Quantity; }
        }


        private IItem _localItem ;


        public ItemViewModel(IItem i, List<DetailViewModel> dvm)
        {
            LocalItem = i;
            LclDetailViewModel = dvm;
        }
    }
}
