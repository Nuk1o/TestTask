using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AssetReference sceneReference;

    void Start()
    {
        LoadScene();
    }

    async void LoadScene()
    {
        AsyncOperationHandle<SceneInstance> handle = sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Scene loaded successfully!");
        }
        else
        {
            Debug.LogError("Failed to load scene: " + handle.DebugName);
        }
    }
}