using System;

namespace CourseWork
{
    public class AESEncryption : IEncryptionStrategy
    {
        public string Encrypt(string data)
        {
            return "AES_Шифр(" + data + ")";
        }
    }

    public class DESEncryption : IEncryptionStrategy
    {
        public string Encrypt(string data)
        {
            return "DES_Шифр(" + data + ")";
        }
    }

    public class NoEncryption : IEncryptionStrategy
    {
        public string Encrypt(string data)
        {
            return data;
        }
    }
}