using EnumExperiment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace EnumExperiment.Core
{
    public class EnumDescriptionFactory
    {
        public static IEnumerable<EnumDescriptor> Create(string baseName, params string[] culturesNames)
        {
            CultureInfo[] cultures = null;

            if (culturesNames.Length == 0)
            {
                cultures = new[] { CultureInfo.CurrentCulture };
            }

            var assembly = typeof(EnumDescriptionFactory).Assembly;

            var resourceManager = new ResourceManager(baseName,
                             assembly);

            var enums = typeof(Program).Assembly.DefinedTypes.Where(x => x.IsEnum);
            var displayAttr = typeof(DisplayAttribute);


            foreach (var codeValue in enums)
            {
                var enumFields = codeValue.GetMembers()
                    .Where(x => x.CustomAttributes.Any(y => y.AttributeType == displayAttr));

                var enumDescription = new EnumDescriptor();

                foreach (var culture in cultures)
                {

                    foreach (var member in enumFields)
                    {
                        var attr = member.GetCustomAttributes(displayAttr, false).First() as DisplayAttribute;

                        enumDescription.Code = (int)Enum.Parse(codeValue, member.Name);
                        enumDescription.TypeName = codeValue.Name;
                        enumDescription.Name = member.Name;


                        string display = member.Name, description = member.Name;

                        try
                        {
                            display = resourceManager.GetString($"{codeValue.Name}.{member.Name}.d", culture);
                            description = resourceManager.GetString($"{codeValue.Name}.{member.Name}.dx", culture);
                        }
                        finally { }

                        enumDescription.Add(culture.Name, member.Name, new EnumDisplayInfo 
                        {
                            Display = display,
                            Description = description
                        });
                    }

                    yield return enumDescription;
                }
            }
        }
    }
}
