using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using xdonr.Adapters;
using System.Collections.Generic;
using xdonr.Models;
using System;
using System.Linq;
using Android.Support.Design.Widget;

namespace xdonr
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView donorsRecyclerView;
        DonorAdapter donorAdapter;
        List<Donor> donorsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SupportActionBar.Title = "Blood Donors";
            donorsRecyclerView = (RecyclerView)FindViewById(Resource.Id.donor_recycler_view);
            FloatingActionButton fab = (FloatingActionButton)FindViewById(Resource.Id.fab);
            fab.Click += Fab_Click;
            CreateData();
            SetUpRecyclerView();
        }

        private void Fab_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Floainf action button clicked", ToastLength.Short).Show();
        }

        void CreateData()
        {
            donorsList = new List<Donor>();
            donorsList.Add(new Donor { BloodGroup = "A+", City = "Borås", Country = "Sweden", Email = "hehe@hehe.se", FullName = "visxxousxoua", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "B+", City = "fristad", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Ankan nakin", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "B-", City = "Hillared", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Manen manen", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "AB+", City = "jamaren", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Pita mein bruda", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "AB-", City = "Borås", Country = "Sweden", Email = "hehe@hehe.se", FullName = "visxxousxoua", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "O-", City = "fristad", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Ankan nakin", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "O+", City = "Hillared", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Manen manen", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "AB+", City = "jamaren", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Pita mein bruda", Phone = "0707070707" }); donorsList.Add(new Donor { BloodGroup = "A", City = "Borås", Country = "Sweden", Email = "hehe@hehe.se", FullName = "visxxousxoua", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "A-", City = "fristad", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Ankan nakin", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "AB+", City = "Hillared", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Manen manen", Phone = "0707070707" });
            donorsList.Add(new Donor { BloodGroup = "O+", City = "jamaren", Country = "Sweden", Email = "hehe@hehe.se", FullName = "Pita mein bruda", Phone = "0707070707" });

        }

        void SetUpRecyclerView()
        {
            donorsRecyclerView.SetLayoutManager(new LinearLayoutManager(donorsRecyclerView.Context));
            donorAdapter = new DonorAdapter(donorsList);
            donorAdapter.EmailClick += DonorsAdapter_EmailClick;
            donorAdapter.CallClick += DonorsAdapter_CallClick;

            donorsRecyclerView.SetAdapter(donorAdapter);
        }

        private void DonorsAdapter_CallClick(object sender, DonorAdapterClickEventArgs e)
        {
            var donor = donorsList.Single(d => d.BloodGroup == donorsList[e.Position].BloodGroup);
            donorsList.RemoveAt(e.Position);
            donorAdapter.NotifyDataSetChanged();
        }

        private void DonorsAdapter_EmailClick(object sender, DonorAdapterClickEventArgs e)
        {
            Toast.MakeText(this, "email was clicked", ToastLength.Short).Show();

        }
    }
}