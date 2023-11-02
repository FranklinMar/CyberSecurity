namespace Lab1
{
    public interface ICracker
    {
        public ICypher Cypher { get; set; }
        public string Key { get; set; }
        public string Crack(string Text);

        public string Crack(string PlainText, string EncryptedText);
    }
}
