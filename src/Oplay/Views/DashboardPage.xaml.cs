using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Oplay.Models.Response;
using Oplay.ViewModels;

namespace Oplay.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        void Handle_ItemSelected_1(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var itemSelected = (EmployeeResponse)e.SelectedItem;

            if (itemSelected != null)
            {
                (BindingContext as DashboardPageViewModel).GoToEmployeeDetailCommand.Execute(itemSelected);

                (sender as ListView).SelectedItem = null;
            }
        }
    }
}
