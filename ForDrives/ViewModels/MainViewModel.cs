using ForDrives.Services.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ForDrives.Helpers;
using System.Windows;
using WinForm = System.Windows.Forms;
using ForDrives.Services.Interfaces;

namespace ForDrives.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private const string ProductName = "ForDrives";

        public MainViewModel()
        {
            applyVisibilityCommand = new RelayCommand(param => this.ApplyVisibilityAction(), param => true);
            applyAccessibilityCommand = new RelayCommand(param => this.ApplyAccessibilityAction(), param => true);

            applicationTitle = ProductName;
            ReloadSettings();
        }

        #region Common Methods

        private void ReloadSettings()
        {
            CurrentSetting_Visibility = new DrivesVisibilityService().GetCurrentSettings();
            CurrentSetting_Accessibility = new DrivesAccessibilityService().GetCurrentSettings();
        }

        private void ApplySetting(IDrivesService driveService, string userInput, bool isLocalMachine)
        {
            driveService.ForLocalMachine = isLocalMachine;

            if ((!isLocalMachine) && (!driveService.RemoveGlobalSettings()))
            {
                cannotChangeOldSetting();
                return;
            }

            if (driveService.SaveNewSettings(userInput))
                showOK();
            else
                cannotSaveSetting();

            ReloadSettings();
        }

        #endregion

        #region MessageBoxes

        private void cannotSaveSetting()
        {
            WinForm.MessageBox.Show("Cannot write to registry! \n",
                   ProductName, WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error);
        }

        private void cannotChangeOldSetting()
        {
            WinForm.MessageBox.Show("Cannot delete old settings in the registry! \n",
                    ProductName, WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error);
        }

        private void showOK()
        {
            WinForm.MessageBox.Show("Settings applied. Restart explorer.exe to see the effect! ",
                ProductName, WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Information);
        }

        #endregion

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

        public string CurrentSetting_Accessibility
        {
            get
            {
                return currentSetting_Accessibilty;
            }
            set
            {
                currentSetting_Accessibilty = value;
                OnPropertyChanged("CurrentSetting_Accessibility");
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

        private bool localMachineSelected;

        public bool LocalMachineSelected
        {
            get
            {
                return localMachineSelected;
            }
            set
            {
                localMachineSelected = value;
                OnPropertyChanged("LocalMachineSelected");
            }
        }

        #endregion

        #region Binding Commands

        private readonly ICommand applyVisibilityCommand;

        public ICommand ApplyVisibilityCommand
        {
            get
            {
                return applyVisibilityCommand;
            }
        }

        private void ApplyVisibilityAction()
        {
            ApplySetting(new DrivesVisibilityService(), newSetting_Visibility, localMachineSelected);
            ReloadSettings();
        }

        private readonly ICommand applyAccessibilityCommand;

        public ICommand ApplyAccessibilityCommand
        {
            get
            {
                return applyAccessibilityCommand;
            }
        }

        private void ApplyAccessibilityAction()
        {
            ApplySetting(new DrivesAccessibilityService(), newSetting_Accessibility, localMachineSelected);
            ReloadSettings();
        }

        #endregion

    }
}
