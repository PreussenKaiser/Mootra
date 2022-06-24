using Android.App;
using Android.Runtime;

namespace Mootra.Blazor;

/// <summary>
/// 
/// </summary>
[Application]
public class MainApplication : MauiApplication
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="handle"></param>
	/// <param name="ownership"></param>
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	protected override MauiApp CreateMauiApp()
		=> MauiProgram.CreateMauiApp();
}
