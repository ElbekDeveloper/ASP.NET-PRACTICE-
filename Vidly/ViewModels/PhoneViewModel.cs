using PhoneStore.Models;
using PhoneStore.Models.References;
using System.Collections.Generic;

namespace Vidly.ViewModels
{
    public class PhoneViewModel
    {
        public Phone Phone { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<OS> OperatingSystems { get; set; }
    }
}