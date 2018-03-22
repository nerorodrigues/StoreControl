using Infrastructure.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Utils
{
    public class AngularModelGenerator
    {
        private static string Name = "export class {0} {{";
        private static string Property = "\t{0} : {1};";
        public static void LoadViewModelTypes(AppDomain pAppDomain, string pOutputDirectory)
        {
            var assemblies = pAppDomain.GetAssemblies();
            var types = assemblies.SelectMany(pX => pX.ExportedTypes).ToList();
            LoadViewModelTypes(types, pOutputDirectory);
        }

        public static void LoadViewModelTypes(List<Type> pTypes, string pOutputDirectory)
        {
            var types = pTypes.Where(pX => !pX.GetTypeInfo().IsAbstract &&
                typeof(ViewModelBase).GetTypeInfo().IsAssignableFrom(pX.GetTypeInfo())).ToList();
            foreach (var type in types)
            {
                var generatedClass = GenerateAngularClass(type, types);
                if (!Directory.Exists(pOutputDirectory))
                    Directory.CreateDirectory(pOutputDirectory);
                using (var file = new StreamWriter(Path.Combine(pOutputDirectory, type.Name + ".ts"), false, Encoding.UTF8))
                {
                    file.Write(generatedClass);
                    file.Flush();
                    file.Close();
                }
            }
        }


        public static string GenerateAngularClass(Type pType, List<Type> pTypesToExport)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Format(Name, pType.Name));
            foreach (var item in pType.GetProperties().Where(pX => pX.CanRead && pX.CanWrite))
            {
                var propertyType = GetJavaScriptType(item.PropertyType, pTypesToExport);
                if (string.IsNullOrEmpty(propertyType))
                    continue;
                str.AppendLine(string.Format(Property, item.Name, propertyType));
            }
            str.AppendLine("}");

            return str.ToString();
        }

        public static string GetJavaScriptType(Type pPropertyType, List<Type> pTypesToExport)
        {
            var propertyType = "";
            var ehArray = pPropertyType.IsArray || (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(pPropertyType) && pPropertyType.GetTypeInfo() != typeof(String).GetTypeInfo());
            if (pPropertyType == typeof(bool))
                propertyType = "boolean";
            else if (pPropertyType == typeof(Guid) || pPropertyType == typeof(String))
                propertyType = "string";
            else if (pPropertyType == typeof(int))
                propertyType = "number";
            else if (pPropertyType == typeof(DateTime))
                propertyType = "Date";
            else if (pPropertyType.IsGenericType)
                propertyType = GetJavaScriptType(pPropertyType.GetGenericArguments().FirstOrDefault(), pTypesToExport);
            else if (pTypesToExport.Any(pX => pPropertyType.GetTypeInfo() == pX.GetTypeInfo()))
                propertyType = pPropertyType.Name;
            else
                propertyType = string.Empty;
            if (!string.IsNullOrEmpty(propertyType) && ehArray)
                propertyType += "[]";
            return propertyType;


        }
    }
}
