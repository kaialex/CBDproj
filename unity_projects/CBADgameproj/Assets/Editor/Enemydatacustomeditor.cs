namespace CBADproj
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(Enemydata))]
    public class Enemydatacustomeditor : Editor
    {
        SerializedProperty shottype;

        private void OnEnable()
        {
            shottype = this.serializedObject.FindProperty("shotdata");
            //Debug.Log(shottype.GetArrayElementAtIndex(0).);
        }

        public override void OnInspectorGUI()
        {

            EditorGUI.BeginChangeCheck();
            base.OnInspectorGUI();

            if (EditorGUI.EndChangeCheck())
            {
                //foreach ()
            }
        }
    }
}
