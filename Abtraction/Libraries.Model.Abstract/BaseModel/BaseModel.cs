
namespace Libraries.Abstract.Models
{
    public abstract class BaseModel
    {
        [XmlIgnore]
        public int CreatedBy { get; set; }
        [XmlIgnore]
        public DateTime CreatedDate { get; set; }
        [XmlIgnore]
        public int ModifiedBy { get; set; }
        [XmlIgnore]
        public DateTime ModifiedDate { get; set; }
      
    }
}
