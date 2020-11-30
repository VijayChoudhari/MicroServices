namespace BingSearch.Repository
{
    public interface ISearchRepository
    {
        string FetchSearchResults(string searchUrl);
    }
}