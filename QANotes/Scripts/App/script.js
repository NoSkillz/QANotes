var viewModel;

//Select Email fields on page load
window.onload = function () {
    emailElement = document.getElementById('Email');
    emailElement.focus();
};


window.onload = function () {
    $('.submit-btn').click(function () {
        $.ajax({
            url: './Notes/SaveNote',
            type: 'POST',
            contentType: "application/json",
            data: ko.mapping.toJSON(viewModel),
            success: function(result) {
                console.log(result);
            },
            error: function (result) {
                console.log(result);
            }
        });
    });
};