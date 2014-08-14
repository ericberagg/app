using System.Collections.Generic;

namespace app.web.application.catalog_browsing
{
    public interface IFindProducts
    {
        IEnumerable<ProductLineItem> get_the_products(ProductsInDepartmentInput input);
    }

    public class ProductLineItem
    {
    }
}