using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOFService.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.SqlSugarCore.DataSeeds
{
    public class SysInfoDataSeed : IDataSeedContributor, ITransientDependency
    {
        private readonly ISqlSugarRepository<SysInfo> _repository;

        public SysInfoDataSeed(ISqlSugarRepository<SysInfo> repository)
        {
            _repository = repository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await _repository.IsAnyAsync(x => true))
            {
                await _repository.InsertManyAsync(GetSeedData());
            }
        }

        private List<SysInfo> GetSeedData()
        {
            var entities = new List<SysInfo>();
            DateTime now = DateTime.Now;

            // 创建种子数据辅助方法
            void AddConfig(string keyName, string keyValue, string keyGroup, string keyMemo)
            {
                entities.Add(new SysInfo
                {
                    KeyName = keyName,
                    KeyValue = keyValue,
                    KeyGroup = keyGroup,
                    KeyMemo = keyMemo,
                    CreateTime = now,
                    EditTime = now,
                    CreationTime = now
                });
            }

            // 氧枪设备相关配置
            AddConfig("cvt_eqt_oyg_gun_no1", "1号枪", "cvt_eqt", "1#氧枪枪号");
            AddConfig("cvt_eqt_oyg_gun_age1", "1", "cvt_eqt", "1#氧枪枪龄");
            AddConfig("cvt_eqt_oyg_gun_no2", "2号枪", "cvt_eqt", "2#氧枪枪号");
            AddConfig("cvt_eqt_oyg_gun_age2", "2", "cvt_eqt", "2#氧枪枪龄");
            AddConfig("cvt_eqt_age_bgn_no", "00001", "cvt_eqt", "炉龄起始炉号");
            AddConfig("cvt_eqt_age_bgn_cnt", "0", "cvt_eqt", "炉龄起始次数");
            AddConfig("cvt_eqt_age_real_cnt", "0", "cvt_eqt", "炉龄实际使用次数");
            AddConfig("cvt_eqt_out_bgn_no", "001", "cvt_eqt", "出钢口起始炉号");
            AddConfig("cvt_eqt_out_bgn_cnt", "0", "cvt_eqt", "出钢口起始次数");
            AddConfig("cvt_eqt_out_real_cnt", "0", "cvt_eqt", "出钢口实际使用次数");

            // 系统基础配置
            AddConfig("sys_base_item_none1", "无", "sys_base", "下拉列表默认选项");
            AddConfig("sys_base_item_none2", "未选择", "sys_base", "下拉列表默认选项");
            AddConfig("sys_base_item_none3", "空仓", "sys_base", "下拉列表默认选项");
            AddConfig("sys_base_item_none4", "未设置", "sys_base", "下拉列表默认选项");

            // 料仓类型配置
            AddConfig("stock_branch_type1", "顶渣料仓", "stock_branch_type", "料仓类型1");
            AddConfig("stock_branch_type2", "转炉料仓", "stock_branch_type", "料仓类型2");

            // 熔剂料仓配置
            for (int i = 1; i <= 12; i++)
            {
                AddConfig($"stock_branch_flux{i}", "none", "stock_branch_flux", $"熔剂料仓{i}");
            }

            // 熔剂料仓类型配置
            for (int i = 1; i <= 12; i++)
            {
                AddConfig($"stock_branch_flux_type{i}", "none", "stock_branch_flux_type", $"熔剂料仓类型{i}");
            }

            // 合金料仓配置
            for (int i = 1; i <= 12; i++)
            {
                AddConfig($"stock_branch_aly{i}", "none", "stock_branch_aly", $"合金料仓{i}");
            }

            // 炉钢相关配置
            AddConfig("cvt_stl_history_save_time", "12", "cvt_stl", "数据库自动备份时间");
            AddConfig("cvt_stl_auto_blow_time", "0", "cvt_stl", "判定自动炼钢吹炼时间");
            AddConfig("cvt_stl_auto_putin_rate", "0", "cvt_stl", "判定自动炼钢投入比率");
            AddConfig("cvt_stl_auto_mode", "0", "cvt_stl", "自动炼钢模式0基于副枪智慧炼钢1基于烟气分析智慧炼钢");
            AddConfig("cvt_stl_stc_study", "false", "cvt_stl", "自动静态自学习");
            AddConfig("cvt_stl_dyc_study", "false", "cvt_stl", "自动动态自学习");
            AddConfig("cvt_stl_stc_cpt_mode", "0", "cvt_stl", "静态计算模式0静态基底计算1静态增量计算2静态综合计算");
            AddConfig("cvt_stl_base_cpt_cft", "0", "cvt_stl", "基底计算系数");
            AddConfig("cvt_stl_add_cpt_cft", "0", "cvt_stl", "增量计算系数");
            AddConfig("cvt_stl_get_dft_rate", "0", "cvt_stl", "钢水收得率默认值");
            AddConfig("cvt_stl_std_wgt", "0", "cvt_stl", "标准配置计算模式下标准钢水重量");
            AddConfig("cvt_stl_aly_get_rate1", "0", "cvt_stl", "合金收得率参数1");
            AddConfig("cvt_stl_aly_get_rate2", "0", "cvt_stl", "合金收得率参数2");
            AddConfig("cvt_stl_aly_get_rate3", "0", "cvt_stl", "合金收得率参数3");
            AddConfig("cvt_stl_aly_cpt_mode", "0", "cvt_stl", "合金计算模式0原始原素守恒计算1标准配置计算2线性规划计算");
            AddConfig("cvt_stl_cpt_oyg_mtl", "false", "cvt_stl", "预先计算并下发氧步和料步");
            AddConfig("cvt_stl_auto_dyc_oyg", "false", "cvt_stl", "自动下发动态氧步");
            AddConfig("cvt_stl_dft_mtl_wgt", "0", "cvt_stl", "默认铁水加料重量");
            
            // 除渣角度和时间配置
            for (int i = 1; i <= 4; i++)
            {
                AddConfig($"cvt_stl_deslagging_L{i}_agl", "0", "cvt_stl", $"L{i}角度");
                AddConfig($"cvt_stl_deslagging_L{i}_time", "0", "cvt_stl", $"L{i}时间");
            }

            // TSC相关配置
            AddConfig("cvt_stl_tsc_tmp_max", "0", "cvt_stl", "TSC温度最大值");
            AddConfig("cvt_stl_tsc_tmp_min", "0", "cvt_stl", "TSC温度最小值");
            AddConfig("cvt_stl_tsc_c_max", "0", "cvt_stl", "TSC碳最大值");
            AddConfig("cvt_stl_tsc_c_min", "0", "cvt_stl", "TSC碳最小值");
            
            // 其他炉钢限值配置
            AddConfig("cvt_stl_smp_p_max", "0", "cvt_stl", "钢样P最大值");
            AddConfig("cvt_stl_srp_max", "0", "cvt_stl", "铁废比最大值");
            AddConfig("cvt_stl_srp_min", "0", "cvt_stl", "铁废比最小值");
            AddConfig("cvt_stl_irn_tmp_min", "0", "cvt_stl", "铁水温度最小值");
            AddConfig("cvt_stl_irn_si_max", "0", "cvt_stl", "铁水硅最大值");
            AddConfig("cvt_stl_end_c_max", "0", "cvt_stl", "终点命中[C]偏差值");
            AddConfig("cvt_stl_end_tmp_max", "0", "cvt_stl", "终点命中温度偏差值");
            AddConfig("cvt_stl_stop_max", "0", "cvt_stl", "转炉停炉时长最大值");
            AddConfig("cvt_stl_last_tmp_max", "0", "cvt_stl", "铁水最后测温时间到装炉兑铁水时长最大值");
            AddConfig("cvt_stl_gun_down_oyg", "0", "cvt_stl", "下枪氧步预留氧量");
            AddConfig("cvt_stl_gun_up_oyg", "0", "cvt_stl", "提枪氧步预留氧量");

            // 铁水标准成分配置
            string[] elements = { "c", "si", "mn", "p", "s" };
            string[] types = { "min", "std", "max" };
            
            for (int i = 1; i <= 2; i++)
            {
                foreach (var element in elements)
                {
                    foreach (var type in types)
                    {
                        AddConfig($"irn_std_{element}{i}_{type}", "0", "irn_std", $"{ (i == 1 ? "铁水" : "生铁") }成分{element.ToUpper()}{ (type == "min" ? "最小" : type == "std" ? "标准" : "最大") }值");
                    }
                }
            }

            // 铁水温度标准配置
            AddConfig("irn_std_tmp_min", "0", "irn_std", "标准铁水温度最小值");
            AddConfig("irn_std_tmp_std", "0", "irn_std", "标准铁水温度标准值");
            AddConfig("irn_std_tmp_max", "0", "irn_std", "标准铁水温度最大值");
            
            // 铁水配比模式配置
            AddConfig("irn_std_match_mode", "0", "irn_std", "铁水废钢配比模式0出钢量不变1出钢量可变");
            AddConfig("irn_std_source_mode", "0", "irn_std", "铁水来源方式0大罐折罐1混铁炉2一罐制度");

            // 铁水温降配置
            AddConfig("irn_tmp_nos_down", "0", "irn_tmp", "不脱硫标准温降");
            AddConfig("irn_tmp_afts_down", "0", "irn_tmp", "脱硫后标准温降");
            
            for (int i = 3; i <= 5; i++)
            {
                AddConfig($"irn_tmp_path{i}_down", "0", "irn_tmp", $"路径{i}标准温降");
            }
            
            // 铁水等待时间配置
            AddConfig("irn_tmp_nos_time", "0", "irn_tmp", "不脱硫测温后标准等待时长");
            AddConfig("irn_tmp_afts_time", "0", "irn_tmp", "脱硫后测温后标准等待时长");
            
            for (int i = 3; i <= 5; i++)
            {
                AddConfig($"irn_tmp_path{i}_time", "0", "irn_tmp", $"路径{i}测温后标准等待时长");
            }
            
            // 铁水等待时间调整
            AddConfig("irn_tmp_wait_more", "0", "irn_tmp", "等待时间比标准时间多几分钟");
            AddConfig("irn_tmp_wait_less", "0", "irn_tmp", "等待时间比标准时间少几分钟");

            // 钢水温度时间段配置
            string[] cvtNum = { "one", "two", "three" };
            
            foreach (var num in cvtNum)
            {
                for (int i = 1; i <= 5; i++)
                {
                    string timeRange = i == 1 ? "小于45分钟" :
                                      i == 2 ? "45至90分钟" :
                                      i == 3 ? "90至135分钟" :
                                      i == 4 ? "135至180分钟" :
                                      "大于180分钟";
                    
                    AddConfig($"stl_tmp_{num}_cvt{i}", "0", "stl_tmp", $"第{(num == "one" ? "一" : num == "two" ? "二" : "三")}炉{timeRange}");
                }
            }

            // 包修正配置
            AddConfig("stl_tmp_middle_cvt", "0", "stl_tmp", "中包第一炉校正");
            AddConfig("stl_tmp_big_delay", "0", "stl_tmp", "大包延误时间系数");
            
            // 炉况侵蚀配置
            AddConfig("stl_tmp_cvt_ser", "0", "stl_tmp", "炉衬严重侵蚀");
            AddConfig("stl_tmp_cvt_mid", "0", "stl_tmp", "炉衬中度侵蚀");
            AddConfig("stl_tmp_cvt_lgt", "0", "stl_tmp", "炉衬轻度侵蚀");
            
            // 钢包烘烤配置
            AddConfig("stl_tmp_bbq_hgh", "0", "stl_tmp", "钢包烘烤高温");
            AddConfig("stl_tmp_bbq_mid", "0", "stl_tmp", "钢包烘烤中温");
            AddConfig("stl_tmp_bbq_low", "0", "stl_tmp", "钢包烘烤低温");
            
            // 钢包结渣配置
            AddConfig("stl_tmp_slag_ser", "0", "stl_tmp", "钢包结渣严重");
            AddConfig("stl_tmp_slag_mid", "0", "stl_tmp", "钢包结渣中等");
            AddConfig("stl_tmp_slag_lgt", "0", "stl_tmp", "钢包结渣较低");
            
            // 钢包残钢配置
            AddConfig("stl_tmp_scrap_ser", "0", "stl_tmp", "钢包残钢多");
            AddConfig("stl_tmp_scrap_mid", "0", "stl_tmp", "钢包残钢中");
            AddConfig("stl_tmp_scrap_lgt", "0", "stl_tmp", "钢包残钢少");
            
            // 出钢时间配置
            AddConfig("stl_tmp_std_time", "0", "stl_tmp", "出钢标准时间");
            AddConfig("stl_tmp_time_ctf", "0", "stl_tmp", "出钢时间修正系数");
            AddConfig("stl_tmp_use_tab", "0", "stl_tmp", "出钢采用查表法0不采用1采用");
            
            // 出钢时间减量配置
            for (int i = 1; i <= 10; i++)
            {
                AddConfig($"stl_tmp_minus_min{i}", "0", "stl_tmp", $"出钢-{i}分钟");
            }
            
            // 浇铸节奏配置
            AddConfig("stl_tmp_cast_fast", "0", "stl_tmp", "浇铸节奏快");
            AddConfig("stl_tmp_cast_fa", "0", "stl_tmp", "浇铸节奏较快");
            AddConfig("stl_tmp_cast_slow", "0", "stl_tmp", "浇铸节奏慢");
            AddConfig("stl_tmp_cast_sl", "0", "stl_tmp", "浇铸节奏较慢");
            
            // 炉龄修正配置
            for (int i = 1; i <= 10; i++)
            {
                AddConfig($"stl_tmp_cvt_crt{i}", "0", "stl_tmp", $"炉龄修正{i * 1000}次");
            }
            
            // 因素修正限值
            AddConfig("stl_tmp_ele_max", "0", "stl_tmp", "每个因素修正最大值");
            AddConfig("stl_tmp_ele_min", "0", "stl_tmp", "每个因素修正最小值");
            
            // 静态计算配置
            AddConfig("stc_cpt_empty_cold1", "0", "stc_cpt", "空炉冷却能60至120");
            AddConfig("stc_cpt_empty_cold2", "0", "stc_cpt", "空炉冷却能120至180");
            AddConfig("stc_cpt_empty_cold3", "0", "stc_cpt", "空炉冷却能大于180");
            
            // 氧单耗系数配置
            AddConfig("stc_cpt_oyg_ctf1", "0", "stc_cpt", "氧单耗系数60至120");
            AddConfig("stc_cpt_oyg_ctf2", "0", "stc_cpt", "氧单耗系数120至180");
            AddConfig("stc_cpt_oyg_ctf3", "0", "stc_cpt", "氧单耗系数大于180");
            
            // 冷却能相关系数配置
            for (int i = 1; i <= 8; i++)
            {
                string factor = i == 1 ? "铁水C" : 
                               i == 2 ? "铁水Si" : 
                               i == 3 ? "铁水Mn" : 
                               i == 4 ? "铁水温度" : 
                               i == 5 ? "终点C" : 
                               i == 6 ? "终点温度" : 
                               i == 7 ? "铁水比" : 
                               "生铁";
                
                AddConfig($"stc_cpt_cold_ctf{i}", "0", "stc_cpt", $"冷却能{factor}");
            }
            
            // 铁水氧单耗系数配置
            for (int i = 1; i <= 4; i++)
            {
                string factor = i == 1 ? "铁水C" : 
                               i == 2 ? "铁水Si" : 
                               i == 3 ? "铁水Mn" : 
                               "终点C";
                
                AddConfig($"stc_cpt_irn_ctf{i}", "0", "stc_cpt", $"铁水氧单耗{factor}");
            }
            
            // 终点碳计算参数配置
            for (int i = 1; i <= 10; i++)
            {
                AddConfig($"stc_cpt_endc_par{i}", "0", "stc_cpt", $"终点碳计算参数{i}");
            }
            
            // 实践范围相关配置
            string[] mtlLabels = { "铁水量", "废钢量", "生铁量" };
            
            for (int i = 1; i <= 3; i++)
            {
                AddConfig($"pra_rag_mtl_max{i}", "0", "pra_rag", $"{mtlLabels[i-1]}最大值");
                AddConfig($"pra_rag_mtl_tgt{i}", "0", "pra_rag", $"{mtlLabels[i-1]}标准值");
                AddConfig($"pra_rag_mtl_min{i}", "0", "pra_rag", $"{mtlLabels[i-1]}最小值");
            }
            
            // 终点温度范围
            AddConfig("pra_rag_tmp_max", "0", "pra_rag", "终点温度最大值");
            AddConfig("pra_rag_tmp_tgt", "0", "pra_rag", "终点温度标准值");
            AddConfig("pra_rag_tmp_min", "0", "pra_rag", "终点温度最小值");
            
            // 氧气范围
            AddConfig("pra_rag_oyg_max1", "0", "pra_rag", "总供氧量最大值");
            AddConfig("pra_rag_oyg_max2", "0", "pra_rag", "动态供氧量最大值");
            AddConfig("pra_rag_oyg_min1", "0", "pra_rag", "总供氧量最小值");
            AddConfig("pra_rag_oyg_min2", "0", "pra_rag", "动态供氧量最小值");
            
            // 校正参数
            AddConfig("pra_rag_tmp_cpt", "0", "pra_rag", "计算校正温度最大值");
            AddConfig("pra_rag_cao_crt", "0", "pra_rag", "倒全渣CaO修正");
            AddConfig("pra_rag_cold_crt", "0", "pra_rag", "倒全渣冷却能修正");
            AddConfig("pra_rag_p_crt", "0", "pra_rag", "铁水P对石灰修正系数");
            
            // 留渣参数
            AddConfig("pra_rag_stay_rs", "0", "pra_rag", "留渣RS");
            AddConfig("pra_rag_stay_os", "0", "pra_rag", "留渣OS");
            AddConfig("pra_rag_stay_r", "0", "pra_rag", "留渣R修正");
            AddConfig("pra_rag_stay_dft", "0", "pra_rag", "默认留渣量");
            
            // 双渣参数
            AddConfig("pra_rag_double_rs1", "0", "pra_rag", "双渣RS");
            AddConfig("pra_rag_double_rs2", "0", "pra_rag", "双渣RS修正");
            AddConfig("pra_rag_double_os", "0", "pra_rag", "双渣OS");
            AddConfig("pra_rag_double_sh1", "0", "pra_rag", "双渣石灰");
            AddConfig("pra_rag_double_sh2", "0", "pra_rag", "双渣石灰修正");
            AddConfig("pra_rag_double_dft", "0", "pra_rag", "默认双渣倒渣量");
            AddConfig("pra_rag_double_c", "0", "pra_rag", "双渣目标碳");
            AddConfig("pra_rag_double_oyg1", "0", "pra_rag", "双渣氧上限");
            AddConfig("pra_rag_double_oyg2", "0", "pra_rag", "双渣氧下限");
            AddConfig("pra_rag_double_bys1", "0", "pra_rag", "双渣白云石");
            AddConfig("pra_rag_double_bys2", "0", "pra_rag", "双渣白云石修正");
            
            // 预测修正参数
            AddConfig("pra_rag_yq_c1", "0", "pra_rag", "C预测流量修正");
            AddConfig("pra_rag_yq_c2", "0", "pra_rag", "C预测成分修正");
            AddConfig("pra_rag_yq_tmp1", "0", "pra_rag", "升温系数1");
            AddConfig("pra_rag_yq_tmp2", "0", "pra_rag", "升温系数2");
            AddConfig("pra_rag_yq_tmp3", "0", "pra_rag", "T预测修正1");
            AddConfig("pra_rag_yq_tmp4", "0", "pra_rag", "T预测修正2");
            AddConfig("pra_rag_yq_tmp5", "0", "pra_rag", "终点温度");
            AddConfig("pra_rag_yq_irn", "0", "pra_rag", "铁水比");
            
            // 系统备份时间
            AddConfig("back_up_date", now.ToString(), "sys", "数据库备份时间");

            return entities;
        }
    }
} 