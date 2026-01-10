using UnityEngine;
using UnityEditor;

namespace FalmeStreamless.Credits
{

    [CustomEditor(typeof(Credits))]
    public class CreditsDebug : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Credits credits = (Credits)target;
            if (GUILayout.Button("Scroll 100px"))
            {
                credits.ScrollTo(100);
            }
            if (GUILayout.Button("Scroll 500px"))
            {
                credits.ScrollTo(500);
            }
            if (GUILayout.Button("Scroll Start"))
            {
                credits.ScrollToStart();
                credits.StartScrolling();
            }
            if (GUILayout.Button("Scroll Stop"))
            {
                credits.StopScrolling();
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
