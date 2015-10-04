//var viewModel;

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


//Display the modal dialog
$(function () {
    $('#edit').click(function () {
        var url = $('#modal').data('url');

        $.get(url, function (data) {
            $('#modal-container').html(data);
            $('.modal').modal('show');
        });
    });
});

//
