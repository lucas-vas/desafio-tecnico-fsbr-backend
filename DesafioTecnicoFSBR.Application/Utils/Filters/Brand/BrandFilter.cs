using System.Linq.Expressions;

namespace DesafioTecnicoFSBR.Application.Utils.Filters.Brand
{
    internal static class BrandFilter
    {
        public static Expression<Func<Domain.Entities.Brand, bool>> Get(string? name)
        {
            Expression<Func<Domain.Entities.Brand, bool>> filter = brand => true;

            if (!string.IsNullOrEmpty(name))
            {
                filter = CombineFilters(filter, brand => brand.Name.ToUpper().Contains(name.ToUpper()));
            }

            return filter;
        }

        private static Expression<Func<T, bool>> CombineFilters<T>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, bool>> newFilter)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(
                Expression.Invoke(filter, parameter),
                Expression.Invoke(newFilter, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
