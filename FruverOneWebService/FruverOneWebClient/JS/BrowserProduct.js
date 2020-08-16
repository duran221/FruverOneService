var URL = "https://localhost:44304/api/GetProduct";
$.ajax({
    type: "GET",                                              // tipo de request que estamos generando
    url: URL,                    // URL al que vamos a hacer el pedido
    data: null,                                                // data es un arreglo JSON que contiene los parámetros que
    // van a ser recibidos por la función del servidor
    contentType: "application/json; charset=utf-8",            // tipo de contenido
    dataType: "json",                                          // formato de transmición de datos
    async: true,                                               // si es asincrónico o no
    success: function (resultado) {                            // función que va a ejecutar si el pedido fue exitoso

        for (var i = 0; i < resultado.items.length; i++) {
            console.log(resultado.items[i]);
        }

        alert(resultado.items);

    },
    error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
        var error = eval("(" + XMLHttpRequest.responseText + ")");
        alert(error.Message);
    }
});
