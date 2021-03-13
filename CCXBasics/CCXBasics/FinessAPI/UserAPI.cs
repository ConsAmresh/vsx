using CCXCommonServices.Common;
using CCXModels;
using CCXModels.domain.UserModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace CCXBasics.cisco.FinessAPI
{
    public class UserAPI
    {
        public int GetNotReadyReasonCodeList()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            List<AgentVisibleStatus> codes = new List<AgentVisibleStatus>();
            WebRequest request = WebRequest.Create("https://ciscodemo.comm100.io:443/finesse/api/ReasonCodes?category=NOT_READY");
            string responseFromServer = string.Empty;
            var reasonCode = 0;
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

                ReasonCodes rc = (ReasonCodes)serializer.Deserialize(reader);
                Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();

                foreach (var items in rc.ReasonCode)
                {
                    if (items.systemCode == false)
                    {
                        codes.Add(new AgentVisibleStatus
                        {
                            statusId = items.uri.Substring(items.uri.LastIndexOf('/') + 1),
                            statusName = items.label
                        });
                    }
                }

                if (codes.Count == 0)
                {
                    codes.Add(new AgentVisibleStatus
                    {
                        statusId = "0",
                        statusName = "NOT_READY"
                    });
                }

                return reasonCode;
            }
            catch (WebException e1)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string GetFinesseUserList()
        {
            WebRequest request = WebRequest.Create("http://183.129.213.10:7777/finesse/api/Users");
            string responseFromServer = string.Empty;
            try
            {
                request.Method = HttpMethod.Get.ToString();
                request.Timeout = 7000;
                request.Headers.Add("access-control-allow-credentials", "true");
                request.Headers.Add("access-control-allow-origin", "*");
                request.Credentials = new NetworkCredential("cfadmin", "Cisco@2020");
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
                string s = e1.Message;
            }
            catch (Exception e)
            {
                throw;
            }
            return responseFromServer;
        }

        public string GetResource()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            WebRequest request = WebRequest.Create("https://hq-uccx.abc.inc/adminapi/resource");
            string responseFromServer = string.Empty;
            try
            {
                request.Method = HttpMethod.Get.ToString();
                request.ContentType = "application/xml";
                request.Timeout = 7000;
                request.Headers.Add("access-control-allow-credentials", "true");
                request.Headers.Add("access-control-allow-origin", "*");
                request.Credentials = new NetworkCredential("administrator", "ciscopsdt");
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

            }
            catch (Exception e)
            {
                throw;
            }
            return responseFromServer;
        }//End

        public HttpStatusCode GetUCCXUserStatus()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            WebRequest request = WebRequest.Create("https://finesse.ipcc.com:443/finesse/api/User/5002");
            string responseFromServer = string.Empty;
            try
            {
                request.Method = HttpMethod.Get.ToString();
                request.Timeout = 7000;
                request.Headers.Add("access-control-allow-credentials", "true");
                request.Headers.Add("access-control-allow-origin", "*");
                request.Credentials = Utility.GetCredentials("NTAwMjoxMjM0");
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

    }
}
