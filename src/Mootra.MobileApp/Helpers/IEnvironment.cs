using System.Drawing;

namespace Mootra.MobileApp.Helpers;

/// <summary>
/// Implements methods to execute during application state changes.
/// </summary>
public interface IEnvironment
{
    /// <summary>
    /// Sets the status bar color.
    /// </summary>
    /// <param name="color">The status bar color to set.</param>
    /// <param name="darkStatusBarTint">The status bar tint to set.</param>
    void SetStatusBarColor(Color color, bool darkStatusBarTint);
}
