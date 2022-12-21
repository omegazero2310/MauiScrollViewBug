using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiScrollViewBug.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implement
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a property already matches a desired value. Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Checks if a property already matches a desired value. Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <param name="onChanged">Action that is called after the property value has been changed.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="args">The PropertyChangedEventArgs</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
        #endregion
        public MainPageViewModel()
        {
            CreateSampleData();
        }
        private List<MenuItem> _menuItems = new List<MenuItem>();
        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }
        private void CreateSampleData()
        {
            //ImageSource Credit https://www.svgrepo.com/collection/digital-nomad-lifestyle-vectors/
            MenuItems.Add(new MenuItem()
            {
                SubItems = new List<MenuSubItem>()
                {
                    new MenuSubItem() 
                    {
                        IconName = "backpack_svgrepo_com.png",
                        Title = "Item 1"
                    },
                    new MenuSubItem()
                    {
                        IconName = "coffee_svgrepo_com.png",
                        Title = "Item 2"
                    },
                    new MenuSubItem()
                    {
                        IconName = "dotnet_bot.png",
                        Title = "Item 3"
                    },
                }
            });
            //MenuItems.Add(new MenuItem()
            //{
            //    SubItems = new List<MenuSubItem>()
            //    {
            //        new MenuSubItem()
            //        {
            //            IconName = "laptop_svgrepo_com.png",
            //            Title = "Item 4"
            //        },
            //        new MenuSubItem()
            //        {
            //            IconName = "phone_svgrepo_com.png",
            //            Title = "Item 5"
            //        },
            //        new MenuSubItem()
            //        {
            //            IconName = "dotnet_bot.png",
            //            Title = "Item 6"
            //        },
            //    }
            //});
            //MenuItems.Add(new MenuItem()
            //{
            //    SubItems = new List<MenuSubItem>()
            //    {
            //        new MenuSubItem()
            //        {
            //            IconName = "suitcase_svgrepo_com.png",
            //            Title = "Item 7"
            //        },
            //        new MenuSubItem()
            //        {
            //            IconName = "surfboard_svgrepo_com.png",
            //            Title = "Item 8"
            //        },
            //        new MenuSubItem()
            //        {
            //            IconName = "van_svgrepo_com.png",
            //            Title = "Item 9"
            //        },
            //    }
            //});
        }
    }
}
