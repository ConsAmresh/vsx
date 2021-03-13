using S22.Xmpp.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCXBasics.cisco.XMPPConnection
{
    public class ManageXMPPConnection
    {
        public void ConnectXMPP()
        {
            var client = new XmppClient("ciscodemo.comm100.io", 5222, false);
            try
            {
                client.Error += Client_Error;
                client.Connect();
                client.Authenticate("5002", "1234");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                client.Close();
            }
        }

        private void Client_Error(object sender, S22.Xmpp.Im.ErrorEventArgs e)
        {
            string s = e.Reason;
        }
    }
}
