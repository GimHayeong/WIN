using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppPhotoGalleryDataBinding
{
    public class JpgValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string fileName = value.ToString();

            if (!File.Exists(fileName))
            {
                return new ValidationResult(false, "Value is not a valid file.");
            }

            if(!fileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
            {
                return new ValidationResult(false, "Value is not a .jpg file.");
            }

            return new ValidationResult(true, null);
        }
    }
}
