using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using static BCrypt.Net.BCrypt;

namespace AvonalleRegisterApi.Domain.Models;
public class User
{
    protected User() { }

    public User(string logon, string password)
    {
        Logon = logon;
        Password = password;
    }

    public int Id { get; set; }
    public string Logon { get; set; }
    public string Password { get; set; }

    //Realiza a encriptação da senha do usuário
    public void EncryptPassword()
    {
        Password = HashPassword(Password, 10);
    }

    //Valida a senha no login
    public bool ValidatePassword(string password)
    {
        var result = Verify(password, Password);
        return result;
    }
}
