using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }
        public ProjectData(string name)
        {
            Name = name;
        }
        public bool Equals(ProjectData other) //Compare
        {
            if (Object.ReferenceEquals(other, null)) //if the object is null 
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) //if the object the same
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "projectName=" + Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}