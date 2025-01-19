namespace InjectingFunctions;

public interface IStrategy
{
    bool CanHandle(ObjectRecord record);

    string Handle(ObjectRecord record);
}
