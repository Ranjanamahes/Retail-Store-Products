var productJsonData = {

    allproduct_URL: WebApiURL + "api/products",
    allproductbyCategory_URL: WebApiURL + "api/category/getbyname",

    GetAllProducts: function () {
        var returndata;
        // Send an AJAX request
        $.getJSON(productJsonData.allproduct_URL)
            .done(function (data) {
                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    $('<li>', { text: productJsonData.formatItem(item) }).appendTo($('#products'));
                });
            });

        return returndata;
    },
    //format product and related details in a row.
    formatItem: function formatItem(item) {
        return item.SKU + ':' + item.Name + '       $' + item.Price;
    },
    findbyCategory: function () {
        var id = $('#prodId').val();
        $.getJSON(productJsonData.allproductbyCategory_URL + '/' + id)
            .done(function (data) {
                var searchResult = '';

                $.each(data, function (key, item) {
                    // Add a list item for the product.
                    searchResult += ' <br/> ' + productJsonData.formatItem(item);
                });
                $('#product').html(searchResult);
            })
            .fail(function (jqXHR, textStatus, err) {
                $('#product').text('Error: ' + err);
            });
    }

}