namespace WpfDesignTimeData.SampleData {
    using System.Collections.Generic;
    using WpfDesignTimeData.Model;

    public class SampleDataViewModel {

        public List<Brand> Brands { get; set; } = new List<Brand>();

        public Product Product { get; set; }

        public SampleDataViewModel() {
        }

    }
}
