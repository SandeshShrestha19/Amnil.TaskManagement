using Volo.Abp.Modularity;

namespace Amnil.TaskManagement;

[DependsOn(
    typeof(TaskManagementDomainModule),
    typeof(TaskManagementTestBaseModule)
)]
public class TaskManagementDomainTestModule : AbpModule
{

}
