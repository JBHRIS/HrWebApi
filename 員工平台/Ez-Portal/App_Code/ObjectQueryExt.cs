using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.UI;

/// <summary>
/// ObjectQueryExt 的摘要描述
/// </summary>
public static class ObjectQueryExt
{
    public static IQueryable<TElement> WhereIn<TElement, TValue>(this IQueryable<TElement> source, Expression<Func<TElement, TValue>> propertySelector, params TValue[] values)
    {
        return source.Where(BuildWhereInExpression(propertySelector, values));
    }

    private static Expression<Func<TElement, bool>> BuildWhereInExpression<TElement, TValue>(Expression<Func<TElement, TValue>> propertySelector, IEnumerable<TValue> values)
    {
        ParameterExpression p = propertySelector.Parameters.Single();
        if (!values.Any())
            return e => false;

        var equals = values.Select(value => (Expression)Expression.Equal(propertySelector.Body, Expression.Constant(value, typeof(TValue))));
        var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));

        return Expression.Lambda<Func<TElement, bool>>(body, p);
    }

    /// <summary>
    /// 若值為DBNull.Value, 則轉為Null
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public static object DbNullToNull(this object original)
    {
        return original == DBNull.Value ? null : original;
    }

    /// <summary>
    /// 若值為null, 則轉成DBNull.Value
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public static object NullToDbNull(this object original)
    {
        return original ?? DBNull.Value;
    }

    public static IEnumerable<Control> GetPageAllControls(this ControlCollection controls)
    {
        if (controls.Count > 0)
        {
            foreach (Control control in controls)
            {

                if (control.Controls.Count > 0)
                foreach (Control grandChild in control.Controls.GetPageAllControls())
                    yield return grandChild;
            
                yield return control;
            }
        }
    }
}
