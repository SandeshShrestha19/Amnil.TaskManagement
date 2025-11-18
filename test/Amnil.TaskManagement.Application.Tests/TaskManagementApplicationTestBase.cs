using Volo.Abp.Modularity;

namespace Amnil.TaskManagement;

public abstract class TaskManagementApplicationTestBase<TStartupModule> : TaskManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
