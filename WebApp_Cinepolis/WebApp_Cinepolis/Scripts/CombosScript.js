document.addEventListener("DOMContentLoaded", clickRadioButtonTipo);

function clickRadioButtonTipo() {

    //Obtención de los elementos de la edición del Juguete
    var divJuguete = document.getElementById("formJuguete");

    //Obtención de los elementos de la edición del Tiquete
    var divTiquete = document.getElementById("formTiquete");

    // Ocultado de elementos según el tipo de combo que sea
    if ($("#AdultosRadio").prop('checked')) {//Caso es para adulto
        divTiquete.style = "display: block;";
        divJuguete.style = "display: none;";
    } else {//Caso es para niños
        divJuguete.style = "display: block;";
        divTiquete.style = "display: none;";
    }
}


