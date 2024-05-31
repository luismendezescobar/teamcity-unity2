using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using System;
using System.IO;

public class GameBuilder : MonoBehaviour
{
    [MenuItem("Build/Build macOS")]
    public static void PerformMacOSBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/macOS/jump-game.app" ;
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result==BuildResult.Succeeded)
        {
            Debug.Log(message: "Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log(message: "Build failed");
        }
    }

    [MenuItem("Build/Build WebGL")]
    public static void PerformWebGLBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/WebGL";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log(message: "Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log(message: "Build failed");
        }
    }
    [MenuItem("Build/Build iOS")]
    public static void PerformiOSBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/iOS";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }

    [MenuItem("Build/Build Android")]
    public static void PerformAndroidBuild()
    {
        // Read command line arguments for version and bundle version code
        string version = GetCommandLineArg("-version");
        string bundleVersionCodeStr = GetCommandLineArg("-bundleVersionCode");
        string packageName = GetCommandLineArg("-packageName");

        if (string.IsNullOrEmpty(version) || string.IsNullOrEmpty(bundleVersionCodeStr))
        {
            Debug.LogError("Version or Bundle Version Code not specified!");
            return;
        }

        if (!int.TryParse(bundleVersionCodeStr, out int bundleVersionCode))
        {
            Debug.LogError("Invalid Bundle Version Code!");
            return;
        }
        // Set version and bundle version code
        PlayerSettings.bundleVersion = version;
        PlayerSettings.Android.bundleVersionCode = bundleVersionCode;
        PlayerSettings.applicationIdentifier = packageName;

        //here continues the normal code
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/Android/jump-game.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
    [MenuItem("Build/Build Android AAB")]
    public static void PerformAndroidAABBuild()
    {
        // Read command line arguments for version and bundle version code
        string version = GetCommandLineArg("-version");
        string bundleVersionCodeStr = GetCommandLineArg("-bundleVersionCode");
        string packageName = GetCommandLineArg("-packageName");

        if (string.IsNullOrEmpty(version) || string.IsNullOrEmpty(bundleVersionCodeStr))
        {
            Debug.LogError("Version or Bundle Version Code not specified!");
            return;
        }

        if (!int.TryParse(bundleVersionCodeStr, out int bundleVersionCode))
        {
            Debug.LogError("Invalid Bundle Version Code!");
            return;
        }
        // Set version and bundle version code
        PlayerSettings.bundleVersion = version;
        PlayerSettings.Android.bundleVersionCode = bundleVersionCode;
        PlayerSettings.applicationIdentifier = packageName;

        //here continues the normal code
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/AndroidAab/jump-game.aab";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.CleanBuildCache;
        
        // Set to build AAB
        EditorUserBuildSettings.buildAppBundle = true;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }   
   
    [MenuItem("Build/Build Android Project")]
    public static void PerformAndroidProjectBuild()
    {
       try{
        // Clean the build path
        string buildPath = "build/AndroidProject";
        if (Directory.Exists(buildPath))
        {
            Directory.Delete(buildPath, true);
        }

        // Ensure the build path is created
        Directory.CreateDirectory(buildPath);
        
        //here continues the usual code
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = buildPath;
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.AcceptExternalModificationsToPlayer; // Option to generate project

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
       }
        catch (System.Exception e)
        {
            Debug.LogError("Luis Build failed with exception: " + e.Message);
            print("Build failed with exception: " + e.Message);
        }
    }   
    private static string GetCommandLineArg(string name)
    {
        var args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == name && args.Length > i + 1)
            {
                return args[i + 1];
            }
        }
        return null;
    }


}
