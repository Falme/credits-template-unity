namespace FalmeStreamless.Credits
{
    [System.Serializable]
    public class CreditsData
    {
        public string version;
        public float velocity;
        public string title;
        public CreditsItem[] items;
        public string[,] labels;
    }

    [System.Serializable]
    public class CreditsItem
    {
        public bool category;
        public bool actor;
        public bool space;
        public bool image;
        public string path;
        public string text;
        public float height;
        public string[] actors;
    }
}
