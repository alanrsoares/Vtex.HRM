namespace Pingdom.Client
{
    using ServiceStack.Text;

    public class JsonStringResult
    {
        private readonly string _actionResponse;

        public override string ToString()
        {
            return _actionResponse;
        }

        public object ToObject()
        {
            return _actionResponse.FromJson<JsonObject>();
        }

        public JsonStringResult(string actionResponse)
        {
            _actionResponse = actionResponse;
        }
    }
}