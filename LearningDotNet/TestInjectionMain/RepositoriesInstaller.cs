using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace TestInjectionMain
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(Component.IsInSameNamespaceAs<Mapper>())
                .WithService.DefaultInterfaces().
                LifestyleTransient());
        }
    }
}