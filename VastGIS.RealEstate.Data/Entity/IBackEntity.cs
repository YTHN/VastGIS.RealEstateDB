namespace VastGIS.RealEstate.Data.Entity
{
    public interface IBackEntity: IEntity
    {
        System.DateTime? WxDcsj { get; set; }
        string WxCly { get; set; }
        System.DateTime? WxClsj { get; set; }
        string WxZty { get; set; }
        System.DateTime? WxZtsj { get; set; }
        string WxZjy { get; set; }
        System.DateTime? WxZjsj { get; set; }
        System.Guid WxWydm { get; set; }
    }
}