using System.Linq.Expressions;

namespace DesafioTecnicoFSBR.Application.Utils.Filters.Car
{
    internal static class CarFilter
    {
        public static Expression<Func<Domain.Entities.Car, bool>> Get
        (
            string? modelDescription,
            int? year,
            Guid? brandId
        )
        {
            Expression<Func<Domain.Entities.Car, bool>> filter = car => true;

            if (!string.IsNullOrEmpty(modelDescription))
            {
                filter = CombineFilters(filter, car => car.ModelDescription.ToUpper().Contains(modelDescription.ToUpper()));
            }

            if (year.HasValue)
            {
                filter = CombineFilters(filter, car => car.Year == year.Value);
            }

            if (brandId.HasValue)
            {
                filter = CombineFilters(filter, car => car.BrandId == brandId);
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
