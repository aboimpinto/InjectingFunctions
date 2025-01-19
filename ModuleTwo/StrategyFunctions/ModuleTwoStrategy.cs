namespace InjectingFunctions.ModuleTwo.StrategyFunctions;

public class ModuleTwoStrategy : IStrategy
{
    public bool CanHandle(ObjectRecord record)
    {
        if (record.ObjectType == ObjectType.Supplier)
        {
            return true;
        }

        return false;
    }

    public string Handle(ObjectRecord record) => "Processed by Module TWO";
}
