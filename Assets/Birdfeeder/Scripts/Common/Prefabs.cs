using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;


    public static class Prefabs
    {
        public static List<GameObject> _assets;
        public async static void Initialize()
        {
            var init = Addressables.InitializeAsync();
            
        }

        //- prefabs
        public static void AddAsset(GameObject asset)
        {
            _assets.Add(asset);
        }
        public static GameObject GetAsset(string name)
        {
            return _assets.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
        }

        //- Addressables
        public static Task<GameObject> GetAddressable(string address)
        {
            var tcs = new TaskCompletionSource<GameObject>();
            var asset = Addressables.LoadAssetAsync<GameObject>(address);
            asset.Completed += operation => { tcs.SetResult(operation.Result); };
            return tcs.Task;
        }
        public static Task<GameObject> GetAddressable(AssetReference address)
        {
            var tcs = new TaskCompletionSource<GameObject>();
            var asset = Addressables.LoadAssetAsync<GameObject>(address);
            asset.Completed += operation => { tcs.SetResult(operation.Result); };
            return tcs.Task;
        }
        public static Task<T> GetAddressable<T>(string address)
        {
            var tcs = new TaskCompletionSource<T>();
            var asset = Addressables.LoadAssetAsync<T>(address);
            asset.Completed += operation => { tcs.SetResult(operation.Result); };
            return tcs.Task;
        }

        //- Scenes
        public static Task<T> LoadSceneAsync<T>(string name, LoadSceneMode mode = LoadSceneMode.Single, bool activate = true) where T : UnityEngine.Object
        {
            var tcs = new TaskCompletionSource<T>();
            var scene = Addressables.LoadSceneAsync(name, mode, activate);
            scene.Completed += operation => { tcs.SetResult(UnityEngine.Object.FindObjectOfType<T>()); };
            return tcs.Task;
        }
        public static Task<SceneInstance> LoadSceneAsync(string name, LoadSceneMode mode = LoadSceneMode.Single, bool activate = true)
        {
            var tcs = new TaskCompletionSource<SceneInstance>();
            var scene = Addressables.LoadSceneAsync(name, mode, activate);
            scene.Completed += operation => { tcs.SetResult(scene.Result); };
            return tcs.Task;
        }

    }
