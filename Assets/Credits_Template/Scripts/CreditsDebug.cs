using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace FalmeStreamless.Credits
{

    [CustomEditor(typeof(Scroll))]
    public class CreditsDebug : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Scroll scroll = (Scroll)target;
            if (GUILayout.Button("Scroll Start"))
            {
                Vector2 res = scroll.GetComponentInParent<CanvasScaler>().referenceResolution;
                scroll.ScrollToStart(res);
                scroll.StartScrolling();
            }
            if (GUILayout.Button("Scroll Stop"))
            {
                scroll.StopScrolling();
            }
        }
    }
}
