using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Autofac;

namespace JBHRIS.Api.Dto
{
    public partial class ConfigurationDto
    {
       
        public List<T> GetModules<T>(string ModuleType,IContainer _container)
        {
            List<T> result = new List<T>();
            var module = this.ModuleSettings.Modules.SingleOrDefault(p => p.ModuleType == ModuleType);
            foreach (var assm in module.AssemblyInfos)
            {
                if (module != null)
                {
                    var sourceDir = this.SourceDir.Trim().Length == 0 ? AppDomain.CurrentDomain.BaseDirectory : this.SourceDir;
                    var asmConcrete = Assembly.LoadFrom(sourceDir + assm.ConcreteClassAssembly);
                    var typeClass = asmConcrete.GetType(assm.ConcreteClass);
                    var instance = _container.ResolveNamed<T>(assm.Name); // (T)asmConcrete.CreateInstance(assm.ConcreteClass);
                    result.Add(instance);
                }
            }
            return result;
        }
    }
}
