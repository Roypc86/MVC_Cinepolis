

function actualizarIdSala() {
    $("#inputSalaId").empty();
    $.ajax({
        type: 'POST',
        url: '/Salas/ObtenerSalaId/',
        dataType: 'json',
        data: { id_cine: $("#DropdownCineId").val() },
        success: function (id) {
            document.getElementById("InputSalaId").value = id;

        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error: ' + errorThrown);
        }
    });
    return false;
}