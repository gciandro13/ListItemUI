using ListItemUI.ListItemPage.DomainLogic;

namespace ListItemUI.ListItemPage.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        //inserire i pulsanti qui (nel dettaglio dell'Item)


        public string Prova
        {
            get { return "Sono vivo"; }
        }

        private double _localIndex;

        public double LocalIndex
        {
            get { return _localIndex; }
            set { _localIndex = value; }
        }


        public DetailViewModel(double localIndex)
        {
            LocalIndex = localIndex;
        }

    }
}
