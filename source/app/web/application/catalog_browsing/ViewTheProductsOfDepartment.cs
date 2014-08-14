using app.web.core;

namespace app.web.application.catalog_browsing
{
    public class ViewTheProductsOfDepartment : ISupportAUserStory
    {
        private IDisplayInformation display_engine;
        private IFindProducts product_finder;

        public ViewTheProductsOfDepartment(IDisplayInformation displayEngine, IFindProducts productFinder)
        {
            display_engine = displayEngine;
            product_finder = productFinder;
        }

        public void process(IProvideRequestDetails request)
        {
            var input = request.map<ProductsInDepartmentInput>();
            var products = product_finder.get_the_products(input);
            display_engine.display(products);
        }
    }

    public class ProductsInDepartmentInput
    {
    }
}