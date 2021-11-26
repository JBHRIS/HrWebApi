using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

public class ConfigSetting
{
    Configuration conf;
    public ConfigSetting()
    {
        try
        {
            conf = System.Configuration.ConfigurationManager.OpenExeConfiguration("");
        }
        catch
        {
        }
    }
    public ConfigSetting(string cfgPath)
    {
        try
        {
            //conf = System.Configuration.ConfigurationManager.OpenExeConfiguration(Path);
            //string cfgPath = Path.Combine(targetDir, "myApp.config");
            var configMap = new ExeConfigurationFileMap { ExeConfigFilename = cfgPath };

            conf = ConfigurationManager.OpenMappedExeConfiguration(configMap,
                ConfigurationUserLevel.None);
            //cf.AppSettings.Settings["somekey"].Value = "newvalue";

            //cf.Save();
        }
        catch
        {
        }
    }
    public void SetAppValue(string Name, string Value)
    {
        if (conf.AppSettings.Settings[Name] != null)
            conf.AppSettings.Settings[Name].Value = Value;
        else conf.AppSettings.Settings.Add(Name, Value);
    }
    public string GetAppValue(string Name)
    {
        if (conf.AppSettings.Settings[Name] != null)
            return conf.AppSettings.Settings[Name].Value;
        else return null;
    }
    public Dictionary<string, string> GetConnectionStringList()
    {
        Dictionary<string, string> lst = new Dictionary<string, string>();
        foreach (ConnectionStringSettings it in conf.ConnectionStrings.ConnectionStrings)
        {
            if (it.Name != "LocalSqlServer")
                lst.Add(it.Name, it.Name);
        }
        return lst;
    }
    public Dictionary<string, string> GetAppSettingStringList()
    {
        Dictionary<string, string> lst = new Dictionary<string, string>();
        foreach (var it in conf.AppSettings.Settings.AllKeys)
        {
            string value = GetAppValue(it);
            lst.Add(it, value);
        }
        return lst;
    }
    public void SetConnValue(string OldName, string NewName, string Value)
    {
        if (conf.ConnectionStrings.ConnectionStrings[OldName] != null)
        {
            conf.ConnectionStrings.ConnectionStrings[OldName].ConnectionString = Value;
            conf.ConnectionStrings.ConnectionStrings[OldName].Name = NewName;
        }
        else conf.AppSettings.Settings.Add(OldName, Value);
    }
    public void AddConnValue(string Name, string Value)
    {
        if (conf.ConnectionStrings.ConnectionStrings[Name] == null)
            conf.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(Name, Value));
        //else conf.AppSettings.Settings.Add(Name, Value);
    }
    public void DeleteConnValue(string Name)
    {
        if (conf.ConnectionStrings.ConnectionStrings[Name] != null)
            conf.ConnectionStrings.ConnectionStrings.Remove(Name);
        //else conf.AppSettings.Settings.Add(Name, Value);
    }
    public string GetConnValue(string Name)
    {
        if (conf.ConnectionStrings.ConnectionStrings[Name] != null)
            return conf.ConnectionStrings.ConnectionStrings[Name].ConnectionString;
        else return null;
    }
    
    public void Save()
    {
        conf.Save();
    }
    public static string ConnectionString(string name)
    {
        try
        {
            string value = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            if (value == null) throw new Exception();
            return value;
        }
        catch (Exception ex)
        {
            var ex1 = new Exception("發生錯誤，請先檢查ConnectionString名稱" + name + "是否存在", ex);
            throw ex1;
        }
    }
    public static NameValueCollection AppSettingValueCollection()
    {
        try
        {
            NameValueCollection value = ConfigurationManager.AppSettings;
            if (value == null) throw new Exception();
            return value;
        }
        catch (Exception ex)
        {
            var ex1 = new Exception("取得AppSetting發生錯誤"+ Environment.NewLine + ex.Message, ex);
            throw ex1;
        }
    }
    public static string AppSettingValue(string name)
    {
        try
        {
            string value = ConfigurationManager.AppSettings[name];
            if (value == null) throw new Exception();
            return value;
        }
        catch (Exception ex)
        {
            var ex1 = new Exception("發生錯誤，請先檢查AppSetting名稱" + name + "是否存在" + Environment.NewLine + ex.Message, ex);
            throw ex1;
        }
    }
    public static string AppSettingValue(string name, string DefaultValue)
    {
        string value = ConfigurationManager.AppSettings[name];
        if (value == null) return DefaultValue;
        return value;
    }
    public static string GetConnectionStringByAppSetting(string AppSettingName)
    {
        try
        {
            string app_name = AppSettingValue(AppSettingName);
            return ConnectionString(app_name);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

