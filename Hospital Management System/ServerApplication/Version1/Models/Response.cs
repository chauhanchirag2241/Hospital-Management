namespace ASMSapi.Model
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        

        public object DataList { get; set; }
    }
}
