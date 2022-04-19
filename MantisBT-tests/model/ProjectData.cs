using System;
using System.Collections.Generic;
using System.Linq;

namespace MantisBT_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {
        }
        
        public ProjectData(string name)
        {
            Name = name;
        }

        public bool Equals(ProjectData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
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
            return "name=" + Name;
        }

        public int CompareTo (ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public string Name { get; set; }        

        public string Title { get; set;}

        public string Id { get; set;}
    }
}
