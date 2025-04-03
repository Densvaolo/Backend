﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    public class UserEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<ProjectEntity> Projects { get; set; } = [];

    }


}
