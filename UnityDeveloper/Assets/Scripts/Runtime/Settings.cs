using UnityEngine;

namespace Wigro.Runtime
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "settings")]
    public sealed class Settings : ScriptableObject
    {
        // TODO: ������� ���������������� ��������� ��� ������� ������� (new source file: SettingsInspector.cs) �� ���� UnityEditor.Editor

        [SerializeField, HideInInspector]
        /// � ��� ���� �� ������ ����� ����������� ��������� ����� ������� � ������ ����� ������� "Assets/..."
        /// ���������: ������� � ������� ��� Unity ��� �� ��������� �������
        private Object _folder;
        public Object folder => _folder;

        [SerializeField, HideInInspector]
        /// ���� ������ ��������� � ���� ����� � ����������� ���������� ��������� 10
        private int _amount;
        public int amount
        {
            get => _amount;
            set => _amount = Mathf.Max(10, value);
        }


        [SerializeField, HideInInspector]
        /// ������������ ������ ���� � �������� ���������� ������ (� ���������� ��� ����� toggle-�������������)
        /// ������� ��� ������: 
        ///  - OpenAnimated(����������� ��������� ��� ��������);
        ///  - CloseAnimated(����������� ��������� ��� ��������);
        ///  - ShowInfo(���������� �� ������ � ����������� � �������� ��� ��������� ����� �������� � ���������);
        private int _flags;

        public bool OpenAnimated
        {
            get => (_flags & 1) != 0;
            set => _flags = value ? (_flags | 1) : (_flags & ~1);
        }

        public bool CloseAnimated
        {
            get => (_flags & 2) != 0;
            set => _flags = value ? (_flags | 2) : (_flags & ~2);
        }

        public bool ShowInfo
        {
            get => (_flags & 4) != 0;
            set => _flags = value ? (_flags | 4) : (_flags & ~4);
        }
    }
}
