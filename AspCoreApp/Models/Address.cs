using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreApp.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        [NotMapped]
        public string FullAddress => string.Format($"{Street} {Number}");
    }
}
