namespace FalmeStreamless.Credits
{
    [System.Serializable]
    public class CreditsData
    {
        public string version;
        public float velocity;
        public string title;
        public CreditsItem[] credits;
        public string[,] labels;
    }

    [System.Serializable]
    public class CreditsItem
    {
        public string label;
        public bool title;
        public bool category;
        public string[] actors;
        public int space;
    }

}
