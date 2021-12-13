using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using xdonr.Models;

namespace xdonr.Adapters
{
    class DonorAdapter : RecyclerView.Adapter
    {
        public event EventHandler<DonorAdapterClickEventArgs> ItemClick;
        public event EventHandler<DonorAdapterClickEventArgs> ItemLongClick;
        List<Donor> DonorsList;

        public DonorAdapter(List<Donor> donorsList)
        {
            DonorsList = donorsList;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);
            itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.donor_row, parent,false);
            var vh = new DonorAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var donor = DonorsList[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as DonorAdapterViewHolder;
            holder.name.Text = donor.FullName;
            holder.location.Text = donor.City +", " + donor.Country;
            holder.name.Text = donor.FullName;
            switch (donor.BloodGroup)
            {
                case "O+":
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.o_positive);
                    break;
                case "A+":
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.a_positive);
                    break;
                case "AB+":
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.ab_positive);
                    break;
                case "AB-":
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.ab_negative);
                    break;
                case "B+":
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.b_positive);
                    break;
                case "A-":
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.a_negative);
                    break;
                default:
                    holder.bloodGroupImage.SetImageResource(Resource.Drawable.o_negative);
                    break;
            }

        }

        public override int ItemCount => DonorsList.Count;

        void OnClick(DonorAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(DonorAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class DonorAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView name;
        public TextView location;
        public ImageView bloodGroupImage;
        public RelativeLayout callLayout;
        public RelativeLayout emailLayout;
        public RelativeLayout deleteLayout;



        public DonorAdapterViewHolder(View itemView, Action<DonorAdapterClickEventArgs> clickListener,
                            Action<DonorAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            name = (TextView)itemView.FindViewById(Resource.Id.donor_name);
            location = (TextView)itemView.FindViewById(Resource.Id.donor_location);
            bloodGroupImage = (ImageView)itemView.FindViewById(Resource.Id.donor_image);
            callLayout = (RelativeLayout)itemView.FindViewById(Resource.Id.call_layout);
            emailLayout = (RelativeLayout)itemView.FindViewById(Resource.Id.email_layout);
            deleteLayout = (RelativeLayout)itemView.FindViewById(Resource.Id.delete_layout);

            itemView.Click += (sender, e) => clickListener(new DonorAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new DonorAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class DonorAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}