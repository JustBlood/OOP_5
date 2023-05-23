using EatThis.Bll;
using SimpleInjector;

namespace EatThis.Settings
{
    public class Configuration
    {
        public Container Container { get; }

        public Configuration()
        {
            Container = new Container();

            Setup();
        }

        public virtual void Setup()
        {
            Container.Register<IDiet, Diet>(Lifestyle.Transient);
            Container.Register<IUser, User>(Lifestyle.Transient);
            Container.Register<IProduct, Product>(Lifestyle.Transient);
            Container.Register<IDish, Dish>(Lifestyle.Transient);
        }

    }
}