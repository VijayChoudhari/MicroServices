using System;
using System.IO;
using System.Net;

namespace BingSearch.Repository
{
    public class SearchRepository : ISearchRepository
    {
        public string FetchSearchResults(string searchUrl)
        {
            var retVal = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(searchUrl);
 
            using (var response = request.GetResponse())
            using (var receiveStream = response.GetResponseStream())
            using (var readStream = new StreamReader(receiveStream))
            {
                retVal = readStream.ReadToEnd();
            }

            return retVal;
        }
    }
}
