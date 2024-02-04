using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using Serilog;

// ReSharper disable ArrangeTypeMemberModifiers

[UnsetVisualStudioEnvironmentVariables]
internal class Build : NukeBuild
{
    const string InteractiveProjectName = "ReactiveMvvm.Avalonia";
    const string CoverageFileName = "coverage.cobertura.xml";

    public static int Main() => Execute<Build>(x => x.RunInteractive);
    
    [Parameter] readonly string Configuration = IsLocalBuild ? "Debug" : "Release";
    [Parameter] readonly bool Interactive;
    [Parameter] readonly bool Full;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    Target Clean => _ => _
        .Before(RunUnitTests)
        .Executes(() => SourceDirectory
            .GlobDirectories("**/bin", "**/obj", "**/AppPackages", "**/BundleArtifacts")
            .Concat(RootDirectory.GlobDirectories("**/artifacts"))
            .ForEach(DeleteDirectory));
    
    Target RunUnitTests => _ => _
        .DependsOn(Clean)
        .Executes(() => SourceDirectory
            .GlobFiles("**/*.Tests.csproj")
            .ForEach(path =>
                DotNetTest(settings => settings
                    .SetProjectFile(path)
                    .SetConfiguration(Configuration)
                    .SetLoggers($"trx;LogFileName={ArtifactsDirectory / "report.trx"}")
                    .AddProperty("CollectCoverage", true)
                    .AddProperty("CoverletOutputFormat", "cobertura")
                    .AddProperty("Exclude", "[xunit.*]*")
                    .AddProperty("CoverletOutput", ArtifactsDirectory / CoverageFileName))));

    Target CompileAvaloniaApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() => SourceDirectory
            .GlobFiles("**/*.Avalonia.csproj")
            .ForEach(path =>
                DotNetBuild(settings => settings
                    .SetProjectFile(path)
                    .SetConfiguration(Configuration))));

    Target CompileTerminalApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() => SourceDirectory
            .GlobFiles("**/*.Terminal.csproj")
            .ForEach(path =>
                DotNetBuild(settings => settings
                    .SetProjectFile(path)
                    .SetConfiguration(Configuration))));

    Target CompileBlazorApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() => SourceDirectory
            .GlobFiles("**/*.Blazor.csproj")
            .ForEach(path =>
                DotNetBuild(settings => settings
                    .SetProjectFile(path)
                    .SetConfiguration(Configuration))));

    Target CompileUniversalWindowsApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var execute = EnvironmentInfo.IsWin && Full;
            Log.Information($"Should compile for Universal Windows: {execute}");
            if (!execute) return;

            Log.Debug("Restoring packages required by UAP...");
            var project = SourceDirectory.GlobFiles("**/*.Uwp.csproj").First();
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Restore"));
            Log.Debug("Successfully restored UAP packages.");

            new[] { MSBuildTargetPlatform.x86,
                    MSBuildTargetPlatform.x64,
                    MSBuildTargetPlatform.arm }
                .ForEach(BuildApp);

            void BuildApp(MSBuildTargetPlatform platform)
            {
                Log.Debug("Cleaning UAP project...");
                MSBuild(settings => settings
                    .SetProjectFile(project)
                    .SetTargets("Clean"));
                Log.Debug("Successfully managed to clean UAP project.");

                Log.Debug($"Building UAP project for {platform}...");
                MSBuild(settings => settings
                    .SetProjectFile(project)
                    .SetTargets("Build")
                    .SetConfiguration(Configuration)
                    .SetTargetPlatform(platform)
                    .SetProperty("AppxPackageSigningEnabled", false)
                    .SetProperty("AppxPackageDir", ArtifactsDirectory)
                    .SetProperty("UapAppxPackageBuildMode", "CI")
                    .SetProperty("AppxBundle", "Always"));
                Log.Debug($"Successfully built UAP project for {platform}.");
            }
        });

    Target CompileXamarinAndroidApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var execute = EnvironmentInfo.IsWin && Full;
            Log.Information($"Should compile for Android: {execute}");
            if (!execute) return;

            Log.Debug("Restoring packages required by Xamarin Android...");
            var project = SourceDirectory.GlobFiles("**/*.Xamarin.Android.csproj").First();
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Restore"));
            Log.Debug("Successfully restored Xamarin Android packages.");

            Log.Debug("Building Xamarin Android project...");
            var java = Environment.GetEnvironmentVariable("JAVA_HOME");
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Build")
                .SetConfiguration(Configuration)
                .SetProperty("JavaSdkDirectory", java));
            Log.Debug("Successfully built Xamarin Android project.");

            Log.Debug("Signing Android package...");
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("SignAndroidPackage")
                .SetConfiguration(Configuration)
                .SetProperty("JavaSdkDirectory", java));
            Log.Debug("Successfully signed Xamarin Android APK.");

            Log.Debug("Moving APK files to artifacts directory...");
            SourceDirectory
                .GlobFiles("**/bin/**/*-Signed.apk")
                .ForEach(file => MoveFileToDirectory(file, ArtifactsDirectory));
            Log.Debug("Successfully moved APK files.");
        });

    Target CompileWindowsPresentationApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var execute = EnvironmentInfo.IsWin && Full;
            Log.Information($"Should compile for WPF: {execute}");
            if (!execute) return;

            Log.Debug("Restoring packages required by WPF app...");
            var project = SourceDirectory.GlobFiles("**/*.Wpf.csproj").First();
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Restore"));
            Log.Debug("Successfully restored Wpf packages.");

            Log.Debug("Building WPF project...");
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Build")
                .SetConfiguration(Configuration));
            Log.Debug("Successfully built WPF project.");
        });

    Target CompileWindowsFormsApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var execute = EnvironmentInfo.IsWin && Full;
            Log.Information($"Should compile for Windows Forms: {execute}");
            if (!execute) return;

            Log.Debug("Restoring packages required by Windows Forms app...");
            var project = SourceDirectory.GlobFiles("**/*.WinForms.csproj").First();
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Restore"));
            Log.Debug("Successfully restored Windows Forms packages.");

            Log.Debug("Building Windows Forms project...");
            MSBuild(settings => settings
                .SetProjectFile(project)
                .SetTargets("Build")
                .SetConfiguration(Configuration));
            Log.Debug("Successfully built Windows Forms project.");
        });

    Target RunInteractive => _ => _
        .DependsOn(CompileAvaloniaApp)
        .DependsOn(CompileTerminalApp)
        .DependsOn(CompileUniversalWindowsApp)
        .DependsOn(CompileXamarinAndroidApp)
        .DependsOn(CompileWindowsPresentationApp)
        .DependsOn(CompileWindowsFormsApp)
        .Executes(() => SourceDirectory
            .GlobFiles($"**/{InteractiveProjectName}.csproj")
            .Where(x => Interactive)
            .ForEach(path => 
                DotNetRun(settings => settings
                    .SetProjectFile(path)
                    .SetConfiguration(Configuration)
                    .EnableNoRestore()
                    .EnableNoBuild())));
}
