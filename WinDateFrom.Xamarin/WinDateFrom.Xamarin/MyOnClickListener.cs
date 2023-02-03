using Android.Content.Res;
using Android.Views;
using Android.Widget;

namespace WinDateFrom.Xamarin
{
    internal class MyOnClickListener : Java.Lang.Object, View.IOnClickListener
    {
        EditText date, name;
        TextView result, anniversary;
        Resources res;

        public MyOnClickListener(EditText d, EditText n, TextView r, TextView a, Resources re)
        {
            date = d;
            name = n;
            result = r;
            anniversary = a;
            res = re;
        }
        public void OnClick(View v)
        {
            Java.Util.Date d = new Java.Util.Date();
            Java.Util.Date d1;
            anniversary.Text = "";
            result.Text = "";
            try
            {
                d1 = new Java.Util.Date(date.Text);
            }
            catch (Java.Lang.IllegalArgumentException ex)
            {
                result.Text = res.GetString(Resource.String.invalid_rvalue);
                return;
            }
            long diff = d.Time - d1.Time;
            diff = diff / (1000 * 3600 * 24);
            result.Text = res.GetString(Resource.String.you_meet) + " " + name.Text + " " + res.GetString(Resource.String.about) + " " + diff.ToString() + " " + res.GetString(Resource.String.days_ago) + ".";
            if (d.GetDate() == d1.GetDate())
                if (d.Month == d1.Month)
                    anniversary.Text = res.GetString(Resource.String.is_your_anniversary);
                else
                    anniversary.Text = res.GetString(Resource.String.is_your_mesiversary);
        }
    }
}