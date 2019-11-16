using System.ComponentModel.DataAnnotations;

namespace Portnox.Data
{
    public class NetworkEvent
    {
        [Key]
        public int Id { get; set; }
        public int Event_Id { get; set; }
        
        [MaxLength(20)]
        public string Switch_Ip { get; set; }
        public int Port_Id { get; set; }
        
        [MaxLength(20)]
        public string Device_Mac { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }
    }
}