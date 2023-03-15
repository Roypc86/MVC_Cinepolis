var textarea = document.querySelector('textarea');

textarea.addEventListener('keydown', autosize);
document.addEventListener("DOMContentLoaded", clickRadioButtonAdultos);

function autosize() {
    var el = this;
    setTimeout(function () {
        el.style.cssText = 'height: fit-content; padding:0; width: 100%;';
        el.style.cssText = 'height:' + el.scrollHeight + 'px; width: 100%;';
        
    }, 0);
}


function clickRadioButtonAdultos() {

    //Obtención de los elementos de la edición del Juguete
    var divAcciones = document.getElementById("form_acciones");
    console.log($("#AdultosRadio").prop('checked'))
    // Ocultado de elementos según el tipo de combo que sea
    if ($("#AdultosRadio").prop('checked')) {//Caso es para adulto
        divAcciones.style = "display: block;";

    } else {//Caso es para niños
        divAcciones.style = "display: none;";
    }
}
