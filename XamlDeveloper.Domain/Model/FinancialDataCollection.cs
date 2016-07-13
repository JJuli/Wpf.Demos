namespace XamlDeveloper.Domain.Model {
    using System;
    using System.Collections.ObjectModel;

    public class FinancialDataCollection : ObservableCollection<FinancialDataPoint> {

        public FinancialDataCollection() {
            this.Add(new FinancialDataPoint {Spending = 20, Budget = 60, Label = "Administration"});
            this.Add(new FinancialDataPoint {Spending = 80, Budget = 40, Label = "Sales"});
            this.Add(new FinancialDataPoint {Spending = 30, Budget = 60, Label = "IT"});
            this.Add(new FinancialDataPoint {Spending = 80, Budget = 40, Label = "Marketing"});
            this.Add(new FinancialDataPoint {Spending = 40, Budget = 60, Label = "Development"});
            this.Add(new FinancialDataPoint {Spending = 60, Budget = 20, Label = "Customer Support"});
        }

    }

    public class FinancialDataPoint {

        public Double Budget { get; set; }

        public String Label { get; set; }

        public Double Spending { get; set; }

        public string ToolTip => $"{this.Label}, Spending {this.Spending}, Budget {this.Budget}";

    }
}
