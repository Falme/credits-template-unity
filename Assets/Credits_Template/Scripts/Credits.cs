using UnityEngine;

namespace FalmeStreamless.Credits
{
    public class Credits : MonoBehaviour
    {
        [Header("All Credits Data")]
        [SerializeField] private TextAsset creditsJSON;

        [Header("Transforms/UI")]
        [SerializeField] private Transform creditsScroll;

        [Header("Elements/Prefabs")]
        [SerializeField] private GameObject creditsStart;
        [SerializeField] private GameObject creditsEnd;
        
        private CreditsData data;

        void Start()
        {
            SerializeJsonData();
            CreateStartPoint();
            for(int a=0; a<data.credits.Length; a++)
            {
                CreateLabel(data.credits[a]);
            }
            CreateEndPoint();
        }

        private void SerializeJsonData()
        {
            data = JsonUtility.FromJson<CreditsData>(creditsJSON.text);
        }

        private void CreateStartPoint()
        {
            GameObject.Instantiate(creditsStart, creditsScroll);
        }

        private void CreateEndPoint()
        {
            GameObject.Instantiate(creditsEnd, creditsScroll);
        }

        private void CreateLabel(CreditsItem item)
        {
            for(int a=0; a<item.actors.Length; a++)
                Debug.Log(item.actors[a]);
        }
    }

}
