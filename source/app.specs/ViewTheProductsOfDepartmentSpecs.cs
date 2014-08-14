using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
    [Subject(typeof(ViewTheProductsOfDepartment))]
    public class ViewTheProductsOfDepartmentSpecs
    {
        public abstract class concern : Observes<ISupportAUserStory, ViewTheProductsOfDepartment>
        {
        }

        public class when_run : concern
        {
            private Establish c = () =>
            {
                product_finder = depends.on<IFindProducts>();
                display_engine = depends.on<IDisplayInformation>();
                input = new ProductsInDepartmentInput();
                products = new List<ProductLineItem>();
                request = fake.an<IProvideRequestDetails>();
                request.setup(x => x.map<ProductsInDepartmentInput>()).Return(input);
                product_finder.setup(x => x.get_the_products(input)).Return(products);
            };

            private Because b = () =>
                sut.process(request);

            private It displays_the_products_of_a_department = () =>
                display_engine.received(x => x.display(products));

            private static IFindProducts product_finder;
            private static IProvideRequestDetails request;
            private static ProductsInDepartmentInput input;
            private static IEnumerable<ProductLineItem> products;
            private static IDisplayInformation display_engine;

            //Establish c = () =>
            //{
            //    display_engine = depends.on<IDisplayInformation>();
            //    department_finder = depends.on<IFindDepartments>();
            //    request = fake.an<IProvideRequestDetails>();
            //    main_departments = new List<MainDepartmentLineItem>();

            //    department_finder.setup(x => x.get_the_main_departments()).Return(main_departments);
            //};

            //Because b = () =>
            //  sut.process(request);

            //It displays_the_departments = () =>
            //  display_engine.received(x => x.display(main_departments));

            //static IFindDepartments department_finder;
            //static IProvideRequestDetails request;
            //static IDisplayInformation display_engine;
            //static IEnumerable<MainDepartmentLineItem> main_departments;
        }
    }
}