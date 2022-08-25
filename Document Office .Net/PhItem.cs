namespace Document_Office.Net
{
    public class PhItem
    {
        public string _Header { get; set; }
        public string _Body { get; set; }

        public System.Drawing.Color _Color { get; set; }

        public PhItem()
        {
            
        }

        public PhItem(string header, string body)
        {
            _Header = header;
            _Body = body;
        }
    }
}
