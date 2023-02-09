namespace CleanAdArch.Domain.Interface.Utils.PasswordHasher;

public interface IPasswordHasher
{
    string Hash(string password);
  
    bool Check(string hash, string password);
}