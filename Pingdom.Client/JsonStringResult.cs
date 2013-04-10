namespace Pingdom.Client
{
    using Newtonsoft.Json;

    public class JsonStringResult
    {
        private readonly string _actionResponse;

        public override string ToString()
        {
            return _actionResponse;
        }

        public object ToObject()
        {
            return JsonConvert.DeserializeObject(_actionResponse);
        }

        public JsonStringResult(string actionResponse)
        {
            _actionResponse = actionResponse;
        }
    }
}