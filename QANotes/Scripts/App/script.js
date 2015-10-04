//Select Email fields on page load
$(function () {
    $('#Email').focus();
});


//Submit ko viewModel with ajax
$(function () {
    $('.submit-btn').click(function () {
        $.ajax({
            url: './Notes/SaveNote',
            type: 'POST',
            contentType: "application/json",
            data: ko.mapping.toJSON(viewModel),
            success: function (result) {
                console.log(result);
            },
            error: function (result) {
                console.log(result);
            }
        });
    });
});

// send an ajax request to edit the note. on success, it calls showModal passing the response
function editNote(id) {
    $.ajax({
        url: './Notes/Edit/' + id,
        type: 'GET',
        success: function (response) {
            showModal(response);
        },
        error: function (response) {
            console.log(response);
        }
    });
};

function showModal(e) {
    $('#modal-container').html(e);
    $('.modal').modal('show');
}
