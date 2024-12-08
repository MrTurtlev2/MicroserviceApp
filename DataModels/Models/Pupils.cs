using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{ 
    public class Pupils
    { 
        public int Id { get; set; }
        public string? Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public int TrainerId { get; set; }
        public Trainers? Trainer { get; set; } 
    }
}
