using Amnil.TaskManagement.Localization;
using Volo.Abp.Application.Services;

namespace Amnil.TaskManagement;

/* Inherit your application services from this class.
 */
public abstract class TaskManagementAppService : ApplicationService
{
    protected TaskManagementAppService()
    {
        LocalizationResource = typeof(TaskManagementResource);
    }
}
