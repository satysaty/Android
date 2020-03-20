using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Company.Models;
using Company.Services;
using Plugin.Connectivity;
using Plugin.Settings;

namespace Company.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IMainCategoryData<MainCategory> MainCategoryData
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                    return new MainCategoryDebug();
                else
                    return new MainCategoryData();
            }
        }

        public ICategoryData<Category> CategoryData
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                    return new CategoryDebug();
                else
                    return new CategoryData();
            }
        }

        public IMasterData<Master> MasterData
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                    return new MasterDebug();
                else
                    return new MasterData();
            }
        }

        public IWorkData<Work> WorkData
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                    return new WorkDebug();
                else
                    return new WorkData();
            }
        }

        public IOptionData<Option> OptionData
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                    return new OptionDebug();
                else
                    return new OptionData();
            }
        }

        public IOptionData<WorkOption> WorkOptionData
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                    return new WorkOptionDebug();
                else
                    return new WorkOptionData();
            }
        }

        public RepairData RepairData
        {
            get
            {
                 return new RepairData();
            }
        }

        public IMainCategoryData<MainCategory> MainCategoryStore => DependencyService.Get<IMainCategoryData<MainCategory>>() ?? MainCategoryData;

        public ICategoryData<Category> CategoryStore => DependencyService.Get<ICategoryData<Category>>() ?? CategoryData;

        public IWorkData<Work> WorkStore => DependencyService.Get<IWorkData<Work>>() ?? WorkData;

        public IMasterData<Master> MasterStore => DependencyService.Get<IMasterData<Master>>() ?? MasterData;

        public IOptionData<Option> OptionStore => DependencyService.Get<IOptionData<Option>>() ?? OptionData;

        public IOptionData<WorkOption> WorkOptionStore => DependencyService.Get<IOptionData<WorkOption>>() ?? WorkOptionData;

        public RepairData RepairStore => DependencyService.Get<RepairData>() ?? RepairData;

        public City CurrentCity => DependencyService.Get<City>() ?? new City();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
                Content = !isBusy;
            }
        }

        bool content = false;
        public bool Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }

        bool errorVisible = false;
        public bool ErrorVisible
        {
            get { return errorVisible; }
            set { SetProperty(ref errorVisible, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        bool internet = false;
        public bool Internet
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
