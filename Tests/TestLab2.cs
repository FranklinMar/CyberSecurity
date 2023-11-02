using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lab2;

namespace Tests
{
    class TestLab2
    {
        private TrithemiusCypher Cypher_EN;
        private TrithemiusCypher Cypher_UA;

        [SetUp]
        public void Setup()
        {
            Cypher_EN = new("abcdefghijklmnopqrstuvwxyz");
            Cypher_UA = new("абвгґдеєжзиіїйклмнопрстуфхцчшщьюя");
        }

        [Test]
        public void Test_Encrypt_EN_ASC()
        {
            Cypher_EN.Key = Cypher_EN.ASCENDING;
            string PlainText = "Hello world!";
            string EncryptedText = "Hfnos buytm!";
            /*StringBuilder EncryptedText = new();
            for (int i = 0; i < PlainText.Length; i++)
            {
                EncryptedText.Append(Convert.ToChar(char.IsLetter(PlainText[i]) ? (PlainText[i] + 1) % 26: PlainText[i]));
            }
            Assert.AreEqual(EncryptedText.ToString(), Cypher_EN.Encrypt(PlainText)); // "Ifmmp xpsme!"*/
            Assert.AreEqual(EncryptedText, Cypher_EN.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_EN_ASC()
        {
            Cypher_EN.Key = Cypher_EN.ASCENDING;
            string PlainText = "Hfnos buytm!"; // "Hello world!"
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
        public void Test_Encrypt_EN_DESC()
        {
            Cypher_EN.Key = Cypher_EN.DESCENDING;
            string PlainText = "Hello world!";
            string EncryptedText = "Gcihj qhjct!";
            /*StringBuilder EncryptedText = new();
            for (int i = 0; i < PlainText.Length; i++)
            {
                EncryptedText.Append(Convert.ToChar(char.IsLetter(PlainText[i]) ? (PlainText[i] + 1) % 26: PlainText[i]));
            }
            Assert.AreEqual(EncryptedText.ToString(), Cypher_EN.Encrypt(PlainText)); // "Ifmmp xpsme!"*/
            Assert.AreEqual(EncryptedText, Cypher_EN.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_EN_DESC()
        {
            Cypher_EN.Key = Cypher_EN.DESCENDING;
            string PlainText = "Gcihj qhjct!"; // "Hello world!"
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
        public void Test_Encrypt_UA_ASC()
        {
            Cypher_UA.Key = Cypher_UA.ASCENDING;
            string PlainText = "Привіт світ!";
            string EncryptedText = "Псїдлч чзпю!";
            Assert.AreEqual(EncryptedText, Cypher_UA.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_UA_ASC()
        {
            Cypher_UA.Key = Cypher_UA.ASCENDING;
            string PlainText = "Псїдлч чзпю!";
            string DecryptedText = "Привіт світ!";
            Assert.AreEqual(DecryptedText, Cypher_UA.Decrypt(PlainText));
        }

        [Test]
        public void Test_Encrypt_UA_DESC()
        {
            Cypher_UA.Key = Cypher_UA.DESCENDING;
            string PlainText = "Привіт світ!";
            string EncryptedText = "Ооєюем кчвї!";
            Assert.AreEqual(EncryptedText, Cypher_UA.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_UA_DESC()
        {
            Cypher_UA.Key = Cypher_UA.DESCENDING;
            string PlainText = "Ооєюем кчвї!";
            string DecryptedText = "Привіт світ!";
            Assert.AreEqual(DecryptedText, Cypher_UA.Decrypt(PlainText));
        }

        [Test]
        public void Test_Encrypt_EN_KEY()
        {
            Cypher_EN.Key = "hello";
            string PlainText = "Hello world!";
            string EncryptedText = "Oiwwc dscwr!";
            /*StringBuilder EncryptedText = new();
            for (int i = 0; i < PlainText.Length; i++)
            {
                EncryptedText.Append(Convert.ToChar(char.IsLetter(PlainText[i]) ? (PlainText[i] + 1) % 26: PlainText[i]));
            }
            Assert.AreEqual(EncryptedText.ToString(), Cypher_EN.Encrypt(PlainText)); // "Ifmmp xpsme!"*/
            Assert.AreEqual(EncryptedText, Cypher_EN.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_EN_KEY()
        {
            Cypher_EN.Key = "hello";
            string PlainText = "Oiwwc dscwr!"; // "Hello world!"
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
        public void Test_Encrypt_UA_KEY()
        {
            Cypher_UA.Key = "світ";
            string PlainText = "Привіт світ!";
            string EncryptedText = "Єтсфяф яфяф!";
            Assert.AreEqual(EncryptedText, Cypher_UA.Encrypt(PlainText));
        }

        [Test]
        public void Test_Decrypt_UA_KEY()
        {
            Cypher_UA.Key = "світ";
            string PlainText = "Єтсфяф яфяф!"; // "Hello world!"
            string DecryptedText = "Привіт світ!";
            Assert.AreEqual(DecryptedText, Cypher_UA.Decrypt(PlainText));
        }

        /*[Test]
        public void Test_Crack_UA_Key_1()
        {
            BruteCracker bruteCracker = new(Cypher_UA, "../../../ua.txt");
            string PlainText = "Рсігїу тгїу!";
            String DecryptedText = "Привіт світ!";
            Assert.AreEqual(DecryptedText, bruteCracker.Crack(PlainText));
        }

        [Test]
        public void Test_Crack_EN_Key_1()
        {
            BruteCracker bruteCracker = new(Cypher_EN, "../../../en.txt");
            string PlainText = "Ifmmp xpsme!";
            String DecryptedText = "Hello world!";
            Assert.AreEqual(DecryptedText, bruteCracker.Crack(PlainText));
        }*/
    }
}
