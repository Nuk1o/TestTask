using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wigro.Runtime
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Canvas _canvas;
        public AssetReference sceneReference;

        void Start()
        {
            _button.onClick.AddListener(delegate { CloseCanvas(); });
            LoadScene();
        }

        private void CloseCanvas()
        {
            _canvas.gameObject.SetActive(false);
        }

        async void LoadScene()
        {
            AsyncOperationHandle<SceneInstance> handle = sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            await handle.Task;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Сцена успешно загружена!");
            }
            else
            {
                Debug.LogError("Не удалось загрузить сцену: " + handle.DebugName);
            }
        }

    }
}
