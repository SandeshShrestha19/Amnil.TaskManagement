using Amnil.TaskManagement.Samples;
using Xunit;

namespace Amnil.TaskManagement.EntityFrameworkCore.Applications;

[Collection(TaskManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TaskManagementEntityFrameworkCoreTestModule>
{

}
