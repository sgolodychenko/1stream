﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OneStream.App_LocalResources;
using _1stream.Models;

namespace OneStream.Models
{
    [Table("Channels")]
    public class Channel : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ChannelId { get; set; }

        [Column("UserId")]
        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<Broadcast> Broadcasts { get; set; }
        
        [Required]
        //[Display(ResourceType = typeof (ModelsResources_en), Name = "Channel_Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public int WatchersCount { get; set; }
        public bool ChatEnable { get; set; }
        public bool FeedbackBroadcaster { get; set; }
        public bool FeedbackSms { get; set; }
        public bool FeedbackMail { get; set; }
        public bool FeedbackCabinet { get; set; }
        public bool CustomLogo { get; set; }
        public bool FreeStreming { get; set; }
        //[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [UIHint("Currency")]
        public decimal CostOfLive { get; set; }
        //[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [UIHint("Currency")]
        public decimal CostOfStorage { get; set; }
    }

    [Table("Broadcasts")]
    public class Broadcast : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BroadcastId { get; set; }

        [Column("ChannelId")]
        public virtual int ChannelId { get; set; }
        [ForeignKey("ChannelId")]
        public virtual Channel Channel { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public int WatchersCount { get; set; }
        public bool ChatEnable { get; set; }
        public bool FeedbackBroadcaster { get; set; }
        public bool FeedbackSms { get; set; }
        public bool FeedbackMail { get; set; }
        public bool FeedbackCabinet { get; set; }
        public bool CustomLogo { get; set; }
        public bool FreeStreming { get; set; }

        public int AccessTime { get; set; }
        public bool AnnounceInChannel { get; set; }
        public int StorageTime { get; set; }
        public decimal CostOfLive { get; set; }
        public decimal CostOfStorage { get; set; }
        public decimal CostOfLiveSpecial { get; set; }
        public decimal CostOfStorageSpecial { get; set; }
        public TimeSpan? OffsetStart { get; set; }
        public TimeSpan? OffsetEnd { get; set; }

        public DateTime StartDate { get; set; }
    }

    [Table("UserInfo")]
    public class UserInfo : BaseModel
    {
        [Key]
        [Column("UserId")]
        public virtual int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public decimal Balance { get; set; }
    }

    public class PersonalCabinet
    {
        public int UserId { get; set; }
        public Broadcast CurrentBroadcast { get; set; }
        public IQueryable<Broadcast> MonthBroadcasts { get; set; }
        public IQueryable<Broadcast> PlannedBroadcasts { get; set; }
        public IQueryable<Broadcast> ArchivedBroadcasts { get; set; }
    }
}