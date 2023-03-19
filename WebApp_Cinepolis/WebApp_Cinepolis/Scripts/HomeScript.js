var selector_cine = document.getElementById("selector-cine");

function onClickPeliculasButton() {
    window.location.href = '/Peliculas/Index/';
}

function onClickCombosButton() {  
    window.location.href = '/Combos/Index/?gen_view=' + false + '&id=' + getIdCine();
}

function onClickSalasButton() {
    window.location.href = '/Salas/Index/?gen_view=' + false + '&id=' + getIdCine();
}

function onClickHorariosButton() {
    window.location.href = '/Horarios/Index/?gen_view=' + false + '&id=' + getIdCine();
}

function getIdCine() {
    if (selector_cine.value == "") {
        return -1;
    }
    return selector_cine.value;
}