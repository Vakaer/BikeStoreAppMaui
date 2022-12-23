using BikeStore.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.App
{
    public static class MauiAppBuilderExtension
    {
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            // Transient objects lifetime services are created each time they are requested.
            // This lifetime works best for lightweight, stateless services.
            foreach (var type in currentAssembly.DefinedTypes.Where(e => e.IsSubclassOf(typeof(Page)) || e.IsSubclassOf(typeof(BaseViewModel))))
            {
                builder.Services.AddTransient(type.AsType());
            }
            return builder;
        }
    }
}
