using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace JBModule.Data.Linq
{
    /// <summary>
    /// DcHelper 的摘要描述
    /// </summary>
    public class DcHelper
    {
        public DcHelper()
        {

        }
        public static string JBHR_ConnectionString = "";
        public static HrDBDataContext GetHrDBDataContext()
        {
            return new HrDBDataContext(JBHR_ConnectionString);
        }

        public static void CopyObjectProperty<T>(T tSource, T tDestination) where T : class
        {
            PropertyInfo[] properties = tSource.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.ToString().Contains("EntityRef"))
                    continue;
                else if (p.PropertyType.ToString().Contains("EntitySet"))
                    continue;
                else
                    p.SetValue(tDestination, p.GetValue(tSource, null), null);
            }
        }


        public static void CopyObjectProperty2<T>(T tSource, T tDestination) where T : class
        {
            foreach (System.Reflection.FieldInfo fi in tSource.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.
          Instance))
            {
                if (fi.FieldType.ToString().Contains("EntityRef"))
                {
                    var value = fi.GetValue(tSource);
                    if (value != null)
                    {
                        fi.SetValue(tDestination, null);
                    }
                }
                if (fi.FieldType.ToString().Contains("EntitySet"))
                {
                    var value = fi.GetValue(tSource);
                    var pi = value.GetType().GetProperty("HasLoadedOrAssignedValues");
                    if (!Convert.ToBoolean(pi.GetValue(value, null)))
                    {
                        var objES = Activator.CreateInstance(value.GetType());
                        fi.SetValue(tDestination, objES);
                        continue;
                    }

                    if (value != null)
                    {
                        System.Reflection.MethodInfo mi = value.GetType().GetMethod("Clear");
                        if (mi != null)
                        {
                            mi.Invoke(value, null);
                        }
                        fi.SetValue(tDestination, value);
                    }
                }
                else
                {
                    var value = fi.GetValue(tSource);
                    fi.SetValue(tDestination, value);
                }
            }
        }


        public static void Detach<T>(T entity) where T : class
        {
            foreach (System.Reflection.FieldInfo fi in entity.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.
          Instance))
            {
                if (fi.FieldType.ToString().Contains("EntityRef"))
                {
                    var value = fi.GetValue(entity);
                    if (value != null)
                    {
                        fi.SetValue(entity, null);
                    }
                }
                if (fi.FieldType.ToString().Contains("EntitySet"))
                {
                    var value = fi.GetValue(entity);
                    var pi = value.GetType().GetProperty("HasLoadedOrAssignedValues");

                    if (!Convert.ToBoolean(pi.GetValue(value, null)))
                    {
                        var objES = Activator.CreateInstance(value.GetType());
                        fi.SetValue(entity, objES);
                        continue;
                    }

                    if (value != null)
                    {
                        System.Reflection.MethodInfo mi = value.GetType().GetMethod("Clear");
                        if (mi != null)
                        {
                            mi.Invoke(value, null);
                        }
                        fi.SetValue(entity, value);
                    }
                }
            }
        }
    }
}