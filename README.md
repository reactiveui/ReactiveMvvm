<div align="center">

<a href="https://github.com/reactiveui/ReactiveMvvm"><img src="https://raw.githubusercontent.com/reactiveui/ReactiveMvvm/main/images/logo.png" alt="ReactiveMvvm" width="128"></a>

# ReactiveMvvm

[![Build](https://img.shields.io/github/actions/workflow/status/reactiveui/ReactiveMvvm/ci-build.yml?branch=main&label=build&logo=githubactions&logoColor=white)](https://github.com/reactiveui/ReactiveMvvm/actions/workflows/ci-build.yml)
[![License](https://img.shields.io/github/license/reactiveui/ReactiveMvvm?color=blue)](https://github.com/reactiveui/ReactiveMvvm/blob/main/LICENSE)
[![Discussions](https://img.shields.io/badge/discussions-ask%20a%20question-8A2BE2?logo=github&logoColor=white)](https://github.com/reactiveui/ReactiveUI/discussions)

</div>

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

## Contribute

ReactiveMvvm is part of [ReactiveUI](https://github.com/reactiveui) and is released under the [MIT license](https://github.com/reactiveui/ReactiveMvvm/blob/main/LICENSE). We welcome contributions of every size, from bug reports and documentation to features and tests.

- **Questions:** ask in [GitHub Discussions](https://github.com/reactiveui/ReactiveUI/discussions).
- **Bugs and feature requests:** open a [GitHub issue](https://github.com/reactiveui/ReactiveMvvm/issues/new/choose).
- **Larger changes:** open an issue or discussion first, so we can agree on the approach before you start.
- **Contributor guide:** read [reactiveui.net/contribute](https://www.reactiveui.net/contribute/) for [building and testing](https://www.reactiveui.net/contribute/building-and-testing/) and [pull requests](https://www.reactiveui.net/contribute/pull-requests/).

### Coding standards

Every pull request must meet these standards. The build checks most of them.

- Follow the [ReactiveUI C# style guide](https://www.reactiveui.net/contribute/software-style-guide/code-style/).
- The repository's `.editorconfig` and the StyleSharp, PerformanceSharp and SecuritySharp analyzers run on every build. Fix each finding in the code. Do not suppress it or relax the `.editorconfig`.
- Add tests for every bug fix and new feature.
- Document public APIs with XML documentation comments.
- Write commit messages in the [Conventional Commits](https://www.reactiveui.net/contribute/software-style-guide/commit-message-convention/) format.
- Follow the [Code of Conduct](https://github.com/reactiveui/.github/blob/main/CODE_OF_CONDUCT.md).

### Support the project

- Sponsor the maintainers on GitHub Sponsors: [reactivemarbles](https://github.com/sponsors/reactivemarbles), [glennawatson](https://github.com/sponsors/glennawatson) and [chrispulman](https://github.com/sponsors/chrispulman).
- Ask your employer to support open source, for example with the [balanced employee IP agreement](https://github.com/github/balanced-employee-ip-agreement).

## Sponsors

[JetBrains](https://www.jetbrains.com/) gives ReactiveUI's maintainers licences for its tools through its
[open source support programme](https://www.jetbrains.com/community/opensource/).
[Anthropic](https://www.anthropic.com/) supports them with [Claude](https://claude.com/) through
[Claude for Open Source](https://claude.com/contact-sales/claude-for-oss).
[OpenAI](https://openai.com/) supports them with [Codex](https://openai.com/codex/) through
[Codex for Open Source](https://developers.openai.com/community/codex-for-oss).
[Snyk](https://snyk.io/) gives the maintainers access to security tools through its
[Secure Developer Program](https://snyk.io/open-source/).

[![JetBrains](https://raw.githubusercontent.com/reactiveui/website/main/docs/images/sponsors/jetbrains.svg)](https://www.jetbrains.com/)
[![Claude by Anthropic](https://raw.githubusercontent.com/reactiveui/website/main/docs/images/sponsors/claude.svg)](https://claude.com/)
[![OpenAI](https://raw.githubusercontent.com/reactiveui/website/main/docs/images/sponsors/openai.svg)](https://openai.com/codex/)
[![Sponsored by Snyk](https://raw.githubusercontent.com/reactiveui/website/e37a112f97ea2e9ea54b21bb7ed9e56df034d618/docs/images/sponsors/snyk.svg)](https://snyk.io/)

See [our sponsors](https://www.reactiveui.net/sponsors/) for more information.
JetBrains, Claude, Anthropic, OpenAI and Codex names and logos are trademarks of their respective owners.
Snyk and the Snyk logo are trademarks of Snyk Ltd.
