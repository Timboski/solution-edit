using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionEdit
{
    public enum ProjectType
    {
        Project,
        Directory,
        SharedProject,
        NetCoreProject
    }

    public static class ProjectTypeExtensions
    {
        private static Dictionary<ProjectType, string> mapTypeToGuid = new Dictionary<ProjectType, string> {
            { ProjectType.Project, "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}" },
            { ProjectType.Directory, "{2150E333-8FDC-42A3-9474-1A3956D46DE8}" },
            { ProjectType.SharedProject, "{D954291E-2A0B-460D-934E-DC6B0785DB48}" },
            { ProjectType.NetCoreProject, "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}" }
        };

        /// <remarks>
        /// Must be declared after mapTypeToGuid. TODO: Refactor both into a non-static class.
        /// </remarks>
        private static Dictionary<string, ProjectType> mapGuidToType =
            mapTypeToGuid.Keys.ToDictionary(key => mapTypeToGuid[key], key => key);

        public static Guid ToGuid(this ProjectType type) => new Guid(mapTypeToGuid[type]);

        public static string ToProjectGuidString(this Guid guid) => guid.ToString("B").ToUpper();

        public static string ToProjectGuidString(this ProjectType type) => type.ToGuid().ToProjectGuidString();

        public static ProjectType ToProjectType(this Guid guid) => mapGuidToType[guid.ToProjectGuidString()];
    }
}