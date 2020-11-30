using GoogleSearch.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Configuration;

namespace GoogleSearch.Logic
{
    public class SearchLogic : ISearchLogic
    {
        public SearchLogic(ISearchRepository searchRepository, IConfiguration iconfig)
        {
            SearchRepository = searchRepository;

            if (iconfig == null)
            {
                throw new Exception("Application configuration not found");
            }

            SearchEngineUrl = iconfig.GetSection("SearchConfiguration")?.GetSection("SearchEngineUrl")?.Value;
            if (string.IsNullOrEmpty(SearchEngineUrl))
            {
                throw new Exception("Application: SearchEngineUrl configuration not found");
            }

            ResultCount = iconfig.GetSection("SearchConfiguration")?.GetSection("ResultCount")?.Value;
            if (string.IsNullOrEmpty(ResultCount))
            {
                throw new Exception("Application: ResultCount configuration not found");
            }
        }

        public ISearchRepository SearchRepository { get; }
        public string SearchEngineUrl { get; }
        public string ResultCount{ get; }

        private string ConstructSearchUrl(string searchToken, string url)
        {
            var retVal = string.Empty;
            retVal = SearchEngineUrl + searchToken;//Note : Result count handling is yet to be implemented for Google Search [Cookie]
            return retVal;
        }

        public int GetUrlOccurencesBySearchToken(string searchToken, string url)
        {
            var retVal = 0;
            var searchUrl = ConstructSearchUrl(searchToken,url);
            var responce = SearchRepository.FetchSearchResults(searchUrl);
            retVal = GetOccurenceCount(responce, url);

            return retVal;
        }

        private int GetOccurenceCount(string resoponse, string url)
        {
            var retVal = 0;

            if (String.IsNullOrEmpty(resoponse))
                throw new ArgumentException("No responce from Google search engine");

            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("No url to search");

            int occurenceCount = 0;
            for (int index = 0; index < resoponse.Length; index += url.Length)
            {
                index = resoponse.IndexOf(url, index);
                if (index == -1)
                {
                    retVal = occurenceCount;
                    break;
                }

                ++occurenceCount;
            }
            return retVal;
        }
    }
}
