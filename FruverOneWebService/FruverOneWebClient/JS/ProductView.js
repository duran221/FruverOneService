
let listProduct = new Array();

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

    $("#addCar").on("click", function () {

        var obj = {
            name: $("#nameProduct").text(),
            img: $("#codProduct").text(),
            price: parseInt($("#priceProduct").text()),
            quantity: parseInt($("#quantityClient").val()),
            total: parseFloat($("#totalProduct").text()),
            cod: $("#codProduct").text()
        };

        listProduct.push(obj);
        let result = `<ul class="list-unstyled">`;
        for (var i in listProduct) {

            result += ` <li class="media">
                        <img src="/Img/${listProduct[i].img}.jpg"  width="40" height="40" alt="...">&nbsp;&nbsp;
                        <div class="media-body">
                        <small>
                          <strong>${listProduct[i].name}</strong><br/>
                           <strong>Precio: </strong>${listProduct[i].price} <br/>
                            <strong>Cantidad: </strong>${listProduct[i].quantity} <br\>
                             <strong>Total: </strong>${listProduct[i].total}
                         </small>
                        </div>
                      </li>`;
        }
        result += `</ul>`;

        result += `
                <form method="post" action="https://gateway.payulatam.com/ppp-web-gateway/pb.zul" accept-charset="UTF-8">
                    <input type="image" border="0" alt="" src="http://www.payulatam.com/img-secure-2015/boton_pagar_pequeno.png" onClick="this.form.urlOrigen.value = window.location.href;" />
                    <input name="buttonId" type="hidden" value="xqJWMQj+dAYgS+XpK0nJOq76dR0h1ONm5ofnxKm37/1yVlpPnXnp8g==" />
                    <input name="merchantId" type="hidden" value="657443" />
                    <input name="accountId" type="hidden" value="659978" />
                    <input name="description" type="hidden" value="Aguacate10kilosGuanabana1kilo" />
                    <input name="referenceCode" type="hidden" value="F0005" />
                    <input name="amount" type="hidden" value="30000.00" />
                    <input name="tax" type="hidden" value="0.00" />
                    <input name="taxReturnBase" type="hidden" value="0.00" />
                    <input name="shipmentValue" value="0.00" type="hidden" />
                    <input name="currency" type="hidden" value="COP" />
                    <input name="lng" type="hidden" value="es" />
                    <input name="displayBuyerComments" type="hidden" value="true" />
                    <input name="buyerCommentsLabel" type="hidden" value="es:Dejanos un Comentario" />
                    <input name="sourceUrl" id="urlOrigen" value="" type="hidden" />
                    <input name="buttonType" value="SIMPLE" type="hidden" />
                    <input name="signature" value="b266ef2089211c48d8208a5bfa84dab07e714db46e63e3b2e4b95b91bed0ec77" type="hidden" />
                </form>`;

        $("#listCar").html(`${result}`);

    })

});
