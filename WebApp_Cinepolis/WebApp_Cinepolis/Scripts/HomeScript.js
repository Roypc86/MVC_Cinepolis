var selector_cine = document.getElementById("selector-cine");

function onClickPeliculasButton() {
    window.location.href = '/Peliculas/Index/' + selector_cine.value;
}

function onClickCombosButton() {  
    window.location.href = '/Combos/Index/?gen_view=' + false + '&id=' + selector_cine.value;
}

function onClickSalasButton() {
    window.location.href = '/Salas/Index/?gen_view=' + false + '&id=' + selector_cine.value;
}

function onClickHorariosButton() {
    window.location.href = '/Horarios/Index/?gen_view=' + false + '&id=' + selector_cine.value;
}