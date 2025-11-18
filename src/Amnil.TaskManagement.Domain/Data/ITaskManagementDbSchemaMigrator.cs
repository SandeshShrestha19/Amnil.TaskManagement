using System.Threading.Tasks;

namespace Amnil.TaskManagement.Data;

public interface ITaskManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
