namespace VastGIS.RealEstate.Data.Entity
{
    public abstract class BackEntity
    {
        public int Bsm { get; set; }
        public System.DateTime? WxDcsj { get; set; }
        public string WxCly { get; set; }
        public System.DateTime? WxClsj { get; set; }
        public string WxZty { get; set; }
        public System.DateTime? WxZtsj { get; set; }
        public string WxZjy { get; set; }
        public System.DateTime? WxZjsj { get; set; }
        public System.Guid WxWydm { get; set; }
    }
}