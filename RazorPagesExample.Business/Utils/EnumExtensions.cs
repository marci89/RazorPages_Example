using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RazorPagesExample.Business.Utils
{
    /// <summary>
    /// It can be useful to display unique text for enums using the DisplayAttribute if, for example, we do not use localization
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieves the <see cref="DisplayAttribute.Name" /> property on the <see cref="DisplayAttribute" />
        /// of the current enum value, or the enum's member name if the <see cref="DisplayAttribute" /> is not present.
        /// </summary>
        /// <param name="val">This enum member to get the name for.</param>
        /// <returns>The <see cref="DisplayAttribute.Name" /> property on the <see cref="DisplayAttribute" /> attribute, if present.</returns>
        public static string GetDisplayName(this Enum val)
        {
            return val.GetType()
                      .GetMember(val.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.Name
                      ?? val.ToString();
        }
    }
}

//for example:
//@foreach(var type in Enum.GetValues(typeof(PetTypeViewModel)))
//            {
//                < option value = "@type.ToString()" >@((type as Enum).GetDisplayName()) </ option >
//            }