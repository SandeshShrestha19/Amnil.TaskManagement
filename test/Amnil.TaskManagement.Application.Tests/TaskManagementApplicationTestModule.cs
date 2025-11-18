using Volo.Abp.Modularity;

namespace Amnil.TaskManagement;

[DependsOn(
    typeof(TaskManagementApplicationModule),
    typeof(TaskManagementDomainTestModule)
)]
public class TaskManagementApplicationTestModule : AbpModule
{

}
