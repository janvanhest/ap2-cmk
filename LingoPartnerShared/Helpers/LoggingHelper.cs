using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LingoPartnerShared.Helpers
{
  public static class LoggingHelper  // Marked as static
  {
    public static void LogError(Exception ex, string message, [CallerMemberName] string caller = "")
    {
      string logMessage = FormatLogMessage("Error", message, caller, ex);
      Trace.TraceError(logMessage);
    }
    public static void LogInformation(string message, [CallerMemberName] string caller = "", Exception? ex = null)
    {
      string logMessage = FormatLogMessage("Info", message, caller, ex ?? null);
      Trace.TraceInformation(logMessage);
    }
    public static void LogWarning(string message, [CallerMemberName] string caller = "", Exception? ex = null)
    {
      string logMessage = FormatLogMessage("Warning", message, caller, ex ?? null);
      Trace.TraceWarning(logMessage);
    }
    private static string FormatLogMessage(string logLevel, string message, string caller, Exception? ex = null)
    {
      string env = Environment.GetEnvironmentVariable("ENV") ?? "production";
      string logMessage = $"{env.ToUpper()}: {logLevel} in {caller}: {message}";

      if (env.Equals("development", StringComparison.OrdinalIgnoreCase))
      {
        if (ex != null)
        {
          logMessage += $"\nError message: {ex.Message}\nStack trace: {ex.StackTrace}";
        }
        Console.WriteLine(logMessage);
      }
      else
      {
        if (ex != null)
        {
          logMessage += $"\nError message: {ex.Message}";
        }
      }

      return logMessage;
    }
  }
}