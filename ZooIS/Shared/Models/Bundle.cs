﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZooIS.Shared.Models
{
    public class Bundle
    {
        public int Id { get; set; }
        public double Price { get; set; } = 0.00;
        public bool PurchaseFinalized { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;  //DateModified arba abu makes more sense ?
        public DateTime DateOfUse { get; set; } = DateTime.Now;  //PAKEIST

        //relationships
        public List<BundleTicket> BundleTickets { get; set; } = new List<BundleTicket>();
        //with RegisteredUsers
        [JsonIgnore]
        public RegisteredUser RegisteredUser { get; set; }
        public int RegisteredUserId { get; set; }
    }
}