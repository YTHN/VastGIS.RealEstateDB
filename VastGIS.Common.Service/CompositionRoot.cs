using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Concrete;
using VastGIS.Common.Services.Helpers;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Services.Views;
using VastGIS.Common.Services.Views.Abstract;
using VastGIS.Common.Shared;
using VastGIS.Common.Shared.Log;

namespace VastGIS.Common.Services
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterService<IFileDialogService, FileDialogService>()
                .RegisterService<IMessageService, MessageService>() // FlexibleMessageService

                .RegisterSingleton<ILoggingService, LoggingService>()

                .RegisterSingleton<IProjectService, ProjectService>()

                .RegisterService<ImageSerializationService>()
                .RegisterService<ProjectLoaderLegacy>()
                .RegisterSingleton<ITempFileService, TempFileService>()
                .RegisterSingleton<IConfigService, ConfigService>()
                .RegisterSingleton<IProjectLoader, ProjectLoader>()
                .RegisterView<IMissingLayersView, MissingLayersView>();
              

            EnumHelper.RegisterConverter(new SelectionOperationConverter());
            EnumHelper.RegisterConverter(new AreaUnitsConverter());
            EnumHelper.RegisterConverter(new LogLevelConverter());
            EnumHelper.RegisterConverter(new GeometryTypeConverter());
            EnumHelper.RegisterConverter(new SaveResultConverter());
            EnumHelper.RegisterConverter(new TileProviderConverter());
            EnumHelper.RegisterConverter(new InterpolationTypeConverter());
            EnumHelper.RegisterConverter(new RasterOverviewSamplingConverter());
            EnumHelper.RegisterConverter(new RasterOverviewTypeConverter());
            EnumHelper.RegisterConverter(new DynamicVisiblityModeConverter());
        }
    }
}
