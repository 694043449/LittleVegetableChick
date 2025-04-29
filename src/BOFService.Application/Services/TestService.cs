using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Settings;

namespace Yi.Abp.Application.Services
{
    /// <summary>
    /// 常用魔改及扩展示例
    /// </summary>
    public class TestService : ApplicationService
    {
        /// <summary>
        /// </summary>
        /// <param name="name">ggg</param>
        /// <returns></returns>
        [HttpGet("hello-world")]
        public string GetHelloWorld(string? name)
        {
            //会自动添加前缀，而不是重置，更符合习惯
            //如果需要重置以"/"根目录开头即可
            //你好世界
            return name ?? "HelloWord";
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <returns></returns>
        [HttpGet("error")]
        public string GetError()
        {
            throw new UserFriendlyException("业务异常");
            throw new Exception("系统异常");
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        public void GetCurrentUser()
        {
            //当token鉴权之后，可以直接获取
            if (CurrentUser.Id is not null)
            {
                //权限
                // CurrentUser.GetPermissions();

                //角色信息
                // CurrentUser.GetRoleInfo();

                //部门id
                // CurrentUser.GetDeptId();
            }
        }

        /// <summary>
        /// 数据权限
        /// </summary>
        public void GetDataFilter()
        {
            //这里会数据权限过滤
            // using (DataFilter.DisablePermissionHandler())
            {
                //这里不会数据权限过滤
            }
            //这里会数据权限过滤
        }

        private static int RequestNumber { get; set; } = 0;

        /// <summary>
        /// 速率限制
        /// </summary>
        /// <returns></returns>
        // [DisableRateLimiting]
        //[EnableRateLimiting("sliding")]
        public int GetRateLimiting()
        {
            RequestNumber++;
            return RequestNumber;
        }


        public ISettingProvider _settingProvider { get; set; }
        
        /// <summary>
        /// 分布式送abp版本：abp套了一层娃。但是纯粹鸡肋，不建议使用这个
        /// </summary>
        public IAbpDistributedLock AbpDistributedLock => LazyServiceProvider.LazyGetService<IAbpDistributedLock>();

        /// <summary>
        /// 分布式锁推荐使用版本：yyds，分布式锁永远的神！
        /// </summary>
        // public IDistributedLockProvider DistributedLock => LazyServiceProvider.LazyGetService<IDistributedLockProvider>();

        /// <summary>
        /// 分布式锁
        /// </summary>
        /// <remarks>强烈吐槽一下abp，正如他们所说，abp的分布式锁单纯为了自己用，一切还是以DistributedLock为主</remarks>>
        /// <returns></returns>
        // public async Task<string> GetDistributedLockAsync()
        // {
        //     var number = 0;
        //     await Parallel.ForAsync(0, 100, async (i, cancellationToken) =>
        //     {
        //         await using (await DistributedLock.AcquireLockAsync("MyLockName"))
        //         {
        //             //执行1秒
        //             number += 1;
        //         }
        //     });
        //     var number2 = 0;
        //     await Parallel.ForAsync(0, 100, async (i, cancellationToken) =>
        //     {
        //             //执行1秒
        //             number2 += 1;
        //     });
        //     return $"加锁结果：{number},不加锁结果：{number2}";
        // }
    }
}