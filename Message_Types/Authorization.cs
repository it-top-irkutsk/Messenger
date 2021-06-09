namespace Message_Types
{
    public class Authorization
    {
        string Login { get; set; }
        string Password { get; set; }
        bool Validation { get; set; }
        
        public Authorization() { }
       
        public Authorization(string login, string password, bool validation)
        {
            Login = login;
            Password = password;
            Validation = validation;
        }
    } 
}