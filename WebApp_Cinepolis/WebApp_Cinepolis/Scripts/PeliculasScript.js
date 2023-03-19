var textarea = document.querySelector('textarea');

textarea.addEventListener('keydown', autosize);
document.addEventListener("DOMContentLoaded", clickRadioButtonAdultos);
document.addEventListener("DOMContentLoaded", autosize_onload);

function autosize() {
    var el = this;
    setTimeout(function () {
        el.style.cssText = 'height: fit-content; padding:0; width: 100%;';
        el.style.cssText = 'height:' + el.scrollHeight + 'px; width: 100%;';
        
    }, 0);
}

function autosize_onload() {
    var el = textarea;
    setTimeout(function () {
        textarea.style.cssText = 'height: fit-content; padding:0; width: 100%;';
        textarea.style.cssText = 'height:' + el.scrollHeight + 'px; width: 100%;';
    }, 0);
}

function clickRadioButtonAdultos() {

    //Obtención de los elementos de la edición de Acciones
    var divAcciones = document.getElementById("form_acciones");
    
    // Ocultado de elementos según el tipo de combo que sea
    if ($("#AdultosRadio").prop('checked')) {//Caso es para adulto
        divAcciones.style = "display: block;";

    } else {
        divAcciones.style = "display: none;";
    }
    if ($("#NinosRadio").prop('checked')) {//Caso es para niños
        if (textarea.value.substring(0, 14).indexOf("Hola amiguitos") == -1) {
            textarea.value = "Hola amiguitos " + textarea.value;
        }
    }
}
