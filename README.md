# Groovebox — native app (WebView2)

A tiny native Windows app: one window, no browser tabs or address bar,
hosting Groovebox via Microsoft's built-in WebView2 engine (the same engine
behind Edge). No Electron, no ~150MB bundle.

## Build it yourself (Windows, needs the free .NET 8 SDK)

```
dotnet publish GrooveboxApp.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o publish
```

That produces one file: `publish\Groovebox.exe`. Double-click it — that's
the whole app, no installer needed.

## Build it automatically via GitHub (no local setup needed)

Push this folder to a repo. `.github/workflows/build.yml` runs on a Windows
GitHub runner, builds the exe, and attaches it under the Actions tab as a
downloadable artifact called `groovebox-native-exe`.

## One requirement for people running the app

It needs the **Microsoft Edge WebView2 Runtime**. This already ships with
Windows 11 and most up-to-date Windows 10 PCs — nothing to do. On an older
or stripped-down Windows install it's missing, in which case the app shows
a short message telling the person to grab it (one free download from
Microsoft, takes under a minute).

## Updating the app later

Edit `Groovebox.html` and rebuild — `Program.cs` doesn't need to change
unless you want to resize the window or change its title.
