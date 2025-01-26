using System.Text;

namespace Support;

class Program
{
    static void Main(string[] args)
    {
        // Using the data from the decompiled file: 
        string passwordEncodedAsBase64 = "0Nv32PTwgYjzg9/8j5TbmvPd3e7WhtWWyuPsyO76/Y+U193E";
        byte[] key = Encoding.ASCII.GetBytes("armando");

        byte[] passwordBase64AsByte = Convert.FromBase64String(passwordEncodedAsBase64);
        byte[] passwordAsByte = passwordBase64AsByte;
        for (int i = 0; i < passwordBase64AsByte.Length; i++)
        {
            passwordAsByte[i] = (byte)((uint)(passwordBase64AsByte[i] ^ key[i % key.Length]) ^ 0xDFu);
        }
        string passwordDecoded = Encoding.UTF8.GetString(passwordAsByte);
        Console.WriteLine($"Decoded password: {passwordDecoded}");
    }
}
