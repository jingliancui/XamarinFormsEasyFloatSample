using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Com.Lzf.Easyfloat;
using Xamarin.Forms;
using Com.Lzf.Easyfloat.Permission;
using Com.Lzf.Easyfloat.Interfaces;
using Com.Lzf.Easyfloat.Enums;

namespace SampleApp.Droid
{
    [Activity(Label = "SampleApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,IOnPermissionResult
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            MessagingCenter.Subscribe<object>(this, MainPage.RequestPermission, _ =>
            {
                PermissionUtils.RequestPermission(this, this);
            });
            
            MessagingCenter.Subscribe<object>(this, MainPage.DoShowFloat, _ =>
            {
                EasyFloat
                .With(this)
                .SetShowPattern(ShowPattern.AllTime)
                .SetLayout(Resource.Layout.FloatLayout)
                .Show();
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void PermissionResult(bool isOpen)
        {
            Console.WriteLine(isOpen.ToString());
        }
    }
}