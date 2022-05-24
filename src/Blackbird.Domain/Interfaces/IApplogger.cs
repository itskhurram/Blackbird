namespace Blackbird.Domain.Interfaces {
    public interface IApplogger {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogVerbose(string message);
        void LogException(Exception ex);
        void LogExceptionWithSource(Exception ex, string source);
        void LogEnter();
        void LogExit();
    }
}
