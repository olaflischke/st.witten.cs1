
namespace HistorischeWaehrungenDal
{
    [Serializable]
    public class HistorischeWaehrungenDalException : Exception
    {
        public HistorischeWaehrungenDalException()
        {
        }

        public HistorischeWaehrungenDalException(string? message) : base(message)
        {
        }

        public HistorischeWaehrungenDalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}