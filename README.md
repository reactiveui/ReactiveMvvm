[![Build Status](https://worldbeater.visualstudio.com/Camelotia/_apis/build/status/ReactiveMvvm-CI)](https://worldbeater.visualstudio.com/Camelotia/_build/latest?definitionId=4) [![Pull Requests](https://img.shields.io/github/issues-pr/worldbeater/reactivemvvm.svg)](https://github.com/worldbeater/reactivemvvm/pulls) [![Issues](https://img.shields.io/github/issues/worldbeater/reactivemvvm.svg)](https://github.com/worldbeater/reactivemvvm/issues) ![License](https://img.shields.io/github/license/worldbeater/reactivemvvm.svg) ![Size](https://img.shields.io/github/repo-size/worldbeater/reactivemvvm.svg) [![Code Coverage](https://img.shields.io/azure-devops/coverage/worldbeater/camelotia/4.svg)](https://worldbeater.visualstudio.com/Camelotia/_build/latest?definitionId=4)

# ReactiveMvvm

A  truly cross-platform app example created using <a href="https://reactiveui.net">ReactiveUI MVVM framework</a>, <a href="https://github.com/Fody/PropertyChanged">PropertyChanged.Fody</a> and most popular XAML UI frameworks. The app implements MVVM architecture extended with <a href="https://medium.com/@worldbeater/reactive-mvvm-for-net-platform-175dc69cfc82">reactive programming and assembly weaving</a>. It was built to demonstrate how to avoid writing boilerplate code when working with the INotifyPropertyChanged interface and how to create portable and maintainable ViewModels. Article on Medium: https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b

| <a href="https://github.com/AvaloniaUI/Avalonia">AvaloniaUI</a> | <a href="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/">Xamarin.Forms</a> | <a href="https://docs.microsoft.com/ru-ru/windows/uwp/get-started/universal-application-platform-guide">Universal Windows Platform</a> |
| --------------- | --------- | -------------- |
| <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="800" src="https://cdn-images-1.medium.com/max/675/1*JPlUC1YoAuE2eFng29LpaQ.png"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img src="https://cdn-images-1.medium.com/max/1500/1*d1oeBQF9ilZ5h_IIhYktPQ.png" width="800"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="800" src="https://cdn-images-1.medium.com/max/900/1*EsqN0dFMCUknKc-4wuIanA.png"></a> | 

| <a href="https://github.com/dotnet/wpf">WPF</a> | <a href="https://github.com/dotnet/winforms">Windows Forms</a> | <a href="https://github.com/migueldeicaza/gui.cs">Terminal.Gui</a> |
| --------------- | --------- | -------------- |
| <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="780" src="https://user-images.githubusercontent.com/6759207/94264350-38409300-ff3f-11ea-9e78-852ee9bc8ae7.png"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img src="https://miro.medium.com/max/493/1*GGwXG5-u_Gc-yMCj8Q1tqQ.png" width="700"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="820" src="https://user-images.githubusercontent.com/6759207/94263920-80ab8100-ff3e-11ea-91f7-9614d6a1c1ae.png"></a> | 

## Technologies and Tools Used
- <a href="https://reactiveui.net/">ReactiveUI</a> modern MVVM framework
- <a href="http://reactivex.io/">Reactive Extensions</a> for the <a href="https://github.com/Reactive-Extensions/Rx.NET">.NET platform</a>
- <a href="https://github.com/Fody/PropertyChanged">PropertyChanged.Fody</a> for INotifyPropertyChanged injections
- <a href="http://xunit.github.io/">xUnit</a> tests on <a href="https://www.microsoft.com/net/core">.NET Core</a>
- <a href="https://github.com/fluentassertions/fluentassertions">FluentAssertions</a> to improve tests readability
- <a href="https://github.com/nsubstitute/NSubstitute">NSubstitute</a> for stubs and mocks
- <a href="https://github.com/AvaloniaUI/Avalonia">AvaloniaUI</a> for Linux and MacOS
- <a href="https://github.com/worldbeater/Citrus.Avalonia">Citrus</a> bright and modern AvaloniaUI theme
- <a href="https://www.xamarin.com/">Xamarin.Forms</a> for Android, iOS and Tizen
- <a href="https://docs.microsoft.com/en-us/windows/uwp/index">Universal Windows Platform</a> for Windows 10
- <a href="https://msdn.microsoft.com/ru-ru/library/aa970268(v=vs.100).aspx">Windows Presentation Foundation</a>
- <a href="https://docs.microsoft.com/ru-ru/dotnet/framework/winforms/windows-forms-overview">Windows Forms</a>
- <a href="https://www.jetbrains.com/rider/">JetBrains Rider</a> and <a href="https://visualstudio.microsoft.com/">Microsoft Visual Studio 2019</a> IDEs
