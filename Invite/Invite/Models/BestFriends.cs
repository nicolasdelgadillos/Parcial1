

namespace Invite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BestFriends
    {
        public enum TypeList
        {
            Dasmian,
            Dardo,
            Delgadillo,
            Dorado,
            Duran
        }
        [Key]
        public int FriendID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public TypeList List { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Description = "Happy Birthday")]
        public string ContactValue { get; set; }
    }
}