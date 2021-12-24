using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xdonr.Models;

namespace xdonr.Fragments
{
    public class AddDonorFragment : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout fullnameText;
        TextInputLayout phoneNr;
        Button saveBtn;
        public event EventHandler<DonorDetailsEventArgs> OnDonorRegistered;
        public class DonorDetailsEventArgs: EventArgs
        {
            public Donor Donor { get; set; }

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.add_new,container,false);
            ConnectView(view);

            return view;
        }

        void ConnectView(View view)
        {
            fullnameText = (TextInputLayout)view.FindViewById(Resource.Id.fullname);
            phoneNr = (TextInputLayout)view.FindViewById(Resource.Id.phone);
            saveBtn = (Button)view.FindViewById(Resource.Id.saveBtn);
            saveBtn.Click += SaveBtn_Click;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            String fullName, phone;
            fullName = fullnameText.EditText.Text;
            phone = phoneNr.EditText.Text;
            var randNr = new Random();
            var tempDonor = new Donor()
            {
                
                BloodGroup = randNr.NextDouble().ToString(),
                City = phone,
                Country = "Random Country",
                Email = "email@email.com",
                FullName = fullName,
                Phone = phone,

            };

            OnDonorRegistered.Invoke(this, new DonorDetailsEventArgs { Donor = tempDonor });



        }
    }
}