using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF30SEP.Interfaces;

namespace WPF30SEP.Models
{
    public class Group : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
