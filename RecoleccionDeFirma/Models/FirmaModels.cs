using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecoleccionDeFirma.Models
{
    public class FirmaModels
    {
        [Key]
        public int firmaID { get; set; }

        [Required(ErrorMessage = "El Primer Nombre es requerido. ")]
        public string primerNombre { get; set; }

        [Required(ErrorMessage = "El Primer Apellido es requerido. ")]
        public string primerApellido { get; set; }

        [Required(ErrorMessage = "La Cédula es requerida ")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[. ]?([0-9]{7})[. ]?([0-9]{1})$", ErrorMessage = "Su Cédula debe contener 11 numeros. ")]
        public string cedula { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[. ]?([0-9]{3})[. ]?([0-9]{4})$", ErrorMessage = "Debe contener 10 numeros. ")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }
    }
}
