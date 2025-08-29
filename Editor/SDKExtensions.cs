
using ThunderRoad;
using ThunderRoad.AssetSorcery;
using UnityEngine;
using QualityLevel = ThunderRoad.QualityLevel;

namespace Wully
{
    public static class SDKExtensions
    {
       //menu item to change the quality to android then switch the build platform to android
        [UnityEditor.MenuItem("ThunderRoad (SDK)/Extensions/Set Build mode to Nomad (Android)", priority = 999)]
        public static void SetAndroidQualityAndPlatform()
        {
            //check if the platform is already set to android
            
            //show an editor dialog to confirm the action
            if (!UnityEditor.EditorUtility.DisplayDialog("Set Android Quality and Platform",
                    "This will set the quality to Android and switch the build platform to Android. \nAre you sure you want to proceed?\n It can take a while to switch the platform for the first time",
                    "Yes", "No"))
            {
                Debug.Log("User cancelled the action.");
                return;
            }
            //set the quality to android
            Debug.Log($"Setting quality to {QualityLevel.Android}");
            QualitySettings.SetQualityLevel((int)QualityLevel.Android);
            Common.GetQualityLevel(true); // Force cache platform 
            AssetSorceryPlatform.AssetSorceryShaderSetPlatform(AssetSorceryPlatformRuntime.AssetSorceryGetBuildPlatform(true));
            //switch the build platform to android
            if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android)
            {
                Debug.Log("Platform is already set to Android.");
            }
            else
            {
                UnityEditor.EditorUserBuildSettings.SwitchActiveBuildTarget(UnityEditor.BuildTargetGroup.Android, UnityEditor.BuildTarget.Android);
            }
            Debug.Log("Set quality to Android and switched platform to Android.");
        }
        
        [UnityEditor.MenuItem("ThunderRoad (SDK)/Extensions/Set Build mode to PC (Windows)", priority = 999)]
        public static void SetWindowsQualityAndPlatform()
        {
            //show an editor dialog to confirm the action
            if (!UnityEditor.EditorUtility.DisplayDialog("Set Windows Quality and Platform",
                    "This will set the quality to Windows and switch the build platform to Windows. \nAre you sure you want to proceed?\n It can take a while to switch the platform for the first time",
                    "Yes", "No"))
            {
                Debug.Log("User cancelled the action.");
                return;
            }
            //set the quality to android
            Debug.Log($"Setting platform to {QualityLevel.Windows}");
            QualitySettings.SetQualityLevel((int)QualityLevel.Windows);
            Common.GetQualityLevel(true); // Force cache platform 
            AssetSorceryPlatform.AssetSorceryShaderSetPlatform(AssetSorceryPlatformRuntime.AssetSorceryGetBuildPlatform(true));
            //switch the build platform to Windows
            if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.StandaloneWindows64)
            {
                Debug.Log("Platform is already set to Windows.");
            }
            else
            {
                UnityEditor.EditorUserBuildSettings.SwitchActiveBuildTarget(UnityEditor.BuildTargetGroup.Standalone, UnityEditor.BuildTarget.StandaloneWindows64);
            }
            Debug.Log("Set quality to Standalone and switched platform to Standalone.");
            
        }
    }
}