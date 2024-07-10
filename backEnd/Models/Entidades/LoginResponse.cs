namespace APITarefas.Models.Entidades
{
    public class LoginResponse
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_In { get; set; }
    }
}
