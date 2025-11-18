using Amnil.TaskManagement.Samples;
using Xunit;

namespace Amnil.TaskManagement.EntityFrameworkCore.Domains;

[Collection(TaskManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TaskManagementEntityFrameworkCoreTestModule>
{

}
