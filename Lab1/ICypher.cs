namespace Lab1
{
    public interface ICypher
    {
        public string Name { get; set; }
        public string Alphabet { get; set; }
        public string Key { get; set;}
        public string Encrypt(string Text);
        public string Decrypt(string Text);
    }
}
