using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace JBTools.IO
{
    public class FormatStringReader
    {
        FormatSpiltType _SpiltType;
        string _Symbol;
        List<FormatStringColumnProperty> _ColumnSettings;
        public FormatStringReader(FormatSpiltType SpiltType, string Symbol)
        {
            _SpiltType = SpiltType;
            _Symbol = Symbol;
            _ColumnSettings = new List<FormatStringColumnProperty>();
        }
        public void SetColumn(FormatStringColumnProperty ColumnSetting)
        {
            _ColumnSettings.Add(ColumnSetting);
        }
        public object GetValue(string ColumnName, string StringLine)
        {
            var query = from a in _ColumnSettings where a.ColumnName == ColumnName select a;
            if (query.Any())
            {
                var value = query.First().GetValue(StringLine, _SpiltType, _Symbol);
                return value;
            }
            return null;
        }

        public enum FormatSpiltType
        {
            PositionLenth,
            SymbolSpilt
        }
        public enum StringDataType
        {
            String = 0,
            Integer = 1,
            Decimal = 2,
            Datetime = 3,
            Boolean = 4
        }
    }
    public class FormatStringColumnProperty
    {
        string _Value;
        public string ColumnName;
        public JBTools.IO.FormatStringReader.StringDataType DataType;
        public string FormatPattern;
        public int StartPosition;
        public int ColumnLength = 0;
        public object GetValue(string StringLine, JBTools.IO.FormatStringReader.FormatSpiltType SpiltType, string Symbol)
        {
            string txt = "";
            if (SpiltType == FormatStringReader.FormatSpiltType.PositionLenth)
            {
                txt = StringLine.Substring(StartPosition, ColumnLength);               
            }
            else if (SpiltType == FormatStringReader.FormatSpiltType.SymbolSpilt)
            {
               var tts = StringLine.Split(Symbol.ToCharArray());
               txt = tts[StartPosition];
            }
            if (DataType == FormatStringReader.StringDataType.Datetime)
                return GetDatetime(txt);
            else if (DataType == FormatStringReader.StringDataType.Boolean)
                return GetBoolean(txt);
            else if (DataType == FormatStringReader.StringDataType.Decimal)
                return GetDecimal(txt);
            else if (DataType == FormatStringReader.StringDataType.Integer)
                return GetInt(txt);
            else return txt;
        }
        DateTime GetDatetime(string Value)
        {
            DateTime dateValue;
            DateTime.TryParseExact(Value, FormatPattern, null, DateTimeStyles.None, out dateValue);
            return dateValue;
        }
        bool GetBoolean(string Value)
        {
            if (Value == FormatPattern)
                return true;
            else return false;
        }
        decimal GetDecimal(string Value)
        {
            return Convert.ToDecimal(Value);
        }
        decimal GetInt(string Value)
        {
            return Convert.ToInt32(Value);
        }
    }
}
