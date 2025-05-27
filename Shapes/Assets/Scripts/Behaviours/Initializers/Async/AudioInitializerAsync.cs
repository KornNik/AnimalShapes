using Helpers;
using Controllers;
using Data;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class AudioInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var audioControllerPrefab = Services.Instance.DataResourcePrefabs.ServicesObject.
                GetAudioPrefab(AudioTypes.AudioController);
            var audioController = GameObject.Instantiate(audioControllerPrefab).
                GetComponent<AudioController>();

            Services.Instance.AudioPlayer.SetObject(audioController);

            await UniTask.Yield();
        }
    }
}
