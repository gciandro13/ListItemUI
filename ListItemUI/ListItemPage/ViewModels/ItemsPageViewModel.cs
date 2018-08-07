using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ListItemUI.ListItemPage.Adapters;
using ListItemUI.ListItemPage.DomainLogic;

namespace ListItemUI.ListItemPage.ViewModels
{
    /* View Model della pagina con la lista degli item. */
    public class ItemsPageViewModel : ViewModelBase , IListItemUIViewModel
    {

        public ICommand Delete { get; }
        public ICommand StartFromThis { get; }

        /* Titolo della pagina. */
        public string Title
        {
            get { return "ViewModel's page"; }
            set { }
        }

        public ObservableCollection<ItemViewModel> LocalItemViewModels
        {
            get { return _localItemViewModels; }
            set
            {
                _localItemViewModels = value;
                RaisePropertyChanged(() =>LocalItemViewModels);
            }
        }

        private ObservableCollection<ItemViewModel> _localItemViewModels;


        private ItemViewModel _selectedItem;
        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }


        /* Costruttore: crea la lista di ItemViewModel. */
        public ItemsPageViewModel(IItemRepository itemRepo)
        {
            LocalItemViewModels = new ObservableCollection<ItemViewModel>();
            var itemsFromDB = itemRepo.GetItems();
            foreach (var item in itemsFromDB)
            {  
                var dvm = new List<DetailViewModel>();
                //TODO: va bene crearne uno per item?
                dvm.Add(new DetailViewModel(item.Index));
                var itVM = new ItemViewModel(item, dvm);
                LocalItemViewModels.Add(itVM);
            }
            string progIndex; 
            string progLabel;

            Delete = new RelayCommand(_ =>
            {
                try {
                    progIndex = SelectedItem.Index.ToString();
                    progLabel = SelectedItem.Label.ToString();
                    MessageBoxResult result = MessageBox.Show(string.Format("Do you really want to delete item {0} ({1})?", progIndex, progLabel),
                       "ListItemUI ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        LocalItemViewModels.Remove(SelectedItem);
                        RaisePropertyChanged(() => LocalItemViewModels);
                        MessageBox.Show(string.Format("Item {0} deleted correctly ({1})", progIndex, progLabel), "ListItemUI");
                    }
                    else
                    {
                        //Do nothing
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Item not selected", "ListItemUI ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });

            StartFromThis = new RelayCommand(_ =>
            {
                try
                {
                    progIndex = SelectedItem.Index.ToString();
                    progLabel = SelectedItem.Label.ToString();

                        MessageBoxResult result = MessageBox.Show(string.Format("Do you really want to start the Execution \nfrom Item {0} ({1})?", progIndex, progLabel),
                            "ListItemUI ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    
                        if (result == MessageBoxResult.Yes)
                        {

                            MessageBox.Show(string.Format("Execution started from Item {0} ({1})", progIndex, progLabel),
                            "ListItemUI ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            //Non fare niente
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Item not selected", "ListItemUI ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }

       


        /* Metodo per chiudere la pagina. */
        public void closePage()
        {
            
        }
        
        public bool clearElements()
        {
            try
            {
                LocalItemViewModels = null;
                RaisePropertyChanged(() => LocalItemViewModels);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool checkIfListIsNull()
        {
            return LocalItemViewModels == null ? true : false;
        }
    }
}
