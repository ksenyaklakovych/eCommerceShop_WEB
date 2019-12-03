namespace eCommerce.BLL.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ValidationException : Exception
    {
        public ValidationException(string message, string prop)
            : base(message)
        {
            this.Property = prop;
        }

        public string Property { get; protected set; }
    }
}
