namespace CBADproj
{
    using UnityEngine;
    using UnityEditor;

    public class EditorWindowSample : EditorWindow
    {
        [MenuItem("Editor/EnemyEditor")]
        private static void Create()
        {
            // 生成
            GetWindow<EditorWindowSample>("Enemy");
        }
    }
}