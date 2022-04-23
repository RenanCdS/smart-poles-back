using SmartPoles.CrossCutting.Enums;
using System;

namespace SmartPoles.Domain.DTOs.Responses
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
