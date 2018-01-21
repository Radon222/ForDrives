namespace ForDrives.Services.Interfaces
{
    public interface IInterpretationService
    {
        int ToNumber(string letters);
        string ToLetters(int number);
    }
}
