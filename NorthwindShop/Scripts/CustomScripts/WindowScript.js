$(document).ready(function () {
    $('.popup .close_window, .overlay').click(function () {
        $('.popup, .overlay').css({ 'opacity': '0', 'visibility': 'hidden' });
    });
    $('input.open_window').click(function (e) {
        $('.popup, .overlay').css({ 'opacity': '1', 'visibility': 'visible' });
        e.preventDefault();
    });
    $('#plusButton').click(function (e) {
        var getVal = $('#InputText').val();
        getVal++;
        $('#InputText').val(String(getVal));
    });
    $('#minusButton').click(function (e) {
        var getVal = $('#InputText').val();
        if (getVal != 0) {
            getVal--;
            $('#InputText').val(String(getVal));
        }

    });
});

