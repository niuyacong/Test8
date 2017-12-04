﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Test.Controllers
{
    public  static class QueryableExtension
    {
        //public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string propertyStr) where TEntity : class
        //{
        //    ParameterExpression param = Expression.Parameter(typeof(TEntity), "c");
        //    PropertyInfo property = typeof(TEntity).GetProperty(propertyStr);
        //    Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
        //    LambdaExpression le = Expression.Lambda(propertyAccessExpression, param);
        //    Type type = typeof(TEntity);
        //    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(le));
        //    return source.Provider.CreateQuery<TEntity>(resultExp);
        //}
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            return _OrderBy<T>(query, propertyName, false);
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            return _OrderBy<T>(query, propertyName, true);
        }

        static IOrderedQueryable<T> _OrderBy<T>(IQueryable<T> query, string propertyName, bool isDesc)
        {
            string methodname = (isDesc) ? "OrderByDescendingInternal" : "OrderByInternal";

            var memberProp = typeof(T).GetProperty(propertyName);

            var method = typeof(QueryableExtension).GetMethod(methodname)
                                       .MakeGenericMethod(typeof(T), memberProp.PropertyType);

            return (IOrderedQueryable<T>)method.Invoke(null, new object[] { query, memberProp });
        }
        public static IOrderedQueryable<T> OrderByInternal<T, TProp>(IQueryable<T> query, PropertyInfo memberProperty)
        {//public
            return query.OrderBy(_GetLamba<T, TProp>(memberProperty));
        }
        public static IOrderedQueryable<T> OrderByDescendingInternal<T, TProp>(IQueryable<T> query, PropertyInfo memberProperty)
        {//public
            return query.OrderByDescending(_GetLamba<T, TProp>(memberProperty));
        }
        static Expression<Func<T, TProp>> _GetLamba<T, TProp>(PropertyInfo memberProperty)
        {
            if (memberProperty.PropertyType != typeof(TProp)) throw new Exception();

            var thisArg = Expression.Parameter(typeof(T));
            var lamba = Expression.Lambda<Func<T, TProp>>(Expression.Property(thisArg, memberProperty), thisArg);

            return lamba;
        }
    }
}