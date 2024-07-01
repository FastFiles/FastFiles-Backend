namespace FastFiles.Services
{
    public interface IMailerSendRepository
    {
        public void SendMail(string to, string user);
    }
}