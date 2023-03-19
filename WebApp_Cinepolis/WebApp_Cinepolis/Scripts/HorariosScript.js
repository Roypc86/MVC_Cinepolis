
if (document.getElementById("edit-page") == null) {
    document.addEventListener("DOMContentLoaded", updateDropdownSalas);
}

function updateDropdownSalas() {
    
    $("#DropdownSalasId").empty();
    $.ajax({
        type: 'POST',
        url: '/Horarios/ActualizarSalasId/',
        dataType: 'json',
        data: { id: $("#DropdownCinesId").val() },
        success: function (salas) {
            salas = salas.replace('{', '').replace('}', '');
            if (salas.length == 0) {
                alert('El cine seleccionado no posee salas.');
                document.getElementById('btn-guardar').disabled = true;
                return;
            }
            document.getElementById('btn-guardar').disabled = false;
            salas = salas.split(',');
            for (s in salas) {
                var number = salas[s].split(':')[1];
                $("#DropdownSalasId").append('<option value="' + number + '">' + number + '</option>');
                
            }
            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error: ' + errorThrown);
        }
    });
    return false;
}
