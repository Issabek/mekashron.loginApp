namespace mekashron.loginApp.Client.Models
{
    public class Response
    {
        public IEnumerable<string> Errors { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
