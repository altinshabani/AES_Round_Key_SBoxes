using System;

namespace AES_Round_Key_SBoxes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestAES();
            Console.WriteLine();
            //TestTextAES();
        }

        public static void TestAES()
        {
            Console.WriteLine("Some test encryption and decryption of real AES (plaintext and keys set to all zero):");
            var aes = new AES();

            Console.WriteLine("AES-128:");
            byte[] key = { 0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76 };
            byte[] data = { 0x62, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76 };

            //    byte[] key = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //    byte[] data = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            data = aes.Encrypt128(data, key);
            Console.WriteLine(AES.ToHex(data));
            data = aes.Decrypt128(data, key);
            Console.WriteLine(AES.ToHex(data));

            Console.WriteLine("AES-192:");
            key = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            data = aes.Encrypt192(data, key);
            Console.WriteLine(AES.ToHex(data));
            data = aes.Decrypt192(data, key);
            Console.WriteLine(AES.ToHex(data));

            Console.WriteLine("AES-256:");
            key = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            data = aes.Encrypt256(data, key);
            Console.WriteLine(AES.ToHex(data));
            data = aes.Decrypt256(data, key);
            Console.WriteLine(AES.ToHex(data));

            // AES-512 -- not specified, but can be created :-)
            Console.WriteLine("AES-512:");
            key = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            data = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            data = aes.Encrypt(data, key, 28);
            Console.WriteLine(AES.ToHex(data));
            data = aes.Decrypt(data, key, 28);
            Console.WriteLine(AES.ToHex(data));
            Console.ReadKey();
        }
        public static void TestTextAES()
        {
            Console.WriteLine("Some test encryption and decryption of text-based AES:");
            string text, key, ciphertext, plaintext;
            var aes = new TextAES();

            Console.WriteLine("Testing with first key:");
            text = "HELLOWORLDTEXTXXTESTWITHFIRSTKEY";
            key = "AAAAAAAAAAAAAAAA";
            Console.WriteLine(text);
            ciphertext = aes.EncryptECB(text, key);
            Console.WriteLine(ciphertext);
            plaintext = aes.DecryptECB(ciphertext, key);
            Console.WriteLine(plaintext);

            Console.WriteLine("Testing with second key:");
            text = "HELLOXWORLDXTHISXISXAXTESTXOFXMYXTEXTXAESXCIPHER";
            key = "BAAAAAAAAAAAAAAA";
            Console.WriteLine(text);
            ciphertext = aes.EncryptECB(text, key);
            Console.WriteLine(ciphertext);
            plaintext = aes.DecryptECB(ciphertext, key);
            Console.WriteLine(plaintext);

            Console.WriteLine("Testing with random key:");
            text = "HELLOXWORLDXTHISXISXAXTESTXOFXMYXTEXTXAESXCIPHER";
            key = aes.GenerateRandomTextKey();
            Console.WriteLine(text);
            ciphertext = aes.EncryptECB(text, key);
            Console.WriteLine(ciphertext);
            plaintext = aes.DecryptECB(ciphertext, key);
            Console.WriteLine(plaintext);
            Console.ReadKey();
        }
    }
}




        
