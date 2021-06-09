namespace Message_Types
{
    public class Authorization
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Validation { get; set; }
        
        public Authorization() { }

        public Authorization(bool validation)
        {
            Validation = validation;
        }
        public Authorization(string login, string password, bool validation)
        {
            Login = login;
            Password = password;
            Validation = validation;
        }
    } 
}