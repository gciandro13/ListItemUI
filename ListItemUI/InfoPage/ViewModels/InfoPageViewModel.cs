using System;

namespace ListItemUI.InfoPage.ViewModels
{
    public class InfoPageViewModel : ViewModelBase, IListItemUIViewModel
    {

        public string Info
        {
            get { return "2018. All rights reserved to" +
                         "\nDeveloper: Ciandrini Giovanni"; }

            set {  }
        }

        public bool checkIfListIsNull()
        {
            throw new NotImplementedException();
        }

        public bool clearElements()
        {
            throw new NotImplementedException();
        }

        public void closePage()
        {
            throw new NotImplementedException();
        }
    }
}