using UnityEngine;

namespace Wigro.Runtime
{
    [System.Serializable]
    public sealed class Settings : ScriptableObject
    {
        // TODO: ������� ���������������� ��������� ��� ������� ������� (new source file: SettingsInspector.cs) �� ���� UnityEditor.Editor

        [SerializeField, HideInInspector]
        /// � ��� ���� �� ������ ����� ����������� ��������� ����� ������� � ������ ����� ������� "Assets/..."
        /// ���������: ������� � ������� ��� Unity ��� �� ��������� �������
        private Object _folder;

        [SerializeField, HideInInspector]
        /// ���� ������ ��������� � ���� ����� � ����������� ���������� ��������� 10
        private int _amount;

        [SerializeField, HideInInspector]
        /// ������������ ������ ���� � �������� ���������� ������ (� ���������� ��� ����� toggle-�������������)
        /// ������� ��� ������: 
        ///  - OpenAnimated(����������� ��������� ��� ��������);
        ///  - CloseAnimated(����������� ��������� ��� ��������);
        ///  - ShowInfo(���������� �� ������ � ����������� � �������� ��� ��������� ����� �������� � ���������);
        private int _flags;

        public Object folder => _folder;

    }
}
