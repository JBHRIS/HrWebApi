using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repo;
/// <summary>
/// Course 的摘要描述
/// </summary>
public class Course
{
	private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
	public trTrainingDetailM CourseObj { get; set; }
	public Course()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

	public bool IsSerialCourse(string courseCode)
	{        
		var serialCourse = (from c in dcTraining.trSerialCourse
							 where c.sSerialCourseCode == courseCode
							 select c).FirstOrDefault();
		if (serialCourse != null)
			return true;
		else
			return false;        
	}

	public void RegisterSerialCourse(string courseCode, string categoryCode, int year, string keyMan)
	{
		var serialCourses = (from c in dcTraining.trSerialCourse
							 where c.sSerialCourseCode == courseCode
							 select c).ToList();

		foreach (var sc in serialCourses)
		{
			var CategoryCourse = (from c in dcTraining.trCategoryCourse
								  where c.sCourseCode == sc.sCourseCode
								  select c).FirstOrDefault();

			if (CategoryCourse != null)
			{
				RegisterCourse(CategoryCourse.sCourseCode, CategoryCourse.sCateCode, year, keyMan);
			}
		}
	}


	public bool IsCourseValid(string courseCode,DateTime datetime)
	{
		trCourse_Repo trCourseRepo = new trCourse_Repo();
		trCourse obj = trCourseRepo.GetByCode(courseCode);
		if ( obj == null )
			return false;
		else
		{
			if ( obj.dDateA <= datetime && obj.dDateD >= datetime )
				return true;
			else
				return false;        
		}
	}
	/// <summary>
	/// 註冊一個課程，尚未開課
	/// </summary>
	/// <param name="courseCode"></param>
	/// <param name="categoryCode"></param>
	/// <param name="year"></param>
	/// <param name="keyMan"></param>
	public void RegisterCourse(string courseCode, string categoryCode, int year, string keyMan)
	{
		if ( IsCourseValid(courseCode , DateTime.Now) == false )
		{
			throw new ApplicationException("此課程已失效!!");
		}

		DesignHelper designHelper = new DesignHelper();
		
		if(IsSerialCourse(courseCode))
		{
			RegisterSerialCourse(courseCode, categoryCode, year, keyMan);
			return;
		}

		trTrainingDetailM obj = new trTrainingDetailM();
		obj.trCourse_sCode = courseCode;
		obj.sKey = categoryCode;
		obj.sKeyMan = keyMan;
		obj.dKeyDate = DateTime.Now;
		obj.bIsPublished = false;
		obj.bWebJoin = false;
		obj.iYear = Convert.ToInt32(year);
		obj.iSession = designHelper.getNewClassSession(obj.iYear.Value, obj.trCourse_sCode);
		obj.iUpLimitP = 0;
		obj.iLowLimitP = 8;
		obj.iClassRptDateSpan = 7;
		obj.bIsNeedClassRpt = true;
		obj.sMaterialSelector = "N";
		obj.iStudentScoreDateSpan = 7;
		obj.bIsNeedStudentScore = true;
		obj.CourseType = null;//Enum.GetName(typeof(EnumCourseTypes) , EnumCourseTypes.OTHERS);

		//從課程帶來的資料
		var course = (from c in dcTraining.trCourse
					  where c.sCode == obj.trCourse_sCode
					  select c).FirstOrDefault();

		obj.iCourseTime = course.iCourseTime;
		obj.iJobScore = course.iJobScore;
		obj.trTrainingMethod_sCode = obj.trTrainingMethod_sCode;

		dcTraining.trTrainingDetailM.InsertOnSubmit(obj);
		dcTraining.SubmitChanges();

		//預設帶入全部的預估費用0        
		insertEmptyCostItem(obj.iAutoKey,keyMan);
	}

	public void RegisterSerialCourseByPlan(trTrainingPlanDetail p, string keyMan)
	{
		var serialCourses = (from c in dcTraining.trSerialCourse
							 where c.sSerialCourseCode == p.trCourse_sCode
							 select c).ToList();

		foreach (var sc in serialCourses)
		{
			var CategoryCourse = (from c in dcTraining.trCategoryCourse
								  where c.sCourseCode == sc.sCourseCode
								  select c).FirstOrDefault();

			if (CategoryCourse != null)
			{
				p.trCourse_sCode = sc.sCourseCode;
				p.sKey = CategoryCourse.sCateCode;
				RegisterCourseByPlan(p, keyMan);
			}
		}
	}

    /// <summary>
    /// 從年度計畫註冊一個課程
    /// </summary>
    /// <param name="p"></param>
    /// <param name="keyMan"></param>
	public void RegisterCourseByPlan(trTrainingPlanDetail p, string keyMan)
	{
		if ( IsCourseValid(p.trCourse_sCode , DateTime.Now) == false )
		{
			throw new ApplicationException("此課程已失效!!");
		}

		if (IsSerialCourse(p.trCourse_sCode))
		{
			RegisterSerialCourseByPlan(p,keyMan);
			return;
		}

		trTrainingDetailM obj = new trTrainingDetailM();
		obj.bIsPublished = false;
		obj.bWebJoin = false;
		obj.dKeyDate = DateTime.Now;
		if (p.iSession != null)
			obj.iSession = p.iSession;
		else
			obj.iSession = 0;

		obj.iEstimateAMT = 0;
		obj.iActualAMT = 0;
		obj.iUpLimitP = 0;
		obj.iLowLimitP = 8;
		obj.iClassRptDateSpan = 7;
		obj.bIsNeedClassRpt = true;
		obj.iStudentScoreDateSpan = 7;
		obj.bIsNeedStudentScore = true;
		obj.CourseType = p.CourseType;
		obj.iYear = p.iYear;
		obj.iYearPlanAutoKey = p.iAutoKey;
		obj.trCourse_sCode = p.trCourse_sCode;
		obj.sMaterialSelector = "N";
		obj.sKey = p.sKey;
		obj.sKeyMan = keyMan;
		obj.iCourseTime = p.iMins;
		//從課程帶來的資料
		var course = (from c in dcTraining.trCourse
					  where c.sCode == p.trCourse_sCode
					  select c).FirstOrDefault();

		obj.iCourseTime = course.iCourseTime;
		obj.iJobScore = course.iJobScore;
		obj.trTrainingMethod_sCode = obj.trTrainingMethod_sCode;

		dcTraining.trTrainingDetailM.InsertOnSubmit(obj);
		dcTraining.SubmitChanges();

		//預設帶入全部的預估費用0
		insertEmptyCostItem(obj.iAutoKey,keyMan);

		var plan = (from c in dcTraining.trTrainingPlanDetail
					where c.iAutoKey == p.iAutoKey
					select c).FirstOrDefault();

		plan.iClassAutoKey = obj.iAutoKey;
		dcTraining.SubmitChanges();
	}

	/// <summary>
	/// load費用
	/// </summary>
	/// <param name="classID"></param>
	/// <param name="keyMan"></param>
	private void insertEmptyCostItem(int classID,string keyMan)
	{
		var costItems = (from c in dcTraining.trCostItem select c).ToList();

		foreach (var c in costItems)
		{
			trTrainingEstimateCost obj = new trTrainingEstimateCost();
			obj.iClassAutoKey = classID;
			obj.iAmt = 0;
			obj.trCostItem_sCode = c.trCostItemCode;
			obj.sKeyMan = keyMan;
			obj.dKeyDate = DateTime.Now;
			dcTraining.trTrainingEstimateCost.InsertOnSubmit(obj);
		}

		dcTraining.SubmitChanges();
	}

	/// <summary>
	/// 回傳講師上課日期 By MMDD
	/// </summary>
	/// <param name="classID"></param>
	/// <param name="teacherCode"></param>
	/// <returns></returns>
	public string GetTeacherClassDateByClassTeacher(int classID,string teacherCode)
	{
		string str = "";
		var actList = (from act in dcTraining.trAttendClassTeacher                                                
						where act.iClassAutoKey == classID && act.sTeacherCode == teacherCode
						orderby act.dClassDate
						select act).ToList();

		List<string> list = new List<string>();

		foreach (var l in actList)
		{
			list.Add(l.dClassDate.ToString("MM/dd"));
		}

		for (int i = 0; i < list.Count; i++)
		{
			if (i == 0)
				str = str + list[i];
			else
				str = str + "、" + list[i];
		}

		return str;
	}

	/// <summary>
	/// 回傳課程多位學員中文名
	/// </summary>
	/// <param name="classID"></param>
	/// <returns></returns>
	public string GetStudentNameByClassID(int classID)
	{
		string str = "";

		trTrainingStudentM_Repo tsm = new trTrainingStudentM_Repo();
		List<trTrainingStudentM> list= tsm.GetByClassID_DLO(classID);		

		for (int i = 0; i < list.Count; i++)
		{
			if (i == 0)
				str = str + list[i].BASE.NAME_C;
			else
                str = str + "、" + list[i].BASE.NAME_C;
		}

		return str;
	}


	/// <summary>
	/// 回傳課程多位講師中文名
	/// </summary>
	/// <param name="classID"></param>
	/// <returns></returns>
	public string GetTeacherNameByClassID(int classID)
	{
		string str = "";
		var teachers = (from act in dcTraining.trAttendClassTeacher
						join t in dcTraining.trTeacher on act.sTeacherCode equals t.sCode
					   // join b in dcTraining.BASE on t.sNobr equals b.NOBR
						where act.iClassAutoKey == classID
						select t).ToList();


        //過濾重複講師名稱，只顯示一筆
		List<string> list = new List<string>();

		for (int i = 0; i < teachers.Count; i++)
		{
			if (!list.Contains(teachers[i].sName))
				list.Add(teachers[i].sName);
		}


		for (int i = 0; i < list.Count; i++)
		{
			if (i == 0)
				str = str + list[i];
			else
				str = str + "、" + list[i];
		}

		return str;
	}

	/// <summary>
	/// 回傳課程地點
	/// </summary>
	/// <param name="classID"></param>
	/// <returns></returns>
	public string GetPlaceNameByClassID(int classID)
	{
		string str = "";
		var places = (from acp in dcTraining.trAttendClassPlace
						join p in dcTraining.trClassroom on acp.sPlaceCode equals p.sCode                        
						where acp.iClassAutoKey == classID
						select p).ToList();

        //過濾重複地點名稱，只顯示一筆
        List<string> list = new List<string>();

        for (int i = 0; i < places.Count; i++)
        {
            if (!list.Contains(places[i].sName))
                list.Add(places[i].sName);
        }


		for (int i = 0; i < list.Count; i++)
		{
            if (i == 0)
                str = str + list[i];
            else
                str = str + "、" + list[i];
		}

		return str;
	}

	/// <summary>
	/// 同步開課講師，將開課上課日期講師，匯入到開課講師中
	/// </summary>
	/// <param name="id"></param>
	public void SyncCourseTeacher(int id)
	{
		ClassTeacher_Repo ctRepo = new ClassTeacher_Repo();
		List<ClassTeacher> ctList = ctRepo.GetByClassKey(id);

		foreach (var p in ctList)
		{
			ctRepo.Delete(p);
		}
		ctRepo.Save();

		trAttendClassTeacher_Repo actRepo = new trAttendClassTeacher_Repo(ctRepo.dc);
		List<trAttendClassTeacher> actList = actRepo.GetByClassKey(id);
		var teachers = (from c in actList select c.sTeacherCode).Distinct();

		foreach (var t in teachers)
		{
			ClassTeacher ctObj = new ClassTeacher();
			ctObj.iClassAutoKey = id;
			ctObj.sTeacherCode = t;
			ctObj.dKeyDate = DateTime.Now;
			ctRepo.Add(ctObj);
		}
		ctRepo.Save();
	}

	/// <summary>
	/// 發布課程時，預設將預估費用帶入實支費用
	/// </summary>
	/// <param name="classKey"></param>
	public void LoadCost(int classKey)
	{
		var actualCost = (from c in dcTraining.trTrainingActualCost
						  where c.iClassAutoKey == classKey
						  select c).FirstOrDefault();

		if (actualCost == null)
		{
			var classEstimateCosts = (from c in dcTraining.trTrainingEstimateCost
									  where c.iClassAutoKey == classKey
									  select c).ToList();

			foreach (var cost in classEstimateCosts)
			{
				trTrainingActualCost obj = new trTrainingActualCost();
				obj.iClassAutoKey = classKey;
				obj.trCostItem_sCode = cost.trCostItem_sCode;
				obj.iAmt = cost.iAmt;
				dcTraining.trTrainingActualCost.InsertOnSubmit(obj);
			}
			dcTraining.SubmitChanges();
		}
	}

	//檢查課程是否有漏填
	public void IsValidClass(int key)
	{
		//bool result = false;
		var classObj = (from c in dcTraining.trTrainingDetailM
						where c.iAutoKey == key
						select c).FirstOrDefault();

        //檢查是否有重複的梯次課程
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> tdmList= tdmRepo.GetByCourseCodeYearSessionIsPublished(classObj.trCourse_sCode, classObj.iYear.Value,classObj.iSession.Value, true);
        if (tdmList.Count > 0)
        {
            throw new ApplicationException("此課程梯次有重複，請確認");
        }

		//1.上課日期是否有設定、課程時數是否有設定
		if (!(classObj.dDateA.HasValue && classObj.dDateD.HasValue))
		{
			throw new ApplicationException("上課日期需設定");
		}

		if (!classObj.iCourseTime.HasValue)
		{
			throw new ApplicationException("上課時數需設定");
		}

		//2結訓條件至少須設定一個
		var detailS = (from c in dcTraining.trTrainingDetailS
					   where c.iClassAutoKey == key
					   select c).FirstOrDefault();

		if (detailS == null)
		{
			throw new ApplicationException("至少須設定一項結訓項目");
		}


		//3.上課時間是否有設定
		var classAttendDate = (from c in dcTraining.trAttendClassDate
							   where c.iClassAutoKey == key
							   select c).ToList();

		foreach (var c in classAttendDate)
		{
			if (!(c.dClassDateA.HasValue && c.dClassDateD.HasValue && c.iAttendMins.HasValue))
			{
				throw new ApplicationException(c.dClassDate.ToShortDateString() + "該天時間未設定");
			}


			//4.講師是否有設定，一堂課可以多講師，要注意
			var classAttendTeacher = (from t in dcTraining.trAttendClassTeacher
									  where t.iClassAutoKey == key && t.dClassDate == c.dClassDate
									  select t).ToList();

			if (classAttendTeacher.Count == 0)
			{
				throw new ApplicationException(c.dClassDate.ToShortDateString() + "該天講師未設定");
			}

			foreach (var t in classAttendTeacher)
			{
				if (t.sTeacherCode == null)
				{
					throw new ApplicationException(c.dClassDate.ToShortDateString() + "該天講師未設定");
				}
			}

			//5.地點是否有設定
			var classAttendPlace = (from p in dcTraining.trAttendClassPlace
									where p.iClassAutoKey == key && p.dClassDate == c.dClassDate
									select p).FirstOrDefault();

			if (classAttendPlace == null)
			{
				throw new ApplicationException(c.dClassDate.ToShortDateString() + "該天地點未設定");
			}


			if (classAttendPlace.sPlaceCode == null)
			{
				throw new ApplicationException(c.dClassDate.ToShortDateString() + "該天地點未設定");
			}                        
		}

		//如果有開放網路報名，要確認輸入時間對不對
		if (classObj.bWebJoin.HasValue && classObj.bWebJoin.Value)
		{
			if (!IsValidWebDateTime(classObj.dWebJoinDateB.Value, classObj.dWebJoinDateE.Value,classObj.dDateTimeA.Value))
			{
				throw new ApplicationException("網路報名時間有誤，不可小於開課時間，或結束時間小於開始時間");
			}
		}
	}

	/// <summary>
	/// 是否為合法的web報名時間
	/// </summary>
	/// <param name="webBeginDatetime"></param>
	/// <param name="webEndDatetime"></param>
	/// <param name="classBeginDatetime"></param>
	/// <returns></returns>
	public bool IsValidWebDateTime(DateTime webBeginDatetime, DateTime webEndDatetime, DateTime classBeginDatetime)
	{
		if (webBeginDatetime == null || webEndDatetime == null || classBeginDatetime == null)
			return false;

		if (webEndDatetime.CompareTo(webBeginDatetime) <= 0)
			return false;

		if(classBeginDatetime.CompareTo(webBeginDatetime)<0 || classBeginDatetime.CompareTo(webEndDatetime)<0)
			return false;

		return true;
	}


	/// <summary>
	/// 發佈課程
	/// </summary>
	/// <param name="ClassID"></param>
	public void PublishCourse(int ClassID,string keyMan)
	{
		var obj = (from c in dcTraining.trTrainingDetailM
				   where c.iAutoKey == Convert.ToInt32(ClassID)
				   select c).FirstOrDefault();

		//設定開課課程上課的起迄時間(正確的時間)
		SetCourseStartTimeEndTime(obj);

		IsValidClass(obj.iAutoKey);		

		//設定使用此課程的教案存檔
		if (obj.iMaterialAutoKey != null)
		{
			var material = (from c in dcTraining.trTeachingMaterial
							where c.iAutoKey == obj.iMaterialAutoKey.Value
							select c).FirstOrDefault();
			if (material != null)
			{
				material.bSaved = true;
			}
		}

		//設定此課程的有效期限 Datetime
		var course = (from c in dcTraining.trCourse
					  where c.sCode == obj.trCourse_sCode
					  select c).FirstOrDefault();

		if (course != null)
		{
			if (course.iValidityDay.HasValue)
			{
				obj.dExpiryDate = obj.dDateD.Value.AddDays(course.iValidityDay.Value);
			}
			else
			{
				obj.dExpiryDate = obj.dDateD.Value;
			}
		}

		//設定是否需要課後心得，學員表現評分，如果要，則設定最後填寫日
		if (obj.bIsNeedClassRpt)
		{
			if (!obj.dClassRptDeadline.HasValue)
				obj.dClassRptDeadline = obj.dDateD.Value.AddDays(obj.iClassRptDateSpan + 1);
		}
		else
		{
			obj.dClassRptDeadline = null;
		}

		if (obj.bIsNeedStudentScore)
		{
			if(!obj.dStudentScoreDeadline.HasValue)
				obj.dStudentScoreDeadline = obj.dDateD.Value.AddDays(obj.iStudentScoreDateSpan + 1);
		}
		else
		{
			obj.dStudentScoreDeadline = null;
		}


		//設定課程問卷的填寫截止日
		var classQuestionnaire = (from c in dcTraining.ClassQuestionnaire
								  where c.iClassAutoKey == obj.iAutoKey
								  select c).ToList();

		foreach (var cq in classQuestionnaire)
		{
			var q = (from c in dcTraining.qQuestionaryM
					 where c.sCode == cq.qQuestionaryM
					 select c).FirstOrDefault();
			if (q != null)
			{
				cq.dDeadLine = obj.dDateTimeD.Value.AddDays(q.FillFormSpan);
			}
		}

        //開課時，將實支費用帶入預估費用
        Course courseFacade = new Course();
        courseFacade.LoadCost(obj.iAutoKey);

        //載入 CourseTeacher
        courseFacade.SyncCourseTeacher(obj.iAutoKey);

        //內部講師
        if (obj.trTeacher_sCode.Equals("01"))
        {
            CalculateInstructorFee(obj.iAutoKey);
        }

        CalculateInstructorTime(obj.iAutoKey);

		//設定課程學員人數
		trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
		obj.iStudentNum = tdmRepo.GetLatestStudentNum(obj.iAutoKey);

		dcTraining.SubmitChanges();

		DoHelper doHelper = new DoHelper();
		trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
		//設定學員的必訓條件等等資料、問卷設定

		tsmRepo.AddStudentByClass(obj.iAutoKey, keyMan);




		CourseObj = obj;
		obj.bIsPublished = true;
		dcTraining.SubmitChanges();
	}

	/// <summary>
	/// 計算內部講師費用分攤
	/// </summary>
	/// <param name="ClassID"></param>
	public void CalculateInstructorFee(int classId)
	{
		//判斷是否需要去計算內部講師費用分攤
		mtCode_Repo mtCodeRepo = new mtCode_Repo();
		var mtCodeCalculateInstructor = mtCodeRepo.GetByCategroyCode("Fee" , "CalculateInstructor");
		if ( mtCodeCalculateInstructor == null || !mtCodeCalculateInstructor.b1.HasValue )
			throw new ApplicationException("未設定mtCode參數Fee-CalculateInstructor-b1");

		ClassTeacher_Repo classTeacherRepo = new ClassTeacher_Repo();
		List<ClassTeacher> classTeacherList = classTeacherRepo.GetByClassKey(classId);

		try
		{
			if (mtCodeCalculateInstructor.b1.Value)
			{
				if (classTeacherList.FirstOrDefault() != null)
				{
					Int32 fee = GetInstructorFee(classId) / classTeacherList.Count(); ;

					foreach (var t in classTeacherList)
					{
						t.Charge = fee;
						classTeacherRepo.Update(t);
					}
					classTeacherRepo.Save();
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 計算講師時間
	/// </summary>
	/// <param name="classId"></param>
	public void CalculateInstructorTime(int classId)
	{
		trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
		var classObj = tdmRepo.GetByKey_DLO(classId);
		if ( classObj == null )
			throw new ApplicationException("課程錯誤");
		if ( !classObj.iCourseTime.HasValue )
			throw new ApplicationException("課程時間尚未設定");

		ClassTeacher_Repo classTeacherRepo = new ClassTeacher_Repo();
		List<ClassTeacher> classTeacherList = classTeacherRepo.GetByClassKey(classId);

		int mins = classObj.iCourseTime.Value / classTeacherList.Count();
		foreach ( var t in classTeacherList )
		{
			t.Minutes = mins;
			classTeacherRepo.Update(t);
		}        
		classTeacherRepo.Save();
	}

	/// <summary>
	/// 檢查ClassTeacher的數值是否正確
	/// </summary>
	/// <param name="classId"></param>
	/// <param name="list"></param>
	/// <returns></returns>
	public bool ValidateClassTeacher(trTrainingDetailM classObj,List<ClassTeacher> list)
	{
		//內部講師
		if (classObj.trTeacher_sCode.Equals("01"))
		{
			int fees = (from c in list select c.Charge.Value).Sum();
			if (GetInstructorFee(classObj.iAutoKey) != fees)
				return false;
		}

		int mins = (from c in list select c.Minutes.Value).Sum();
		if (classObj.iCourseTime != mins)
			return false;

		return true;    
	}

	/// <summary>
	/// 設定課程開始結束時間
	/// </summary>
	/// <param name="obj"></param>
	public void SetCourseStartTimeEndTime(trTrainingDetailM obj)
	{
		var AttendClassDate = (from c in dcTraining.trAttendClassDate
							   where c.iClassAutoKey == obj.iAutoKey
							   select c).ToList();

		var adate = (from c in AttendClassDate
					 select c.dClassDateA).Min();

		var ddate = (from c in AttendClassDate
					 select c.dClassDateD).Max();

		obj.dDateTimeA = adate;
		obj.dDateTimeD = ddate;
	}


	/// <summary>
	/// 取得課程講師費用
	/// </summary>
	/// <param name="classId"></param>
	/// <returns></returns>
	public Int32 GetInstructorFee(int classId)
	{
			mtCode_Repo mtCodeRepo = new mtCode_Repo();
			var mtCodeInstructor = mtCodeRepo.GetByCategroyCode("Fee" , "Instructor");
			if ( mtCodeInstructor == null )
				throw new ApplicationException("未設定mtCode參數Fee-Instructor-s1");

			trTrainingActualCost_Repo tacRepo = new trTrainingActualCost_Repo();
			var tacObj = tacRepo.GetByClassKeyCostItemCode(classId , mtCodeInstructor.s1);
			if (tacObj != null)
			{
				return tacObj.iAmt;
			}
			else
			{
				throw new ApplicationException("課程時間尚未設定");
			}
	}
}