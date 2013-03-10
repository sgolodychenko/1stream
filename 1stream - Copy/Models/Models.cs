using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1stream.Models
{
    public class Channel
    {
        [Key]
        public int ChannelId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("TariffId")]
        public int TariffId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    //public class ChannelsFields
    //{
    //    [Key]
    //    public int ChannelId { get; set; }
    //    [Key]
    //    public string Key { get; set; }
    //    public string Value { get; set; }
    //    public DateTime Updated { get; set; }
    //}

    [Table("Tariffs")]
    public class Tariff
    {
        [Key]
        public int TariffId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class TariffField
    {
        [Key]
        [ForeignKey("TariffId")]
        public int TariffId { get; set; }
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }

}