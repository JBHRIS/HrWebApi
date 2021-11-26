using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JBModule.Pluging
{
	public class CDisk
	{
		public static string FindDirectory(string startPath, string dirSearchPattern, string fileSearchPattern)
		{
			string path = "";
			DirectoryInfo sdi;

			if (startPath.IndexOf("bin") != -1)
			{
				sdi = new DirectoryInfo(startPath + "\\..\\..\\");
			}
			else
			{
				sdi = new DirectoryInfo(startPath);
			}
			path = sdi.FullName;

			DirectoryInfo[] dis = sdi.GetDirectories(dirSearchPattern, SearchOption.AllDirectories);

			if (dis.Count() > 0)
			{
				if (dis.Count() == 1) path = dis[0].FullName;
				if (fileSearchPattern.Trim().Length > 0)
				{
					foreach (DirectoryInfo di in dis)
					{
						FileInfo[] fis = di.GetFiles(fileSearchPattern, SearchOption.AllDirectories);

						if (fis.Count() > 0)
						{
							path = fis[0].DirectoryName;
							break;
						}
					}
				}
			}

			return path + @"\";
		}
	}
}
