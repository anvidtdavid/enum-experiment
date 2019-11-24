using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnumExperiment.Models;

namespace EnumExperiment.Core
{
    public class EnumService : IEnumService
    {
        public Task<EnumDescriptor> GetEnumDescriptors(string langulageCulture = null)
        {
            throw new NotImplementedException();
        }
    }
}
