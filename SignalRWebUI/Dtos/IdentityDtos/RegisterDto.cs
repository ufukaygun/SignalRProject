namespace SignalRWebUI.Dtos.IdentityDtos
{
    //Kayıt olma metodu
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string mail { get; set; }
        public string Password { get; set; }
    }
}
