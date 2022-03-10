using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using Supercharge;
using System.Threading;
using System.Threading.Tasks;
using System;
using Android.Widget;

namespace skeletonview
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        LinearLayout line;
        ShimmerLayout shimmerLayout;    
        List<string> employeenames;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerView recycler;
        recycleradapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            shimmerLayout = FindViewById<ShimmerLayout>(Resource.Id.shimeerlayout);

            line = FindViewById<LinearLayout>(Resource.Id.linear);
            
            recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            employeenames = new List<string> { "sagar", "meet", "manish", "jay", "Aires", "Akash", "Raju", "meet", "manish", "jay", "Aires", "Akash", "Raju", "meet", "manish", "jay", "Aires", "Akash", "Raju" };
            mLayoutManager = new LinearLayoutManager(this);
            
            recycler.SetLayoutManager(mLayoutManager);

            mAdapter = new recycleradapter(employeenames, ApplicationContext);
            recycler.Visibility = Android.Views.ViewStates.Invisible;
            recycler.SetAdapter(mAdapter);
            shimmerLayout.StartShimmerAnimation();
            blocker();
          //  Parallel.Invoke(
          //    () => {
          //        showshimmer(3000);
          //    },
          //    () => {
          //        hideshimmer();
          //    }
          //);

            //var t = Task.Run(async delegate
            //{
            //    shimmerLayout.Visibility = Android.Views.ViewStates.Visible;
            //    shimmerLayout.StartShimmerAnimation();
            //    await Task.Delay(3000);

            //}
            //);

            //System.Threading.Thread.Sleep(3000);

            //shimmerLayout.Visibility = Android.Views.ViewStates.Gone;
            //shimmerLayout.StopShimmerAnimation();
            //recycler.Visibility = Android.Views.ViewStates.Visible;




        }

        
        protected  async void blocker()
        {
          
            await Task.Delay(3000);
            recycler.Visibility = Android.Views.ViewStates.Visible;
            shimmerLayout.StopShimmerAnimation();
            line.Visibility = Android.Views.ViewStates.Invisible;
            }
            

        }
        
    }


