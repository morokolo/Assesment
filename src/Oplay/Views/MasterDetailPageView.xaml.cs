using System;
using Xamarin.Forms;

namespace Oplay.Views
{
    public partial class MasterDetailPageView: MasterDetailPage
    {
        public MasterDetailPageView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.IsPresented = false;
        }
    }
}
