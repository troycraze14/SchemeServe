using System.Collections;
using System.Web;

namespace SchemeServe.Provider.Api.Infrastructure.Services.HttpApiClient
{
    public static class QueryExtensions
    {
        private static string ToCamelCase(this string prop) => char.ToLowerInvariant(prop[0]) + prop.Substring(1);

        public static string ToQueryString(this object obj)
        {
            var result = new List<string>();
            var props = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null);
            foreach (var p in props)
            {
                var value = p.GetValue(obj, null);
                if (value is ICollection enumerable)
                {
                    result.AddRange(from object v in enumerable select $"{p.Name.ToCamelCase()}={HttpUtility.UrlEncode(v.ToString())}");
                }
                else if (value is not null)
                {
                    result.Add($"{Uri.EscapeDataString(p.Name.ToCamelCase())}={HttpUtility.UrlEncode(value.ToString())}");
                }
            }

            return string.Join("&", result.ToArray());
        }
    }
}
