using UnityEngine;
using UnityEditor;

namespace Wigro.Runtime
{
    [CustomEditor( typeof(Settings) )]
    [CanEditMultipleObjects]
    public class SettingsInspector : UnityEditor.Editor
    {
        private Settings _subject;
        private SerializedProperty _folder;
        private SerializedProperty _amount;
        private SerializedProperty _flags;

        private bool _isAnimatedOpened;
        private bool _isAnimatedClosure;
        private bool _isShowInfo;
        
        void OnEnable () 
        {
            _subject = target as Settings;
		
            _folder = serializedObject.FindProperty("_folder");
            _amount = serializedObject.FindProperty ("_amount");
            _flags = serializedObject.FindProperty("_flags");
        }
        
        public override void OnInspectorGUI() 
        {
            serializedObject.Update();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Folder");
            _folder.objectReferenceValue = EditorGUILayout.ObjectField(_folder.objectReferenceValue, typeof(Object), false);
            EditorGUILayout.EndHorizontal();
            _amount.intValue = Mathf.Max(10, EditorGUILayout.IntField("Inventory size:", Mathf.Max(10, _amount.intValue)));

            _subject.OpenAnimated = EditorGUILayout.Toggle("Open Animated", _subject.OpenAnimated);
            _subject.CloseAnimated = EditorGUILayout.Toggle("Close Animated", _subject.CloseAnimated);
            _subject.ShowInfo = EditorGUILayout.Toggle("Show Info", _subject.ShowInfo);

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(_subject);
        }
    }
}