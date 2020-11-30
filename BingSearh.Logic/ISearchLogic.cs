namespace BingSearh.Logic
{
    public interface ISearchLogic
    {
        int GetUrlOccurencesBySearchToken(string searchToken, string url);
    }
}

