using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dono.UtilitiesForUnity
{
    public static class UnityPathUtil
    {
        public static string StreamingAssetPathAccordingToTheDevice()
        {
            string streamingAssetPath;
            #if UNITY_STANDALONE
            streamingAssetPath = Application.dataPath + "/StreamingAssets";
            #elif UNITY_IOS
            streamingAssetPath = Application.dataPath + "/Raw";
            #elif UNITY_ANDROID
            streamingAssetPath = "jar:file://" + Application.dataPath + "!/assets/";
            #else
            streamingAssetPath = Application.dataPath + "/StreamingAssets";
            #endif
            return streamingAssetPath;
        }
    }
}