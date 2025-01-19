namespace InjectingFunctions.ModuleOne.StrategyFunctions;

public class ModuleOneStrategy : IStrategy
{
    public bool CanHandle(ObjectRecord record)
    {
        if (record.ObjectType == ObjectType.Client)
        {
            return true;
        }

        return false;
    }

    public string Handle(ObjectRecord record) => "Processed by Module ONE";
}
