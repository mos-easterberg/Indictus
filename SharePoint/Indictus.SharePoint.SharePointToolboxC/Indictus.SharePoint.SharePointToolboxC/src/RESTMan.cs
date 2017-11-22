
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Net.Http;


namespace Indictus.SharePoint.SharePointToolboxC
{
    public class RESTMan
    {
        public static SharePointOnlineCredentials CreateCredentials(String sUser, String sPwd)
        {                        
            var passWord = new SecureString();
            foreach (var c in sPwd) passWord.AppendChar(c);
            var credential = new SharePointOnlineCredentials(sUser, passWord);

            return credential;
        }

        public static HttpClient GetClient(String webUrl, SharePointOnlineCredentials credential)
        {
            //Creating Handler to allow the client to use credentials and cookie
            var handler = new HttpClientHandler() { Credentials = credential };

            //Getting authentication cookies
            Uri uri = new Uri(webUrl);
            handler.CookieContainer.SetCookies(uri, credential.GetAuthenticationCookie(uri));

            //Invoking REST API
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static async Task<String> GetData(HttpClient client, String sUrl, String sRestCommand)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(string.Format(sRestCommand, sUrl)).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string jsonData = await response.Content.ReadAsStringAsync();
                return jsonData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //===================================================
        public static async Task<String> GetListItems(HttpClient client, String sUrl, String sListName)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(string.Format("{0}/_api/web/lists/GetByTitle('" + sListName + "')/items", sUrl)).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                String s = await response.Content.ReadAsStringAsync();
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
