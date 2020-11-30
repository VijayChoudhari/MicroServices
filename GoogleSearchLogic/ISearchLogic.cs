namespace GoogleSearch.Logic
{
    public interface ISearchLogic
    {
        int GetUrlOccurencesBySearchToken(string searchToken, string url);
    }
}
