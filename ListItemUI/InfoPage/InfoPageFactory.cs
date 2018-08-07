using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListItemUI.InfoPage.ViewModels;

namespace ListItemUI.InfoPage
{
    public class InfoPageFactory : IPageFactory
    {

        public IListItemUIViewModel CreatePage()
        {
            return new InfoPageViewModel();
        }
    }
}
