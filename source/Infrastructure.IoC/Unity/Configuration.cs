using Application.Example.Contract;
using Microsoft.Practices.Unity;

namespace Infrastructure.IoC.Unity
{
    public class Configuration
    {
        public static IUnityContainer GetContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled,
                overwriteExistingMappings:true);

            // Manual Mappings
            container.RegisterType<IConversationRepository, Data.EntityFramework.Conversations.ConversationRepository>();
            
            return container;
        }
    }
}