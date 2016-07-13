namespace XamlDeveloper.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using Wpf.Common.Dialog;
    using XamlDeveloper.Domain.Data;
    using XamlDeveloper.Domain.Model;
    using XamlDeveloper.Presentation.View;
    using Xunit;

    public class XamlMVVMDemoCodeFixture {

        readonly IBusinessService _businessServiceMock;
        readonly Prism.Regions.NavigationContext _navigationContext;
        const String TestAllBrands = "All Brands";
        const String TestAllCategories = "All Categories";
        const String TestBrandName = "Test Brand";
        const String TestBrandNameAlternate = "Test Brand Alternate";
        const String TestCategoryName = "Test Category";
        const Double TestCostValue = 2.99;
        const Int32 TestIdentValue = 1;
        const Int32 TestIdentValueAlternate = 2;
        const String TestProductName = "Test Product";

        public XamlMVVMDemoCodeFixture() {
            var mock = new Mock<IBusinessService>();
            mock.Setup(x => x.AllSearchResults).Returns(new List<SearchResult> {new SearchResult {BrandId = TestIdentValue, BrandName = TestBrandName, CategoryId = TestIdentValue, CategoryName = TestCategoryName, Name = TestProductName, ProductIdent = TestIdentValue}});
            mock.Setup(x => x.Brands).Returns(
                new List<Brand> {
                    new Brand {BrandIdent = TestIdentValue, Name = TestBrandName},
                    new Brand {BrandIdent = TestIdentValueAlternate, Name = TestBrandNameAlternate}
                });
            mock.Setup(x => x.Categories).Returns(new List<Category> {new Category {CategoryIdent = TestIdentValue, Name = TestCategoryName}});
            mock.Setup(x => x.Products).Returns(new List<Product> {new Product {ProductIdent = TestIdentValue, Name = TestProductName, BrandId = TestIdentValue, CategoryId = TestIdentValue, Cost = TestCostValue, IsActive = true}});
            mock.Setup(x => x.Seasons).Returns(new List<Season>());
            mock.Setup(x => x.FinancialDataCollection).Returns(new FinancialDataCollection());
            _businessServiceMock = mock.Object;

            _navigationContext = new Prism.Regions.NavigationContext(null, null);
        }

        [Fact]
        public void ConfirmNavigationRequest_WhenCallBackIsTrue_NoDialogIsDisplayed() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>())).Returns(DialogResult.No);

            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);

            var test = false;

            // act
            sut.ConfirmNavigationRequest(It.IsAny<Prism.Regions.NavigationContext>(), confirm => test = confirm);

            // assert
            Assert.True(test);
            dialogService.Verify(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>()), Times.Never());
        }

        [Fact]
        public void ProductThatIsDirty_ConfirmNavigationRequest_CallBackIsFalseWhenDialogResultIsCancel() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>())).Returns(DialogResult.Cancel);

            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);
            sut.Product = new Product {IsDirty = true};

            var test = false;

            // act
            sut.ConfirmNavigationRequest(It.IsAny<Prism.Regions.NavigationContext>(), confirm => test = confirm);

            // assert
            Assert.False(test);
            dialogService.Verify(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>()), Times.Once);
        }

        [Fact]
        public void ProductThatIsDirty_ConfirmNavigationRequest_CallBackIsFalseWhenDialogResultIsNo() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>())).Returns(DialogResult.No);

            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);
            sut.Product = new Product {IsDirty = true};

            var test = false;

            // act
            sut.ConfirmNavigationRequest(It.IsAny<Prism.Regions.NavigationContext>(), confirm => test = confirm);

            // assert
            Assert.False(test);
            dialogService.Verify(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>()), Times.Once);
        }

        [Fact]
        public void ProductThatIsDirty_ConfirmNavigationRequest_CallBackIsTrueWhenDialogResultIsYes() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>())).Returns(DialogResult.Yes);

            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);
            sut.Product = new Product {IsDirty = true};

            var test = false;

            // act
            sut.ConfirmNavigationRequest(It.IsAny<Prism.Regions.NavigationContext>(), confirm => test = confirm);

            // assert
            Assert.True(test);
            dialogService.Verify(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>()), Times.Once);
        }

        [Fact]
        public void ProductThatIsNotDirty_ConfirmNavigationRequest_CallBackIsTrueNoDialogIsDisplayed() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>())).Returns(DialogResult.No);

            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);
            sut.Product = new Product {IsDirty = false};

            var test = false;

            // act
            sut.ConfirmNavigationRequest(It.IsAny<Prism.Regions.NavigationContext>(), confirm => test = confirm);

            // assert
            Assert.True(test);
            dialogService.Verify(x => x.ConfirmDialog(It.IsAny<String>(), It.IsAny<String>()), Times.Never());
        }

        [Fact]
        public void ConstructorThrows_WhenBusinessServiceIsNull() {
            Assert.Throws<ArgumentNullException>(() => new XamlMVVMDemoCodeViewModel(null, null));
        }

        [Fact]
        public void ConstructorThrows_WhenDialogServiceIsNull() {
            var mock = new Mock<IBusinessService>();
            Assert.Throws<ArgumentNullException>(() => new XamlMVVMDemoCodeViewModel(mock.Object, null));
        }

        [Fact]
        public void EditProductCommandExecute_ProductWithSameIdent_IsAvailableToUI() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var searchResult = new SearchResult {ProductIdent = TestIdentValue};
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext); // loads the data

            // act
            sut.EditProductCommand.Execute(searchResult);

            // assert
            Assert.True(sut.Product.ProductIdent == searchResult.ProductIdent);
        }

        [Fact]
        public void EditProductCommandExecute_Raises_Product_PropertyChanged() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var searchResult = new SearchResult {ProductIdent = TestIdentValue};
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext); // loads the data

            // act

            // assert
            Assert.PropertyChanged(sut, "Product", () => sut.EditProductCommand.Execute(searchResult));
        }

        [Fact]
        public void EditProductCommandExecute_Raises_IsNameFocused_PropertyChanged() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var searchResult = new SearchResult {ProductIdent = TestIdentValue};
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext); // loads the data

            // act

            // assert
            Assert.PropertyChanged(sut, "IsNameFocused", () => sut.EditProductCommand.Execute(searchResult));
        }

        [Fact]
        public void OnNavigatedTo_LoadsData() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var sut = new XamlMVVMDemoCodeViewModel(
                _businessServiceMock, dialogService.Object);

            // act
            sut.OnNavigatedTo(_navigationContext);

            // assert
            Assert.True(sut.Brands.Count() == 3);
            Assert.True(sut.Categories.Count() == 2);
        }

        [Fact]
        public void OnNavigatedTo_SetsDefaultSelectedItem_ForBrandAndCategory() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);

            // act
            sut.OnNavigatedTo(_navigationContext);

            // assert
            Assert.True(sut.SelectedBrand.BrandIdent == 0 && sut.SelectedBrand.Name == TestAllBrands);
            Assert.True(sut.SelectedCategory.CategoryIdent == 0 && sut.SelectedCategory.Name == TestAllCategories);
        }

        [Theory,
         InlineData("t", 0, 0, true),
         InlineData("t", 1, 0, true),
         InlineData("t", 0, 1, true),
         InlineData("t", 2, 1, false),
         InlineData("xyz", 0, 0, false)]
        public void SearchText_WhenChanged_ExecutesASearch(
            String searchText, Int32 brandId, Int32 categoryId, 
            Boolean expectsNonEmptyResult) {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);

            sut.SelectedBrand = sut.Brands.Single(x => x.BrandIdent == brandId);
            sut.SelectedCategory = sut.Categories.Single(x => x.CategoryIdent == categoryId);

            // act

            sut.SearchText = searchText;

            // assert
            if (sut.SearchResults == null || sut.SearchResults.Count == 0) {
                Assert.True(expectsNonEmptyResult == false);
            } else {
                Assert.True((sut.SearchResults.Count == 1) == expectsNonEmptyResult);
                Assert.True((sut.SearchResults[0].ProductIdent == TestIdentValue) == expectsNonEmptyResult);
            }
        }

        [Fact]
        public void SettingSearchStringToEmpty_MakesSearchResults_Null() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);

            // act
            sut.SearchText = String.Empty;

            // assert
            Assert.Null(sut.SearchResults);
        }

        [Fact]
        public void SettingSelectedBrand_ExecutesSearch() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);

            // act

            // assert
            Assert.PropertyChanged(sut, "SearchResults", () => sut.SelectedBrand = sut.Brands.Single(x => x.BrandIdent == TestIdentValue));
        }

        [Fact]
        public void SettingSelectedCategory_ExecutesSearch() {
            // arrange
            var dialogService = new Mock<IDialogService>();
            var sut = new XamlMVVMDemoCodeViewModel(_businessServiceMock, dialogService.Object);
            sut.OnNavigatedTo(_navigationContext);

            // act

            // assert
            Assert.PropertyChanged(sut, "SearchResults", () => sut.SelectedCategory = sut.Categories.Single(x => x.CategoryIdent == TestIdentValue));
        }

    }
}
