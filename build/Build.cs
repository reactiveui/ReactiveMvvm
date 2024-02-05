using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using Nuke.Common.Tools.MSBuild;

class Build : NukeBuild
{
    const string InteractiveProjectName = "ReactiveMvvm.Avalonia";
    const string CoverageFileName = "coverage.cobertura.xml";

    public static int Main() => Execute<Build>(x => x.RunInteractive);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    [Parameter] readonly bool Interactive;
    [Parameter] readonly bool Full;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    Target Clean => _ => _
        .Before(RunUnitTests)
        .Executes(() => SourceDirectory
            .GlobDirectories("**/bin", "**/obj", "**/AppPackages", "**/BundleArtifacts")
            .Concat(RootDirectory.GlobDirectories("**/artifacts"))
            .ForEach(ap => ap.DeleteDirectory()));

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

    Target CompileMauiApp => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() => SourceDirectory
            .GlobFiles("**/*.Maui.csproj")
            .ForEach(path =>
                DotNetBuild(settings => settings
                    .SetProjectFile(path)
                    .SetConfiguration(Configuration))));

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
        .DependsOn(CompileBlazorApp)
        .DependsOn(CompileMauiApp)
        .DependsOn(CompileTerminalApp)
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
