using NUnit.Framework;
using Lab1;
using System.Text;
using System;

namespace Tests
{
    public class TestLab1
    {
        private Cypher Cypher_EN;
        private Cypher Cypher_UA;

        [SetUp]
        public void Setup()
        {
            Cypher_EN = new("abcdefghijklmnopqrstuvwxyz");
            Cypher_UA = new("абвгґдеєжзиіїйклмнопрстуфхцчшщьюя");
        }

        [Test]
        public void Test_Encrypt_EN_Key_1()
        {
            Cypher_EN.KeyInt = 1;
            string PlainText = "Hello world!";
            string EncryptedText = "Ifmmp xpsme!";
            /*StringBuilder EncryptedText = new();
            for (int i = 0; i < PlainText.Length; i++)
            {
                EncryptedText.Append(Convert.ToChar(char.IsLetter(PlainText[i]) ? (PlainText[i] + 1) % 26: PlainText[i]));
            }
            Assert.AreEqual(EncryptedText.ToString(), Cypher_EN.Encrypt(PlainText)); // "Ifmmp xpsme!"*/
            Assert.AreEqual(EncryptedText, Cypher_EN.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_EN_Key_1()
        {
            Cypher_EN.KeyInt = 1;
            string PlainText = "Ifmmp xpsme!"; // "Hello world!"
            string DecryptedText = "Hello world!";
            /*StringBuilder DecryptedText = new();
            for (int i = 0; i < PlainText.Length; i++)
            {
                DecryptedText.Append(Convert.ToChar(char.IsLetter(PlainText[i]) ? (PlainText[i] + 26 - 1) % 26 : PlainText[i]));
            }
            Assert.AreEqual(DecryptedText.ToString(), Cypher_EN.Decrypt(PlainText)); // "Hello world!"*/
            Assert.AreEqual(DecryptedText, Cypher_EN.Decrypt(PlainText));
        }
        [Test]
        public void Test_Encrypt_UA_Key_1()
        {
            Cypher_UA.KeyInt = 1;
            string PlainText = "Привіт світ!";
            string EncryptedText = "Рсігїу тгїу!";
            Assert.AreEqual(EncryptedText, Cypher_UA.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_UA_Key_1()
        {
            Cypher_UA.KeyInt = 1;
            string PlainText = "Рсігїу тгїу!";
            string DecryptedText = "Привіт світ!";
            Assert.AreEqual(DecryptedText, Cypher_UA.Decrypt(PlainText));
        }

        [Test]
        public void Test_Crack_UA_Key_1()
        {
            BruteCracker bruteCracker = new(Cypher_UA, "../../../ua.txt");
            string PlainText = "Рсігїу тгїу!";
            string DecryptedText = "Привіт світ!";
            Assert.AreEqual(DecryptedText, bruteCracker.Crack(PlainText));
        }

        [Test]
        public void Test_Crack_EN_Key_1()
        {
            BruteCracker bruteCracker = new(Cypher_EN, "../../../en.txt");
            string PlainText = "Ifmmp xpsme!";
            string DecryptedText = "Hello world!";
            Assert.AreEqual(DecryptedText, bruteCracker.Crack(PlainText));
        }
    }
}