using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public const string DoShowFloat = "DoShowFloat";

        public const string RequestPermission = "RequestPermission";

        public const string DoDismissFloat = "DoDismissFloat";

        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowFloatBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new object(), DoShowFloat);
        }

        private void PermissionBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new object(), RequestPermission);
        }

        private void DismissBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new object(), DoDismissFloat);
        }
    }
}
