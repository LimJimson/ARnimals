using System.IO;
using HG.Extensions;
using UnityEditor;
using UnityEngine;

namespace HG.Utils
{
    public static class UnityPathHelper
    {

        /// <param name="extension">single extension "xml", or  </param>

        public static string SelectFileRelative(string title, string directory, string extension)
        {
            if (!Directory.Exists(directory))
            {
                directory = "";
            }
           
            string path = EditorUtility.OpenFilePanel(title, directory, extension);
            return path.RemoveStartSubStr(ProjectPath());
        }
        
        public static string SelectFileRelative(string title, string directory, string[] extensions)
        {
            if (!Directory.Exists(directory))
            {
                directory = "";
            }
            
            var extention = string.Join(",", extensions);
           
            string path = EditorUtility.OpenFilePanel(title, directory, extention);
            return path.RemoveStartSubStr(ProjectPath());
        }
        
        
        
        /// <param name="filters">File extensions in form { "Image files", "png,jpg,jpeg", "All files", "*" }.</param>
        public static string SelectFileRelativeWithFilters(string title, string directory, string[] filters)
        {
            if (!Directory.Exists(directory))
            {
                directory = "";
            }

            string path = EditorUtility.OpenFilePanelWithFilters(title, directory, filters);
            return path.RemoveStartSubStr(ProjectPath());
        }
        


        public static string ProjectPath()
        {
            return Application.dataPath.RemoveEndSubStr("Assets");
        }
    }
}