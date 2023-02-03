using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.View;
using static Java.Util.Jar.Attributes;

namespace WinDateFrom.Xamarin
{
    public class MyClickListener : Java.Lang.Object, IOnClickListener
    {
        private EditText date, name;
        private TextView result, anniversary;
        private Android.Content.Res.Resources res;

        public MyClickListener(EditText d, EditText n, TextView r, TextView a, Android.Content.Res.Resources re) {
            date = d;
            name = n;
            result = r;
            anniversary= a;
            res = re;
        }
        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
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

        public void SetJniIdentityHashCode(int value)
        {
            throw new NotImplementedException();
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            throw new NotImplementedException();
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            throw new NotImplementedException();
        }

        public void UnregisterFromRuntime()
        {
            throw new NotImplementedException();
        }
    }
}