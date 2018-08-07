using System.Windows;
using ListItemUI.ViewModels;

namespace ListItemUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IPageFactory itemPageFactory, IPageFactory infoPageFactory)
        {
            /* Inizializzazione dei componenti. */
            InitializeComponent();
            /* Creazione View Model associato alla finestra (MainWindowViewModel).
             * Vengono passate le factory dei View Model delle due pagine, per permettere la creazione dei View Model internamente. */
            var mainWindowVM = new MainWindowViewModel(itemPageFactory , infoPageFactory);
            /* Associa il Data Context della View al View Model ottenuto. */
            DataContext = mainWindowVM;
            
        }

    }
}
