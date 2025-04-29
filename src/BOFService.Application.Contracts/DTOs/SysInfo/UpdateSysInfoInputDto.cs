namespace BOFService.Application.Contracts.DTOs.SysInfo;

public class UpdateSysInfoInputDto
{
    /// <summary>
    /// 数据标识
    /// </summary>
    public string KeyName { get; set; }

    /// <summary>
    /// 数据值
    /// </summary>
    public string KeyValue { get; set; }
}