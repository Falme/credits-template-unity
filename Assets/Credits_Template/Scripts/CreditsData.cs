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
	public string text;
	public int height;
	}

}
