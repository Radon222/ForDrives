using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ForDrives.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string applicationTitle;

        public string ApplicationTitle
        {
            get { return applicationTitle; }
            set
            {
                if (applicationTitle != value)
                {
                    applicationTitle = value;
                    OnPropertyChanged("ApplicationTitle");
                }
            }
        }

        public MainViewModel()
        {
            applicationTitle = "ForDrives";
        }
    }
}
