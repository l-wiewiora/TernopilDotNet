$(document).ready(function() {
    getComments();
});

$('#save-data-btn').click(function () {
    $('.loader').addClass('active');
    $.ajax({
        url: 'api/comments?comment=' + $('#comment').val(),
        method: 'POST'
    }).done(function () {
        $('#comment').val('');
        getComments();
        $('.loader').removeClass('active');
    });
});

function getComments() {
    $.ajax({
        url: 'api/comments',
        method: 'GET'
    }).done(function (data) {
        $('#comments-section').empty();
        $.each(data,
            function (index, comment) {
                if (comment != null) {
                    var newItem = document.createElement('li');
                    $(newItem).text(comment);
                    $('#comments-section').append(newItem);
                }
            });
    });
}