namespace Annexxie.Model
{
    public class Lookup
    {
        int vId;
        string vValue, vCategory;

        public Lookup(int id, string category, string value)
        {
            vId = id;
            vValue = value;
            vCategory = category;
        }

        public int Id { get => vId; set => vId = value; }
        public string Value { get => vValue; set => vValue = value; }
        public string Category { get => vCategory; set => vCategory = value; }
    }
}
