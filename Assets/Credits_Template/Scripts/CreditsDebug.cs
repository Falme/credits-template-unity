using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace FalmeStreamless.Credits
{

    [CustomEditor(typeof(CreditsScroll))]
    public class CreditsDebug : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CreditsScroll creditsScroll = (CreditsScroll)target;
            if (GUILayout.Button("Scroll Start"))
            {
                Vector2 res = creditsScroll.GetComponentInParent<CanvasScaler>().referenceResolution;
                creditsScroll.ScrollToStart(res);
                creditsScroll.StartScrolling();
            }
            if (GUILayout.Button("Scroll Stop"))
            {
                creditsScroll.StopScrolling();
            }
        }
    }
}
