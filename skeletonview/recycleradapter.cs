using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace skeletonview
{
    class recycleradapter : RecyclerView.Adapter
    {

        Context con;
        private readonly string[] spaceCrafts;
        public event EventHandler<int> itemClick;
        public List<string> employeenames;

        public recycleradapter(List<string> employeenames, Context context)
        {
            this.employeenames = employeenames;
            con = context;
        }

        //public override int ItemCount => throw new NotImplementedException();
        public override int ItemCount
        {
            get { return employeenames.Count; }
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder vh = holder as MyViewHolder;

            //vh.textView.Text = employeenames[position].ToString();
            vh.textView.Click += delegate {
                Toast.MakeText(con, "message", ToastLength.Long).Show();
            };
        }



        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.rowitem, parent, false);
            MyViewHolder vh = new MyViewHolder(itemView);
            return vh;
        }



        public class MyViewHolder : RecyclerView.ViewHolder
        {
            private readonly Action<int> listener;
            public TextView textView;
            public MyViewHolder(View itemView) : base(itemView)
            {

                textView = itemView.FindViewById<TextView>(Resource.Id.textitem);


            }


        }

    }
}