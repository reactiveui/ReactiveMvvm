# ReactiveMvvm

A minimal but truly cross-platform app created using <a href="https://reactiveui.net">ReactiveUI MVVM framework</a> and most popular XAML UI frameworks. The app implements MVVM architecture extended with <a href="https://medium.com/@worldbeater/reactive-mvvm-for-net-platform-175dc69cfc82">reactive programming and assembly weaving</a>. It was built to demonstrate how to avoid writing boilerplate code when working with the INotifyPropertyChanged interface and how to create portable and maintainable ViewModels. Article on Medium: https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b

| <a href="https://github.com/AvaloniaUI/Avalonia">Avalonia UI</a> | <a href="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/">Xamarin Forms</a> | <a href="https://docs.microsoft.com/ru-ru/windows/uwp/get-started/universal-application-platform-guide">Universal Windows Platform</a> |
| --------------- | --------- | -------------- |
| <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="800" src="https://cdn-images-1.medium.com/max/1200/1*Lz7aENCsgOog1QnYiu8lzA.png"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img src="https://cdn-images-1.medium.com/max/1500/1*d1oeBQF9ilZ5h_IIhYktPQ.png" width="800"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="800" src="https://cdn-images-1.medium.com/max/900/1*EsqN0dFMCUknKc-4wuIanA.png"></a> | 

## Technologies and Tools Used
- <a href="https://reactiveui.net/">Reactive UI</a> modern MVVM framework
- <a href="http://reactivex.io/">Reactive Extensions</a> for the <a href="https://github.com/Reactive-Extensions/Rx.NET">.NET platform</a>
- <a href="https://github.com/Fody/PropertyChanged">PropertyChanged.Fody</a> for INotifyPropertyChanged injections
- <a href="http://xunit.github.io/">xUnit</a> tests on <a href="https://www.microsoft.com/net/core">.NET Core</a>
- <a href="https://github.com/fluentassertions/fluentassertions">FluentAssertions</a> to improve tests readability
- <a href="https://github.com/nsubstitute/NSubstitute">NSubstitute</a> for stubs and mocks
- <a href="https://github.com/AvaloniaUI/Avalonia">Avalonia UI</a> for Linux and MacOS
- <a href="https://www.xamarin.com/">Xamarin.Forms</a> for Android and iOS
- <a href="https://docs.microsoft.com/en-us/windows/uwp/index">Universal Windows Platform</a> for Windows 10
- <a href="https://msdn.microsoft.com/ru-ru/library/aa970268(v=vs.100).aspx">Windows Presentation Foundation</a>
