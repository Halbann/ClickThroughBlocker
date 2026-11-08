using System;
using UnityEngine;

namespace ClearAllInputLocks
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    class SceneChangeCleanup : MonoBehaviour
    {
        void Start()
        {
            GameEvents.onGameSceneLoadRequested.Add(onGameSceneLoadRequested);
        }
        void OnDestroy()
        {
            GameEvents.onGameSceneLoadRequested.Remove(onGameSceneLoadRequested);
        }

        bool ongameSceneLoadRequestedCalled = false;
        void onGameSceneLoadRequested(GameScenes gs)
        {
            if (!ongameSceneLoadRequestedCalled)
            {
                ongameSceneLoadRequestedCalled = true;
                InputLockManager.ClearControlLocks();
            }
        }
    }
}
