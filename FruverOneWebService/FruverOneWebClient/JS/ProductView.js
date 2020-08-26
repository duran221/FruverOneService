$(document).ready(function () {
    $("#decreaseProduct").on("click", function () {
        var aux = parseInt($("#quantityClient").val());
        var dec = aux - 1;

        if (dec > 0) {

            var desc = parseFloat($("#descProduct").text());
            var cantPrice = parseInt($("#priceProduct").text());

            var total = dec * (cantPrice - (cantPrice * (desc / 100)));

            $("#quantityClient").val(dec);
            $("#cantShop").text(dec);
            $("#totalProduct").text(total);
            
            
        }
      
    });

    $("#increaseProduct").on("click", function () {
        var aux = parseInt($("#quantityClient").val());
        var aum = aux + 1;
        $("#quantityClient").val(aum);

        var desc = parseFloat($("#descProduct").text());
        var cantPrice = parseInt($("#priceProduct").text());

        var total = aum * (cantPrice - (cantPrice * (desc / 100))); 
        $("#cantShop").text(aum);
        $("#totalProduct").text(total);

    });

});
