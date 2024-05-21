Tester.Test();

public class Activity
{
    public int Price { get; set; }
    public string Name { get; set; }
    public Activity(string name) { Name = name; }
}

public class VacationConfigurator
{
    public string Destination { get; private set; }
    private List<Activity> additionalActivities = new List<Activity>();

    public decimal CalculateTotal()
    {
        return additionalActivities.Sum(it => it.Price);
    }

    public void AddExtra(Activity activity)
    {
        additionalActivities.Add(activity);
    }

    public void Remove(Activity activity)
    {
        additionalActivities.Remove(activity);
    }

    public void LoadPrevious(VacationConfiguration configuration)
    {
        Destination = configuration.GetDestination();
        additionalActivities.Clear();
        additionalActivities.AddRange(configuration.GetAdditionalActivities());
    }

    public VacationConfiguration Store()
    {
        return new VacationConfiguration(Destination, additionalActivities);
    }
}

public class VacationConfiguration
{
    private string destination;
    private List<Activity> additionalActivities;
    public VacationConfiguration(string destination, List<Activity> additionalActivities)
    {
        this.destination = destination;
        this.additionalActivities = additionalActivities;
    }
    public string GetDestination()
    {
        return destination;
    }

    public List<Activity> GetAdditionalActivities()
    {
        return additionalActivities;
    }
}

public class ConfigurationManager
{
    private List<VacationConfiguration> configurations = new List<VacationConfiguration>();

    public void AddConfiguration(VacationConfiguration configuration)
    {
        configurations.Add(configuration);
    }

    public void DeleteConfiguration(VacationConfiguration configuration)
    {
        configurations.Remove(configuration);
    }

    public VacationConfiguration GetConfiguration(int index)
    {
        return configurations[index];
    }
}

public class Tester
{
    
        public static void Test()
        {
            TestCreateActivities();
            TestAddActivitiesAndCalculateTotal();
            TestRemoveActivityAndRecalculateTotal();
            TestStoreAndLoadConfiguration();
            TestManageConfigurations();
        }

        public static void TestCreateActivities()
        {
            Activity activity1 = new Activity("Skiing") { Price = 100 };
            Activity activity2 = new Activity("Snowboarding") { Price = 150 };
            Console.WriteLine($"Activity 1: {activity1.Name}, Price: {activity1.Price}");  
            Console.WriteLine($"Activity 2: {activity2.Name}, Price: {activity2.Price}");  
        }

        public static void TestAddActivitiesAndCalculateTotal()
        {
            VacationConfigurator configurator = new VacationConfigurator();
            Activity activity1 = new Activity("Skiing") { Price = 100 };
            Activity activity2 = new Activity("Snowboarding") { Price = 150 };
            configurator.AddExtra(activity1);
            configurator.AddExtra(activity2);
            decimal total = configurator.CalculateTotal();
            Console.WriteLine($"Total Price: {total}");  
        }

        public static void TestRemoveActivityAndRecalculateTotal()
        {
            VacationConfigurator configurator = new VacationConfigurator();
            Activity activity1 = new Activity("Skiing") { Price = 100 };
            Activity activity2 = new Activity("Snowboarding") { Price = 150 };
            configurator.AddExtra(activity1);
            configurator.AddExtra(activity2);
            configurator.Remove(activity1);
            decimal total = configurator.CalculateTotal();
            Console.WriteLine($"Total Price after removal: {total}");  
        }

        public static void TestStoreAndLoadConfiguration()
        {
            VacationConfigurator configurator = new VacationConfigurator();
            Activity activity1 = new Activity("Skiing") { Price = 100 };
            configurator.LoadPrevious(new VacationConfiguration("Mountain", new List<Activity> { activity1 }));
            VacationConfiguration storedConfig = configurator.Store();
            Console.WriteLine($"Stored Configuration Destination: {storedConfig.GetDestination()}");  
        }

        public static void TestManageConfigurations()
        {
            Activity activity1 = new Activity("Skiing") { Price = 100 };
            VacationConfiguration config = new VacationConfiguration("Mountain", new List<Activity> { activity1 });
            ConfigurationManager manager = new ConfigurationManager();
            manager.AddConfiguration(config);
            VacationConfiguration loadedConfig = manager.GetConfiguration(0);
            Console.WriteLine($"Loaded Configuration Destination: {loadedConfig.GetDestination()}");  
            manager.DeleteConfiguration(loadedConfig);
            try
            {
                Console.WriteLine($"Configuration Count after Deletion: {(manager.GetConfiguration(0) == null ? 0 : 1)}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Configuration Count after Deletion: 0");  
            }
        }
}
