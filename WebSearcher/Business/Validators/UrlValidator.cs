using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebSearcher.Business.Validators
{
    public class UrlValidator : ValidationAttribute
    {

        public UrlValidator() { }

        /// <summary>
        /// Validates the URL input
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The validation state</returns>
        public override bool IsValid(object value)
        {
            if (value == null || value.ToString() == string.Empty)
            {
                return true;
            }

            try
            {
                Uri result;

                if (Uri.TryCreate(value.ToString(), UriKind.RelativeOrAbsolute, out result))
                {
                    if (result.Scheme.StartsWith(Resources.Constants.Constants.Common.Http) 
                        || result.Scheme.StartsWith(Resources.Constants.Constants.Common.Https))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}