using CCXModels.domain.UserModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CCXBasics.cisco.FinessConfig
{
    public class FinesseConfigs : IFinesseConfigs
    {
        public void GetSystemConfig()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            List<AgentVisibleStatus> codes = new List<AgentVisibleStatus>();
            WebRequest request = WebRequest.Create("https://ciscodemo.comm100.io:443/finesse/api/SystemConfig");
            string responseFromServer = string.Empty;

            XmlSerializer serializer = new XmlSerializer(typeof(ReasonCodes));
            try
            {
                request.Method = HttpMethod.Get.ToString();
                request.Timeout = 7000;
                request.Headers.Add("access-control-allow-credentials", "true");
                request.Headers.Add("access-control-allow-origin", "*");
                request.Credentials = new NetworkCredential("administrator", "Comm100Aa");

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Console.WriteLine(((HttpWebResponse)response).StatusCode);
                Console.WriteLine("Response Received");
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();

            }
            catch (WebException e1)
            {
                Console.WriteLine(e1.Message.ToString());
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public HttpStatusCode GetServerVersionInfo()
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            WebRequest request = WebRequest.Create("https://3.97.135.84:443/finesse-dp/rest/DiagnosticPortal/GetProductVersion");
            string responseFromServer = string.Empty;
            try
            {
                request.Method = HttpMethod.Get.ToString();
                request.Timeout = 7000;
                request.Headers.Add("access-control-allow-credentials", "true");
                request.Headers.Add("access-control-allow-origin", "*");
                request.Credentials = new NetworkCredential("administrator", "Comm100Aa");
                request.ContentType = "application/x-www-form-urlencoded";
                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Console.WriteLine(((HttpWebResponse)response).StatusCode);
                Console.WriteLine("Response Received");
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();

                byte[] byteArray = Encoding.ASCII.GetBytes(responseFromServer);
                MemoryStream memstream = new MemoryStream(byteArray);
                var xmldocument = new XmlDocument();
                xmldocument.Load(memstream);
                XmlElement root = xmldocument.DocumentElement;
                var nsmgr = new XmlNamespaceManager(xmldocument.NameTable);
                nsmgr.AddNamespace("dp", "http://www.cisco.com/vtg/diagnosticportal");
                XmlNode snode = root.SelectSingleNode("dp:ProductVersion", nsmgr);
                string sver = snode.Attributes["VersionString"].Value;

                return ((System.Net.HttpWebResponse)response).StatusCode;
            }
            catch (WebException e1)
            {
                return HttpStatusCode.BadRequest;
            }
            catch (Exception e)
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public HttpStatusCode UpdateStatus(string status)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://finesse.ipcc.com:443/finesse/api/User/5002");
            string responseFromServer = string.Empty;
            //string reqData = "<User><state>"+ status + "</state><reasonCodeId>20003</reasonCodeId></User>";
            string reqData = "<User><state>" + status + "</state></User>";
            try
            {
                request.Method = "PUT";
                request.Timeout = 7000;
                request.KeepAlive = true;
                request.Headers.Add("access-control-allow-credentials", "true");
                request.Headers.Add("access-control-allow-origin", "*");
                request.ContentType = "application/xml";
                request.Credentials = new NetworkCredential("5002", "1234");

                byte[] data = Encoding.UTF8.GetBytes(reqData);

                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Console.WriteLine(((HttpWebResponse)response).StatusCode);
                Console.WriteLine("Response Received");

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
                return ((System.Net.HttpWebResponse)response).StatusCode;
            }
            catch (WebException e1)
            {

                return HttpStatusCode.BadRequest;
            }
            catch (Exception e)
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public void SendHTTPRequest()
        {
            string response = string.Empty;
            string data = string.Format("<User><state>READY</state></User>");
            string method = "PUT";
            string mUri = string.Format("http://183.129.213.10:7777/finesse/api/User/{0}", "703");


            string mAuth = string.Format("{0}:{1}", "amresh", "Aa000000");
            string mB64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(mAuth));
            string _AuthHeader = string.Format("{0} {1}", "Basic", mB64String);


            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyError6t5s) { return true; };
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.Authorization, _AuthHeader);
                wc.Headers.Add("Content-Type", "application/XML");
                response = wc.UploadString(mUri, method, data);
            }
            catch (Exception ex)
            {

            }

        }

    }
}
