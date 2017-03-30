using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionEdit
{
    public enum ProjectType
    {
        Project,
        Directory,
        SharedProject
    }
    
    public static class ProjectTypeExtensions
    {
        private static Dictionary<ProjectType, Guid> mapTypeToGuid = new Dictionary<ProjectType, Guid> {
            { ProjectType.Project, new Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC") },
            { ProjectType.Directory, new Guid("2150E333-8FDC-42A3-9474-1A3956D46DE8") },
            { ProjectType.SharedProject, new Guid("D954291E-2A0B-460D-934E-DC6B0785DB48") }
        };

        private static Dictionary<Guid, ProjectType> mapGuidToType = 
            mapTypeToGuid.Keys.ToDictionary(key => mapTypeToGuid[key], key => key); 

        public static Guid ToGuid(this ProjectType type) => mapTypeToGuid[type];

        public static string ToProjectGuidString(this Guid guid) => guid.ToString("B").ToUpper();

        public static ProjectType ToProjectType(this Guid guid) => mapGuidToType[guid];

        public static string ToProjectGuidString(this ProjectType type) => type.ToGuid().ToProjectGuidString();
    }
}