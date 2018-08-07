using System;
using System.Windows;
using System.Windows.Input;
using ListItemUI.ListItemPage.ViewModels;

namespace ListItemUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IListItemUIViewModel _itemsPageViewModel;
        private readonly IListItemUIViewModel _infoPageViewModel;

        public ICommand SelectItemsPageViewModel { get; }
        public ICommand SelectInfoPageViewModel { get; }

        public ICommand ClearAll { get; }



        public object CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set
            {
                _currentPageViewModel = value;
                RaisePropertyChanged(() => CurrentPageViewModel);
            }
        }
        private object _currentPageViewModel;

        public MainWindowViewModel(IPageFactory itemsPageFactory, IPageFactory infoPageFactory)
        {
            /* Creazione delle due pagine sfruttando le factory. */
            _itemsPageViewModel = itemsPageFactory.CreatePage();
            _infoPageViewModel = infoPageFactory.CreatePage();
           
            /* Istruzione richiamata quando viene premuto il corrispondente pulsante. */
            SelectItemsPageViewModel = new RelayCommand(_ =>
            {
                    CurrentPageViewModel = _itemsPageViewModel;
            });

            /* Istruzione richiamata quando viene premuto il corrispondente pulsante. */
            SelectInfoPageViewModel = new RelayCommand(_ =>
            {
                CurrentPageViewModel = _infoPageViewModel;
            });

          

            ClearAll = new RelayCommand(_ =>
            {
                bool res = _itemsPageViewModel.checkIfListIsNull();
                if (res)
                {
                    MessageBox.Show("Worklist is already empty");
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Do you really want to clear ListItem?",
                      "ListItemUI ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    res = _itemsPageViewModel.clearElements();
                    if (!res)
                    {
                        MessageBox.Show("Problem has occured");
                    }
                }
                else
                {
                    //do nothing
                };

            });


            /* Aggiornamento della pagina corrente che viene mostrata. */
            CurrentPageViewModel = _itemsPageViewModel;




        }

    }
}
