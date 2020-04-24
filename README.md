# MediaElementRepro 

## `SIGSEV` thrown on `AVFoundation.AVPlayer.Pause` During `Xamarin.Forms.Platform.iOS.MediaElementRenderer.Dispose`

When `Dispose` is called on `Xamarin.Forms.Platform.iOS.MediaElementRenderer`, a `SIGSEV`exception is thrown when [`_avPlayerViewController?.Player?.Pause();` is called](https://github.com/xamarin/Xamarin.Forms/blob/0fcb73afbf8fd5d1f9057d999de0af9494004837/Xamarin.Forms.Platform.iOS/Renderers/MediaElementRenderer.cs#L134).

### Reprodiction Steps

1. Download/clone this repository
2. In Visual Studio, open `MediaElementRepro.sln`
3. Build/Deploy `MediaElementRepro.iOS` to an iOS Simulator or Device
4. In the iOS app, verify the video is playing
5. In the iOS app, tap the `Open New Media Element Page` Button
6. In the iOS app, verify the video is playing
7. In the iOS app, tap the `Close` button
8. In Visual Studio, confirm a SIGSEV exception is thrown
9. If no exception has been thrown, repeat Steps 6-8
  - Note: Despite the crash, the video may continue to play on the iOS device. We can confirm the app has crashed by getting no response when tapping the `Open New Media Element Page` Button

### Stack Trace

```bash
 at <unknown> <0xffffffff>
	  at ObjCRuntime.Messaging:void_objc_msgSend <0x000e9>
	  at AVFoundation.AVPlayer:Pause <0x00122>
	  at Xamarin.Forms.Platform.iOS.MediaElementRenderer:Dispose <0x00253>
	  at Foundation.NSObject:Dispose <0x00074>
	  at Xamarin.Forms.Platform.iOS.VisualElementPackager:Dispose <0x002c5>
	  at Xamarin.Forms.Platform.iOS.VisualElementPackager:Dispose <0x00071>
	  at Xamarin.Forms.Platform.iOS.VisualElementRenderer`1:Dispose <0x0024a>
	  at Foundation.NSObject:Dispose <0x00074>
	  at Xamarin.Forms.Platform.iOS.VisualElementPackager:Dispose <0x002c5>
	  at Xamarin.Forms.Platform.iOS.VisualElementPackager:Dispose <0x00071>
	  at Xamarin.Forms.Platform.iOS.PageRenderer:Dispose <0x0041a>
	  at Foundation.NSObject:Dispose <0x00074>
	  at Xamarin.Forms.Platform.iOS.DisposeHelpers:DisposeModalAndChildRenderers <0x0030f>
	  at <Xamarin-Forms-INavigation-PopModalAsync>d__25:MoveNext <0x008d2>
	  at MoveNextRunner:InvokeMoveNext <0x000ab>
	  at System.Threading.ExecutionContext:RunInternal <0x00585>
	  at System.Threading.ExecutionContext:Run <0x00092>
	  at MoveNextRunner:Run <0x001aa>
	  at System.Threading.Tasks.AwaitTaskContinuation:InvokeAction <0x00093>
	  at System.Threading.Tasks.AwaitTaskContinuation:RunCallback <0x00153>
	  at System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation:Run <0x0013a>
	  at System.Threading.Tasks.Task:FinishContinuations <0x006a6>
	  at System.Threading.Tasks.Task:FinishStageThree <0x0015a>
	  at System.Threading.Tasks.Task`1:TrySetResult <0x0022a>
	  at System.Threading.Tasks.TaskCompletionSource`1:TrySetResult <0x00092>
	  at System.Threading.Tasks.TaskCompletionSource`1:SetResult <0x0007a>
	  at <>c__DisplayClass33_0:<DismissViewControllerAsync>b__0 <0x00082>
	  at SDAction:Invoke <0x00154>
	  at SDAction:Invoke <0x0010a>
	  at <unknown> <0xffffffff>
	  at UIKit.UIApplication:UIApplicationMain <0x00259>
	  at UIKit.UIApplication:Main <0x000b2>
	  at UIKit.UIApplication:Main <0x00132>
	  at MediaElementRepro.iOS.Application:Main <0x0007a>
	  at <Module>:runtime_invoke_void_object <0x00198>
   ```
   
   ## 2. 
   
   ## Environment
   === Visual Studio Enterprise 2019 for Mac ===

Version 8.5.4 (build 12)
Installation UUID: 8726d97c-8890-4b25-b8e6-17a149905e3c
	GTK+ 2.24.23 (Raleigh theme)
	Xamarin.Mac 6.14.1.39 (d16-5 / 30e8706b4)

	Package version: 608000123

=== Mono Framework MDK ===

Runtime:
	Mono 6.8.0.123 (2019-10/1d0d939dc30) (64-bit)
	Package version: 608000123

=== Roslyn (Language Service) ===

3.5.0-beta4-20125-04+1baa0b3063238ed752ad1f0368b1df6b6901373e

=== NuGet ===

Version: 5.4.0.6315

=== .NET Core SDK ===

SDK: /usr/local/share/dotnet/sdk/3.1.200/Sdks
SDK Versions:
	3.1.200
	3.1.102
	3.0.101
	2.1.803
MSBuild SDKs: /Library/Frameworks/Mono.framework/Versions/6.8.0/lib/mono/msbuild/Current/bin/Sdks

=== .NET Core Runtime ===

Runtime: /usr/local/share/dotnet/dotnet
Runtime Versions:
	5.0.0-preview.1.20120.5
	3.1.2
	3.1.1
	3.1.0
	3.0.3
	3.0.1
	2.1.17
	2.1.16
	2.1.15
	2.1.14

=== Xamarin.Profiler ===

Version: 1.6.13.11
Location: /Applications/Xamarin Profiler.app/Contents/MacOS/Xamarin Profiler

=== Updater ===

Version: 11

=== Apple Developer Tools ===

Xcode 11.4.1 (16137)
Build 11E503a

=== Xamarin.Mac ===

Version: 6.16.0.13 (Visual Studio Enterprise)
Hash: b75deaf82
Branch: d16-5-xcode11.4
Build date: 2020-04-01 21:33:18-0400

=== Xamarin.iOS ===

Version: 13.16.0.13 (Visual Studio Enterprise)
Hash: b75deaf82
Branch: d16-5-xcode11.4
Build date: 2020-04-01 21:33:19-0400

=== Xamarin Designer ===

Version: 16.5.0.471
Hash: 35aa4889d
Branch: remotes/origin/d16-5
Build date: 2020-02-25 00:52:08 UTC

=== Xamarin.Android ===

Version: 10.2.0.100 (Visual Studio Enterprise)
Commit: xamarin-android/d16-5/988c811
Android SDK: /Users/bramin/Library/Developer/Xamarin/android-sdk-macosx
	Supported Android versions:
		7.0 (API level 24)
		8.0 (API level 26)
		8.1 (API level 27)

SDK Tools Version: 26.1.1
SDK Platform Tools Version: 29.0.5
SDK Build Tools Version: 29.0.2

Build Information: 
Mono: c0c5c78
Java.Interop: xamarin/java.interop/d16-5@fc18c54
ProGuard: xamarin/proguard/master@905836d
SQLite: xamarin/sqlite/3.28.0@46204c4
Xamarin.Android Tools: xamarin/xamarin-android-tools/d16-5@9f4ed4b

=== Microsoft Mobile OpenJDK ===

Java SDK: /Users/bramin/Library/Developer/Xamarin/jdk/microsoft_dist_openjdk_1.8.0.25
1.8.0-25
Android Designer EPL code available here:
https://github.com/xamarin/AndroidDesigner.EPL

=== Android SDK Manager ===

Version: 16.5.0.39
Hash: 6fb4c79
Branch: remotes/origin/d16-5
Build date: 2020-04-15 20:49:08 UTC

=== Android Device Manager ===

Version: 16.5.0.71
Hash: 49194e8
Branch: remotes/origin/d16-5~1
Build date: 2020-04-15 20:49:28 UTC

=== Xamarin Inspector ===

Version: 1.4.3
Hash: db27525
Branch: 1.4-release
Build date: Mon, 09 Jul 2018 21:20:18 GMT
Client compatibility: 1

=== Build Information ===

Release ID: 805040012
Git revision: 7642369422103e19b0b8d29ddc211abf2fd32607
Build date: 2020-04-16 08:55:15-04
Build branch: release-8.5
Xamarin extensions: 7642369422103e19b0b8d29ddc211abf2fd32607

=== Operating System ===

Mac OS X 10.15.4
Darwin 19.4.0 Darwin Kernel Version 19.4.0
    Wed Mar  4 22:28:40 PST 2020
    root:xnu-6153.101.6~15/RELEASE_X86_64 x86_64

