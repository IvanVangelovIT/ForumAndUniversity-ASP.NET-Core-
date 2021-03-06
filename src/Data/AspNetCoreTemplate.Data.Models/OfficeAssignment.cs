namespace AspNetCoreTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Common.Models;

    public class OfficeAssignment : BaseDeletableModel<int>
    {
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}