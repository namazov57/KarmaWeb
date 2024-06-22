namespace Karma.Infrastructure.Commons
{
    public class EmailOptions
    {
        //public string SmtpServer { get; set; }
        //public short SmtpPort { get; set; }
        //public string FromAddress { get; set; }
        //public string FromName { get; set; }
        //public string Password { get; set; }

        public string DisplayName { get; set; }
        public string SmtpServer { get; set; }
        public short SmtpPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
