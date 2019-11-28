using EnumExperiment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnumExperiment
{
    public interface IEnumService
    {
        Task<EnumDescriptor> GetEnumDescriptors(string langulageCulture = null);
    }
}
