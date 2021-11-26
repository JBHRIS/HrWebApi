using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Repo;
using System.Text;
/// <summary>
/// MailVariable 的摘要描述
/// </summary>
public class MailVariable
{
	protected NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
	DataContext dc = new DataContext();    
	private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
	private static string[] variables = new string[]{ "^[[name]]^","^[[nobr]]^","^[[ClassName]]^","^[[ClassCategoryName]]^","^[[ClassDate]]^","^[[ClassTeacherName]]^"};
	public string Nobr { get; set; }
	public string Teacher { get; set; }
	public int StudentDetailM { get; set; }
	public int TrainingDetailM { get; set; }
	public trTrainingDetailM TDM { get; set; }
	private string _str ="";
	private trTrainingDetailM_Repo dmRepo = new trTrainingDetailM_Repo();
	private BASE_Repo baseRepo = new BASE_Repo();
    public JUser juser { get; set; }

	public static bool IsEmail(string email)
	{
		if (Regex.IsMatch(email.Trim(), RegularExp.Email))
			return true;
		else
			return false;
	}

	public struct RegularExp
	{
		public const string Chinese = @"^[\u4E00-\u9FA5\uF900-\uFA2D]+$";
		public const string Color = "^#[a-fA-F0-9]{6}";
		public const string Date = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
		public const string DateTime = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
		public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
		public const string Float = @"^(-?\d+)(\.\d+)?$";
		public const string ImageFormat = @"\.(?i:jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
		public const string Integer = @"^-?\d+$";
		public const string IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
		public const string Letter = "^[A-Za-z]+$";
		public const string LowerLetter = "^[a-z]+$";
		public const string MinusFloat = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
		public const string MinusInteger = "^-[0-9]*[1-9][0-9]*$";
		public const string Mobile = "^0{0,1}13[0-9]{9}$";
		public const string NumbericOrLetterOrChinese = @"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D]+$";
		public const string Numeric = "^[0-9]+$";
		public const string NumericOrLetter = "^[A-Za-z0-9]+$";
		public const string NumericOrLetterOrUnderline = @"^\w+$";
		public const string PlusFloat = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
		public const string PlusInteger = "^[0-9]*[1-9][0-9]*$";
		public const string Telephone = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";
		public const string UnMinusFloat = @"^\d+(\.\d+)?$";
		public const string UnMinusInteger = @"\d+$";
		public const string UnPlusFloat = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";
		public const string UnPlusInteger = @"^((-\d+)|(0+))$";
		public const string UpperLetter = "^[A-Z]+$";
		public const string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
	}
	public static string[] GetVariablesArr()
	{
		return variables;
	}

	public MailVariable()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

	public bool hasVaribles(string str)
	{
		bool result = false;

		foreach (var s in variables)
		{
			if (str.Contains(s))
			{
				return true;
			}
		}

		return result;
	}

	public void SetStr(string str)
	{
		_str = str;
	}

	public string GetTrainingDetailMStr(string str)
	{
		trTrainingDetailM dmObj =null;
		if (TrainingDetailM == 0)
		{
			return str;
		}

		_str = str;
		if (TDM == null)        
			dmObj = dmRepo.GetByKey_DLO(TrainingDetailM);        
		else
			dmObj = TDM;

		if(dmObj ==null || dmObj.trCourse.trCategoryCourse[0].trCategory ==null || dmObj.trCourse ==null)
		{
			logger.Error("無正確課程資訊");
			throw new ApplicationException("無正確課程資訊");            
		}

		if (_str.Contains("^[[ClassName]]^"))
		{
			_str = _str.Replace("^[[ClassName]]^",dmObj.trCourse.sName);
		}

		if (_str.Contains("^[[ClassCategoryName]]^"))
		{
			//_str = _str.Replace("^[[ClassCategoryName]]^", dmObj.trCategory.sName);
			_str = _str.Replace("^[[ClassCategoryName]]^" , dmObj.trCourse.trCategoryCourse[0].trCategory.sName);
		}

		if (_str.Contains("^[[ClassDate]]^"))
		{
			string tempStr="";

			for (int i = 0; i < dmObj.trAttendClassDate.Count; i++)
			{
				if (i == 0)
					tempStr = tempStr + dmObj.trAttendClassDate[i].dClassDateA.Value.ToShortDateString() + " " 
						+ dmObj.trAttendClassDate[i].dClassDateA.Value.ToShortTimeString();
				else
					tempStr = tempStr + "、" + dmObj.trAttendClassDate[i].dClassDateA.Value.ToShortDateString() + " " 
						+ dmObj.trAttendClassDate[i].dClassDateA.Value.ToShortTimeString();
			}

			_str = _str.Replace("^[[ClassDate]]^", tempStr);
		}

        if (_str.Contains("^[[ClassTime]]^"))
        {
            StringBuilder sb = new StringBuilder(dmObj.dDateTimeA.Value.Hour.ToString().PadLeft(2, '0'));
            sb.Append(":");
            sb.Append(dmObj.dDateTimeA.Value.Minute.ToString().PadLeft(2, '0'));
            sb.Append("-");
            sb.Append(dmObj.dDateTimeD.Value.Hour.ToString().PadLeft(2, '0'));
            sb.Append(":");
            sb.Append(dmObj.dDateTimeD.Value.Minute.ToString().PadLeft(2, '0'));
            _str = _str.Replace("^[[ClassTime]]^", sb.ToString());
        }

		if (_str.Contains("^[[ClassStudentNumber]]^"))
		{
			Course course = new Course();
			_str = _str.Replace("^[[ClassStudentNumber]]^", dmObj.iStudentNum.ToString());
		}

		if (_str.Contains("^[[ClassTeacherName]]^"))
		{
			Course course = new Course();            
			_str = _str.Replace("^[[ClassTeacherName]]^", course.GetTeacherNameByClassID(TrainingDetailM));
		}

		if ( _str.Contains("^[[ClassPlaceName]]^") )
		{
			Course course = new Course();
			_str = _str.Replace("^[[ClassPlaceName]]^" , course.GetPlaceNameByClassID(TrainingDetailM));
		}

		if (_str.Contains("^[[ClassStudentName]]^"))
		{
			Course course = new Course();
			_str = _str.Replace("^[[ClassStudentName]]^", course.GetStudentNameByClassID(TrainingDetailM));
		}

		return _str;
	}

	//public string GetStudentDetailMStr(string str)
	//{
	//    _str = str;
	//    var sm = (from c in dcTraining.trTrainingDetailM

	//}

	public string GetBaseStr(string str)
	{
		if (str == null || str.Length == 0)
			return str;
		_str = str;
		BASE BaseObj = baseRepo.GetByNobr(Nobr);

		if (BaseObj == null)
			return _str;

		if (_str.Contains("^[[name]]^"))
		{
			_str = _str.Replace("^[[name]]^", BaseObj.NAME_C);
		}

		if (_str.Contains("^[[nobr]]^"))
		{
			_str = _str.Replace("^[[nobr]]^", BaseObj.NOBR);
		}
		return _str;
	}

	public string GetAllStr(string str)
	{
		string result = "";
		result = GetBaseStr(str);
		result = GetTrainingDetailMStr(result);
        result = GetCustomStr(result);
        result = GetByCurrentUserStr(result);

        if (IsContainVariable(result))
            result = GetAllStr(result,3);

		return result;
	}

    public string GetAllStr(string str,int Acounter)
    {
        Acounter--;
        string result = "";
        result = GetBaseStr(str);
        result = GetTrainingDetailMStr(result);
        result = GetCustomStr(result);
        result = GetByCurrentUserStr(result);

        if (IsContainVariable(result) && Acounter>0)
            result = GetAllStr(result,Acounter);

        return result;
    }



    public string GetByCurrentUserStr(string str)
    {
        if (str == null || str.Length == 0)
            return str;
        _str = str;

        if (juser == null)
            return str;


        return _str;
    }

    public string GetCustomStr(string str)
    {
        if (str == null || str.Length == 0)
            return str;
        _str = str;

        NotifyCustomVariable_Repo ncvRepo = new NotifyCustomVariable_Repo();
        List<NotifyCustomVariable> ncvList= ncvRepo.GetAll();
        foreach (NotifyCustomVariable n in ncvList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("^[[");
            sb.Append(n.Code);
            sb.Append("]]^");
            if (_str.Contains(sb.ToString()))
                _str = _str.Replace(sb.ToString(),n.Text );
        }

        return _str;
    }


    public bool IsContainVariable(string str)
    {
        if (str.Contains("^[[") && str.Contains("]]^"))
            return true;
        else
            return false;
    }
}