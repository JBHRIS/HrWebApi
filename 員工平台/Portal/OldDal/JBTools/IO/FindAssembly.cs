using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace JBTools.IO
{
    public class FindAssembly
    {
        public static Assembly GetAssembly(string assemblyName)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load(assemblyName);
            }
            catch
            {
                try
                {
                    assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), assemblyName));
                }
                catch
                {
                    assembly = Assembly.LoadFile(assemblyName);
                }
            }
            return assembly;
        }
    }
}
