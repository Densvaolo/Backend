using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    public class StatusEntity
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public ICollection<ProjectEntity> Projects { get; set; } = [];
    }


}
