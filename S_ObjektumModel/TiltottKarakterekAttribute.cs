using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public class TiltottKarakterekAttribute : ValidationAttribute
    {
        string tiltottak;
        public TiltottKarakterekAttribute(string karakterek)
        {
            tiltottak = karakterek;
        }
        protected override ValidationResult IsValid(object ertek, ValidationContext validationContext)
        {
            if (ertek != null)
            {
                for (int i = 0; i < tiltottak.Length; i++)
                {
                    var szovegkent = ertek.ToString();
                    if (szovegkent.Contains(tiltottak[i]))
                    {
                        var uzenet = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(uzenet);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
