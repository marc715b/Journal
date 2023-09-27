using System.Security.Cryptography;
using System.Text;

public class Encryption {
    private Aes _aes;
    private ICryptoTransform _encryptor;
    private ICryptoTransform _decryptor;
    private SHA256 _sha256;
    private byte[] _password;

    public Encryption() {
        _sha256 = SHA256.Create();

        PromptPassword();

        _aes = Aes.Create();
        _aes.Key = _password;
        _aes.IV = new byte[16];

        _encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
        _decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);

    }

    private byte[] GetSHA256(string input)
        => _sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

    private string DigestBytes(byte[] input) {
        string digest = string.Empty;
        
        foreach (byte b in input)
            digest += string.Format("{0:x2}", b);
        
        return digest;
    }

    private void PromptPassword() {
        string correct = File.ReadAllText("PasswordHash.txt");

        Console.Clear();
        Utils.WriteColor("(hint: koden er \"secret\")", ConsoleColor.Gray);

        byte[] hashed;
        while (true) {
            hashed = GetSHA256(Utils.Prompt("Password: "));
            
            if (DigestBytes(hashed) == correct) {
                _password = hashed;
                break;
            }
            
            Utils.WriteColor("Incorrect!", ConsoleColor.Red);
        }
    }

    public string Encrypt(string input) {
        byte[] encrypted;
        using (MemoryStream mem = new MemoryStream()) {
            using (CryptoStream crypto = new CryptoStream(mem, _encryptor, CryptoStreamMode.Write)) {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                crypto.Write(bytes, 0, bytes.Length);
            }
            encrypted = mem.ToArray();
        }
        return Convert.ToBase64String(encrypted);
    }

    public string Decrypt(string input) {
        byte[] encrypted = Convert.FromBase64String(input);
        byte[] decrypted;
        using (MemoryStream mem = new MemoryStream(encrypted)) {
            using (CryptoStream crypto = new CryptoStream(mem, _decryptor, CryptoStreamMode.Read)) {
                using (MemoryStream plain = new MemoryStream()) {
                    crypto.CopyTo(plain);
                    decrypted = plain.ToArray();
                }
            }
        }
        return Encoding.UTF8.GetString(decrypted);
    }
}