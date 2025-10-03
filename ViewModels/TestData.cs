using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF30SEP.Models;

namespace WPF30SEP.ViewModels
{
    public static class TestData
    {
                //public static IEnumerable<Group> Groups { get; } = Enumerable.Range(1, 10).Select(i => new Group { Name = $"Group {i}" }).ToList();

        public static IEnumerable<Group> Groups { get; } =
            Enumerable.Range(1, 10).Select(i => new Group { Id = i, Name = $"Group Name {i}" }).ToList();

        public static IEnumerable<Student> Students { get; } = CreateStudents(Groups);

        private static IEnumerable<Student> CreateStudents(IEnumerable<Group> groups)
        {
            var index = 1;
            foreach (var group in groups)
                for (var i = 0; i < 10; i++)
                    group.Students.Add(new Student
                    {
                        Id = index,
                        LastName = $"LastName  {index}",
                        FirstName = $"FirstName  {index++}"
                    });         
            return groups.SelectMany(g => g.Students).ToList();
        }
    }
}
