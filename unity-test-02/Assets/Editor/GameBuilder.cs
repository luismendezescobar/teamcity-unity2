using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class GameBuilder : MonoBehaviour
{
    [MenuItem("Build/Build macOS")]
    public static void PerformMacOSBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/macOS/jump-game.app" ;
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.None;

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
        buildPlayerOptions.options = BuildOptions.None;

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
        buildPlayerOptions.options = BuildOptions.None;

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

    [MenuItem("Build/Build Android apk")]
    public static void PerformAndroidBuildApk()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/Android/jump-game.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

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

   [MenuItem("Build/Build Android aab")]
    public static void PerformAndroidBuildAab()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "build/Android/jump-game.aab";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

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
}
