namespace XamlDeveloper.Domain.Data {
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using XamlDeveloper.Domain.Model;

    public class BusinessService : IBusinessService {

        public IList<SearchResult> AllSearchResults { get; private set; }

        public IList<Brand> Brands { get; private set; }

        public IList<Category> Categories { get; private set; }

        public FinancialDataCollection FinancialDataCollection { get; }

        public IList<Product> Products { get; private set; }

        public IList<Season> Seasons { get; private set; }

        public BusinessService() {
            this.FinancialDataCollection = new FinancialDataCollection();
        }

        public void LoadData() {
            var json = File.ReadAllText(@".\RawData\brands.json");
            this.Brands = JsonConvert.DeserializeObject<List<Brand>>(json);

            json = File.ReadAllText(@".\RawData\categories.json");
            this.Categories = JsonConvert.DeserializeObject<List<Category>>(json);

            json = File.ReadAllText(@".\RawData\seasons.json");
            this.Seasons = JsonConvert.DeserializeObject<List<Season>>(json);

            json = File.ReadAllText(@".\RawData\products.json");
            this.Products = JsonConvert.DeserializeObject<List<Product>>(json);

            var query = from p in this.Products
                join b in this.Brands on p.BrandId equals b.BrandIdent
                join c in this.Categories on p.CategoryId equals c.CategoryIdent
                select new SearchResult {
                    ProductIdent = p.ProductIdent,
                    Name = p.Name,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    BrandName = b.Name,
                    CategoryName = c.Name
                };

            this.AllSearchResults = query.ToList();
        }

    }
}
