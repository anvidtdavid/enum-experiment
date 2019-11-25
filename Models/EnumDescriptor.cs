using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EnumExperiment.Models
{
    public class EnumDescriptor
    {
         public int Code { get; set; }

        public IDictionary<string, EnumDisplayInfo> DisplayInfo { get; set; }

        public EnumDescriptor()
        {
            DisplayInfo = new Dictionary<string, EnumDisplayInfo>();
        }

        public void Add(string cultureName, EnumDisplayInfo displayInfo)
        {
            DisplayInfo.Add(cultureName, displayInfo);
        }
    }

    public class EnumDisplayInfo
    { 
        public string Display { get; set; }

        public string Description { get; set; }
    }

    enum Sam
    {
        [Display(Name = "Value 1", Description = "Value 1 Description")]
        Value1 = 0,

        [Display(Name = "Value 2", Description = "Value 2 Description")]
        Value2 = 1
    }

    enum Status
    {
        [Display(Name = "New", Description = "Indicates its a newly created one")]
        New = 0,

        [Display(Name = "InProgress", Description = "Indicates its in progress")]
        InProgress = 1,

        [Display(Name = "OnHold", Description = "Indicates its on hold")]
        OnHold = 2,

        [Display(Name = "Completed", Description = "Indicates it is completed")]
        Completed = 3,

        [Display(Name = "Approved", Description = "Indicates it is approved")]
        Approved = 4,

        [Display(Name = "Approved", Description = "Indicates it is rejected")]
        Rejected = 5
    }
}
