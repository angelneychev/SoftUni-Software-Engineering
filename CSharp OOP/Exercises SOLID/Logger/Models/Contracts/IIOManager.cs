namespace Logger.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPach { get; }

        string CurrentFilePach { get; }

        void EnsureDirectoryAndFileExist();

        string GetCurrentPath();
    }
}
