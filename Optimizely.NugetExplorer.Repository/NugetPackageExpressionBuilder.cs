using Optimizely.NugetExplorer.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Optimizely.NugetExplorer.Repository
{
    public class NugetPackageExpressionBuilder
    {
        public Expression<Func<NugetPackage, bool>> BuildExpression (NugetPackageQuery query)
        {
            Expression? currentExpression = null;
            var modelParameterExpression = Expression.Parameter(typeof(NugetPackage), "nuget");

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                currentExpression = CreateExpression(query.Name, null, nameof(NugetPackage.Name), modelParameterExpression);
            }

            if (!string.IsNullOrWhiteSpace(query.Version))
            {
                currentExpression = CreateExpression(query.Version, currentExpression, nameof(NugetPackage.Version), modelParameterExpression);
            }

            if (query.InternalOnly.HasValue)
            {
                currentExpression = CreateExpression(query.InternalOnly.Value, currentExpression, nameof(NugetPackage.InternalOnly), modelParameterExpression);
            }

            if (query.NetFlavor.HasValue)
            {
                currentExpression = CreateExpression(query.NetFlavor.Value, currentExpression, nameof(NugetPackage.NetFlavor), modelParameterExpression);
            }

            if (query.TotalDownload.HasValue)
            {
                currentExpression = CreateExpression(query.TotalDownload.Value, currentExpression, nameof(NugetPackage.TotalDownload), modelParameterExpression);
            }

            if (string.IsNullOrWhiteSpace(query.Tag))
            {
                // https://stackoverflow.com/questions/22913540/dynamic-linq-query-contains-list
                // https://stackoverflow.com/questions/27295702/how-do-you-check-if-a-string-contains-any-strings-from-a-list-in-entity-framewor
                // contains method
                var containsMethod = typeof(List<string>).GetMethod("Contains", new[] { typeof(string) }); // List<string>.Contains(string)
            }

            if (currentExpression is object)
            {
                var searchExpression = Expression.Lambda<Func<NugetPackage, bool>>(
                    body: currentExpression,
                    tailCall: false,
                    parameters: new List<ParameterExpression> { modelParameterExpression });

                //var searchFunc = searchExpression.Compile();
                return searchExpression;
            }

            return null;
        }

        /// <summary>
        /// Aggregates an expression with a property and an operator
        /// </summary>
        /// <typeparam name="TType">The type of parameter</typeparam>
        /// <param name="value">The value of parameter to use in expression</param>
        /// <param name="currentExpression">The current expression to aggregate, if any</param>
        /// <param name="propertyName">The name of property to call on modelExpressionParameter</param>
        /// <param name="modelExpressionParameter">The model expression parameter to evaluate</param>
        /// <param name="operatorType">Operator to use. Defaults to &#61;</param>
        /// <param name="expressionType">ExpressionType.Or / ExpressionType.And</param>
        private static Expression CreateExpression<TType>(
            TType value,
            Expression? currentExpression,
            string propertyName, 
            ParameterExpression modelExpressionParameter,
            string operatorType = "=",
            ExpressionType expressionType = ExpressionType.And) // https://docs.microsoft.com/en-us/dotnet/api/system.linq.expressions.binaryexpression?view=net-6.0
        {
            ConstantExpression propertyValueExpression = Expression.Constant(value);
            MemberExpression propertyModelExpression = Expression.Property(modelExpressionParameter, propertyName); // nuget.PropertyName
            BinaryExpression operatorExpression = null; // nuget.PropertyName == value

            switch (operatorType)
            {
                case ">":
                    operatorExpression = Expression.GreaterThan(propertyModelExpression, propertyValueExpression);
                    break;
                case ">=":
                    operatorExpression = Expression.GreaterThanOrEqual(propertyModelExpression, propertyValueExpression);
                    break;
                case "<":
                    operatorExpression = Expression.LessThan(propertyModelExpression, propertyValueExpression);
                    break;
                case "<=":
                    operatorExpression = Expression.LessThanOrEqual(propertyModelExpression, propertyValueExpression);
                    break;
                default:
                    operatorExpression = Expression.Equal(propertyModelExpression, propertyValueExpression);
                    break;
            }

            if (currentExpression is null)
            {
                currentExpression = operatorExpression;
            }
            else
            {
                var previousExpresion = currentExpression;
                //currentExpression = Expression.And(previousExpresion, operatorExpression);
                switch(expressionType)
                {
                    case ExpressionType.Or:
                        currentExpression = Expression.Or(previousExpresion, operatorExpression);
                        break;
                    default:
                        currentExpression = Expression.And(previousExpresion, operatorExpression);
                        break;
                }
            }

            return currentExpression;
        }
    }
}
