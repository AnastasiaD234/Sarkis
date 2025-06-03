using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class ReserTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EventTime { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumPersons { get; set; }

        [Required]
        [StringLength(100)]
        public string EventType { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }


        public virtual List<BucataComandata> BucateComandate { get; set; }
        

    }
}
