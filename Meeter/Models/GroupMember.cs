﻿using System;
namespace Meeter.Models
{
    public class GroupMember
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public string UserId { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
