# ReactiveMvvm

<img src="images/logo.png" alt="ReactiveMvvm" width="160" />

[![Build](https://github.com/reactiveui/ReactiveMvvm/actions/workflows/ci-build.yml/badge.svg)](https://github.com/reactiveui/ReactiveMvvm/actions/workflows/ci-build.yml)
[![License](https://img.shields.io/github/license/reactiveui/ReactiveMvvm)](LICENSE)

A cross-platform feedback application built with ReactiveUI, reactive view models and source-generated properties. The same view model powers Avalonia, WPF, Windows Forms, .NET MAUI, Terminal.Gui and Blazor views on .NET 10 and .NET 11.

The screenshots below show the application's original implementations. The Xamarin.Forms sample has been replaced by .NET MAUI.

| <a href="https://github.com/AvaloniaUI/Avalonia">AvaloniaUI</a> | <a href="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/">Xamarin.Forms</a> | <a href="https://docs.microsoft.com/ru-ru/windows/uwp/get-started/universal-application-platform-guide">Universal Windows Platform</a> |
| --------------- | --------- | -------------- |
| <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="800" src="https://cdn-images-1.medium.com/max/675/1*JPlUC1YoAuE2eFng29LpaQ.png"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img src="https://cdn-images-1.medium.com/max/1500/1*d1oeBQF9ilZ5h_IIhYktPQ.png" width="800"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="800" src="https://cdn-images-1.medium.com/max/900/1*EsqN0dFMCUknKc-4wuIanA.png"></a> | 

| <a href="https://github.com/dotnet/wpf">WPF</a> | <a href="https://github.com/dotnet/winforms">Windows Forms</a> | <a href="https://github.com/migueldeicaza/gui.cs">Terminal.Gui</a> |
| --------------- | --------- | -------------- |
| <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="780" src="https://user-images.githubusercontent.com/6759207/94264350-38409300-ff3f-11ea-9e78-852ee9bc8ae7.png"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img src="https://miro.medium.com/max/493/1*GGwXG5-u_Gc-yMCj8Q1tqQ.png" width="700"></a> | <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="820" src="https://user-images.githubusercontent.com/6759207/94263920-80ab8100-ff3e-11ea-91f7-9614d6a1c1ae.png"></a> | 

| ASP .NET Core via <a href="https://github.com/worldbeater/ReactiveMvvm/tree/main/src/reactivemvvm.blazor.server">Blazor</a> or <a href="https://github.com/worldbeater/ReactiveMvvm/tree/main/src/reactivemvvm.blazor.wasm">Blazor.Wasm</a> | 
| --------------- | 
| <a href="https://medium.com/@worldbeater/reactive-ui-fody-cross-platform-forms-7b501d79f46b"><img width="420" src="https://user-images.githubusercontent.com/6759207/94431677-44765b80-019e-11eb-9ebd-7e15b51a8255.png"></a> | 

## Technologies

- ReactiveUI and System.Reactive for observable state, commands and view activation.
- ReactiveUI.SourceGenerators for reactive properties.
- Avalonia with the Fluent theme, WPF, Windows Forms, .NET MAUI, Terminal.Gui and Blazor for platform views.
- TUnit and Microsoft.Testing.Platform for deterministic tests and Cobertura coverage.

## Sponsors

[JetBrains](https://www.jetbrains.com/) gives ReactiveUI's maintainers licences for its tools through its
[open source support programme](https://www.jetbrains.com/community/opensource/).
[Anthropic](https://www.anthropic.com/) supports them with [Claude](https://claude.com/) through
[Claude for Open Source](https://claude.com/contact-sales/claude-for-oss).
[OpenAI](https://openai.com/) supports them with [Codex](https://openai.com/codex/) through
[Codex for Open Source](https://developers.openai.com/community/codex-for-oss).

[![JetBrains](https://raw.githubusercontent.com/reactiveui/website/main/docs/images/sponsors/jetbrains.svg)](https://www.jetbrains.com/)
[![Claude by Anthropic](https://raw.githubusercontent.com/reactiveui/website/main/docs/images/sponsors/claude.svg)](https://claude.com/)
[![OpenAI](https://raw.githubusercontent.com/reactiveui/website/main/docs/images/sponsors/openai.svg)](https://openai.com/codex/)

See [our sponsors](https://www.reactiveui.net/sponsors/) for more information.
JetBrains, Claude, Anthropic, OpenAI and Codex names and logos are trademarks of their respective owners.
