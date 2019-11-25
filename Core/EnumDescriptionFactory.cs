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
        public static Dictionary<string, Dictionary<string, EnumDescriptor>> Create(string baseName, params string[] culturesNames)
        {
            CultureInfo[] cultures = null;

            if (culturesNames.Length == 0)
            {
                cultures = new[] { CultureInfo.CurrentCulture };
            }
            else
            {
                cultures = new[] { CultureInfo.CurrentCulture }
                .Concat(culturesNames.Select(x => new CultureInfo(x))).ToArray();
            }

            var assembly = typeof(EnumDescriptionFactory).Assembly;

            var resourceManager = new ResourceManager(baseName,
                             assembly);

            var enums = typeof(Program).Assembly.DefinedTypes.Where(x => x.IsEnum);
            var displayAttr = typeof(DisplayAttribute);

            var resultDictionary = new Dictionary<string, Dictionary<string, EnumDescriptor>>();

            foreach (var codeValue in enums)
            {
                var enumFields = codeValue.GetMembers()
                    .Where(x => x.CustomAttributes.Any(y => y.AttributeType == displayAttr));

                resultDictionary.Add(codeValue.Name, new Dictionary<string, EnumDescriptor>());

                foreach (var member in enumFields)
                {
                    var enumDescription = new EnumDescriptor
                    {
                        Code = (int)Enum.Parse(codeValue, member.Name)
                    };

                    foreach (var culture in cultures)
                    {
                        var attr = member.GetCustomAttributes(displayAttr, false).First() as DisplayAttribute;

                        string display = member.Name, description = member.Name;

                        try
                        {
                            display = resourceManager.GetString($"{codeValue.Name}.{member.Name}.d", culture);
                            description = resourceManager.GetString($"{codeValue.Name}.{member.Name}.dx", culture);
                        }
                        finally { }

                        enumDescription.Add(culture.Name, new EnumDisplayInfo
                        {
                            Display = display,
                            Description = description
                        });
                    }

                    resultDictionary[codeValue.Name].Add(member.Name,enumDescription);
                }
            }

            return resultDictionary;
        }
    }
}
