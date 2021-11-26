using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JBHRIS.Api.Tools
{
	public static class DistinctComparer
	{
		public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> seenKeys = new HashSet<TKey>();
			foreach (TSource element in source)
			{
				var elementValue = keySelector(element);
				if (seenKeys.Add(elementValue))
				{
					yield return element;
				}
			}
		}
	}
}
