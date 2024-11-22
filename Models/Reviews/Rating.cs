using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace total_test_1.Models.Reviews;

public partial class Rating
{
    [Key]
    public int RatingId { get; set; }

    [Column("Rating")]
    public int Ratings { get; set; }

    [InverseProperty("Rating")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}