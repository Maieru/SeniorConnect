using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DefinedInEnumAttribute : ValidationAttribute
    {
        private readonly Type EnumType;

        public DefinedInEnumAttribute(Type enumType) : base()
        {
            EnumType = enumType;
        }

        public override bool IsValid(object value)
        {
            if (this.EnumType == null)
                throw new InvalidOperationException("Type cannot be null");


            if (!this.EnumType.IsEnum)
                throw new InvalidOperationException("Type must be an enum");

            return System.Enum.IsDefined(EnumType, value);
        }
    }
}
