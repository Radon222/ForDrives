namespace ForDrives.Services.Interfaces
{
    public interface IDrivesService
    {
        bool ForLocalMachine { get; set; }
        bool LocalMachineAccessTest();
        string GetCurrentSettings();
        bool SaveNewSettings(string userInput);
        bool RemoveGlobalSettings();
    }
}
