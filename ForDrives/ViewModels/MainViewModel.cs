using ForDrives.Services.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ForDrives.Helpers;
using System.Windows;

namespace ForDrives.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            applicationTitle = "ForDrives";
            ReloadSettings();
        }

        private void ReloadSettings()
        {
            currentSetting_Visibility = new DrivesVisibilityService().GetCurrentSettings();
            currentSetting_Accessibilty = new DrivesAccessibilityService().GetCurrentSettings();
        }

        #region Binding Properties

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

        private string currentSetting_Accessibilty;

        public string CurrentSetting_Accessibilty
        {
            get
            {
                return currentSetting_Accessibilty;
            }
            set
            {
                currentSetting_Accessibilty = value;
                OnPropertyChanged("DrivesAccessibiltyCurrentSetting");
            }
        }

        private string currentSetting_Visibility;

        public string CurrentSetting_Visibility
        {
            get
            {
                return currentSetting_Visibility;
            }
            set
            {
                currentSetting_Visibility = value;
                OnPropertyChanged("CurrentSetting_Visibility");
            }
        }

        private string newSetting_Visibility;

        public string NewSetting_Visibility
        {
            get
            {
                return newSetting_Visibility;
            }
            set
            {
                newSetting_Visibility = value;
                OnPropertyChanged("NewSetting_Visibility");
            }
        }

        private string newSetting_Accessibility;

        public string NewSetting_Accessibility
        {
            get
            {
                return newSetting_Accessibility;
            }
            set
            {
                newSetting_Accessibility = value;
                OnPropertyChanged("NewSetting_Accessibility");
            }
        }

        #endregion

        #region Binding Commands

        private ICommand applyVisibilityCommand;

        public ICommand ApplyVisibilityCommand
        {
            get
            {
                return (applyVisibilityCommand ?? (applyVisibilityCommand = new CommandHandler(() => ApplyVisibilityAction(), true)));
            }
        }
        
        private void ApplyVisibilityAction()
        {
            MessageBox.Show("Visibility");
        }
        
        private ICommand applyAccessibilityCommand;

        public ICommand ApplyAccessibilityCommand
        {
            get
            {
                return (applyAccessibilityCommand ?? (applyAccessibilityCommand = new CommandHandler(() => ApplyAccessibilityAction(), true)));
            }
        }
        
        private void ApplyAccessibilityAction()
        {
            MessageBox.Show("Access");
        }
        
        #endregion

    }
}
