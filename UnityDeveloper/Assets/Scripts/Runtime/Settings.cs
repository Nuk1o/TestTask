using UnityEngine;

namespace Wigro.Runtime
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "settings")]
    public sealed class Settings : ScriptableObject
    {
        // TODO: Создать пользовательский инспектор для данного конфига (new source file: SettingsInspector.cs) на базе UnityEditor.Editor

        [SerializeField, HideInInspector]
        /// В это поле мы должны иметь возможность назначить любой каталог в рамках корня проекта "Assets/..."
        /// Подсказка: каталог в проекте для Unity так же считается ассетом
        private Object _folder;
        public Object folder => _folder;

        [SerializeField, HideInInspector]
        /// Поле должно принимать в себя число с минимальным допустимым значением 10
        private int _amount;
        public int amount
        {
            get => _amount;
            set => _amount = Mathf.Max(10, value);
        }


        [SerializeField, HideInInspector]
        /// Использовать данное поле в качестве контейнера флагов (в инспекторе это будет toggle-переключатель)
        /// Сделать три выбора: 
        ///  - OpenAnimated(Анимировать инвентарь при открытии);
        ///  - CloseAnimated(Анимировать инвентарь при закрытии);
        ///  - ShowInfo(показывать ли панель с информацией о предмете при выделении этого предмета в инвентаре);
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
