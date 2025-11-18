using Microsoft.Extensions.Localization;
using Amnil.TaskManagement.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Amnil.TaskManagement;

[Dependency(ReplaceServices = true)]
public class TaskManagementBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TaskManagementResource> _localizer;

    public TaskManagementBrandingProvider(IStringLocalizer<TaskManagementResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
