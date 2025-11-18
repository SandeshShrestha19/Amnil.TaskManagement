using Amnil.TaskManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Amnil.TaskManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TaskManagementEntityFrameworkCoreModule),
    typeof(TaskManagementApplicationContractsModule)
)]
public class TaskManagementDbMigratorModule : AbpModule
{
}
