using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using BOFService.Domain.Entities;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.SqlSugarCore.DataSeeds
{
    public class UserDataSeed : IDataSeedContributor, ITransientDependency
    {
        private ISqlSugarRepository<UserInfo> _repository;
        
        // 构造函数，注入需要的依赖
        public UserDataSeed(ISqlSugarRepository<UserInfo> repository)
        {
            _repository = repository;
        }
        
        // 实现SeedAsync方法，用于添加种子数据
        public async Task SeedAsync(DataSeedContext context)
        {
            // 检查表是否已有数据，如无则添加种子数据
            if (!await _repository.IsAnyAsync(x => true))
            {
                await _repository.InsertManyAsync(GetSeedData());
            }
        }
        
        // 创建种子数据列表
        public List<UserInfo> GetSeedData()
        {
            var entities = new List<UserInfo>();
            
            // 创建超级管理员
            UserInfo admin = new UserInfo()
            {
                UserName = "admin",
                UserPassword = "21232F297A57A5A743894A0E4A801FC3", // admin的MD5值
                RoleId = 1, // 超级管理员角色ID
                PartName = "系统管理部",
                WorkerName = "超级管理员",
                UserCondition = 1, // 正常状态
                CreateTime = DateTime.Now
            };
            entities.Add(admin);
            
            return entities;
        }
    }
}