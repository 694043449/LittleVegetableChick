using Microsoft.Extensions.Logging;
using SqlSugar;
using Volo.Abp.DependencyInjection;
using Yi.Framework.SqlSugarCore;

namespace BOFService.SqlSugarCore
{
    public class BofServiceDbContext : SqlSugarDbContext
    {
        public BofServiceDbContext(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
        {
        }
    }
}
