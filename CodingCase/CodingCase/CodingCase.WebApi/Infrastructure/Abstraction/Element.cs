using System;
using CodingCase.WebApi.Infrastructure.Attributes;

namespace CodingCase.WebApi.Infrastructure.Abstraction
{
    public abstract class Element
    {
        public Guid Id { get; set; }
        public abstract string Description { get; set; }

        public virtual int GetWeight(string filter)
        {
            return GetWeightForObject<WeightAttribute>(this, filter);
        }

        protected int GetWeightForObject<T>(Element obj, string filter) where T : IWeight
        {
            filter = filter?.ToLower() ?? "";

            if (string.IsNullOrEmpty(filter))
                return 0;

            var properties = obj.GetType().GetProperties();

            var sum = 0;

            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    if (!(attr is T weightAttribute))
                        continue;

                    var propertyValue = (string)prop.GetValue(obj, null);

                    if (string.IsNullOrEmpty(propertyValue))
                        continue;

                    propertyValue = propertyValue.ToLower();
                    
                    if (propertyValue == filter)
                    {
                        sum += 10 * weightAttribute.Weight;
                    }
                    else if (propertyValue.Contains(filter))
                    {
                        sum += weightAttribute.Weight;
                    }
                }
            }
            return sum;
        }
    }
}
