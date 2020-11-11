using PhoneStore.Models.References;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public Material Materials { get; set; }
        [Display(Name = "Material")]
        public int MaterialId { get; set; }
        public Model Model { get; set; }
        [Display(Name = "Model")]
        public int ModelId { get; set; }
        public OS OperatingSystem { get; set; }
        [Display(Name = "Operating System")]
        public int OperatingSystemId { get; set; }
        public IList<Color> Colors { get; set; }
        public short RamInGb { get; set; }
        public short HddInGb { get; set; }
        public decimal Price { get; set; }
        public decimal Battery { get; set; }
        public int WeightInKg { get; set; }
        public int DimensionInInch { get; set; }
        public byte FrontCameraCount { get; set; }
        public byte MainCameraCount { get; set; }
        public short FrontCameraPrecisonInPx { get; set; }
        public short MainCameraPrecisonInPx { get; set; }
    }
}