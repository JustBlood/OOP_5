using EatThis.Bll;
using EatThis.Settings;

public class Program
{
    #region DI
    private static Configuration _configuration;

    private static Configuration SetConfiguration()
    {
        var configuration = new Configuration();
        return configuration;
    }

    private static IDiet CreateDiet()
    {
        var diet = _configuration.Container.GetInstance<IDiet>();
        /*
         * Todo: придумать, как сделать взаимодействие слоев в интерфейсах, убрать свойста IEnumerable и узнать, нужно ли вообще их убирать 
         * */
        //var diet = _configuration.Container.GetInstance<IDiet>();
        //diet.Name = "Новая диета";
        //var productNames = new List<string>() { "Молоко", "Яйца", "Мука", "Сахар", "Яблоки" };
        //var dish = _configuration.Container.GetInstance<IDish>();
        //dish.
        //foreach (var productName in productNames)
        //{
        //    var product = _configuration.Container.GetInstance<IProduct>();
        //    product.Name = productName;
        //    diet.GetDishes.Add(product);
        //}
        return null;

    }
    #endregion
    public static void Main(string[] args)
    {
        
    }

    private static void StartApp()
    {
        
    }
}