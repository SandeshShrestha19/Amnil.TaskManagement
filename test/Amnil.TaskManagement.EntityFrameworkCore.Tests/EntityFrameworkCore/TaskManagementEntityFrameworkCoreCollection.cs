using Xunit;

namespace Amnil.TaskManagement.EntityFrameworkCore;

[CollectionDefinition(TaskManagementTestConsts.CollectionDefinitionName)]
public class TaskManagementEntityFrameworkCoreCollection : ICollectionFixture<TaskManagementEntityFrameworkCoreFixture>
{

}
