using System.ComponentModel.DataAnnotations.Schema;

namespace st10161149_prog7311_part2.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }

}
