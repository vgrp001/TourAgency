$(document).ready(function () {
    var date_input = $('input[id="picker"]');
    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    var date = new Date();
    var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
    var options = {
        format: 'dd/mm/yyyy',
        container: container,
        todayHighlight: true,
        startDate: today,
        autoclose: true,
        orientation: 'bottom'
    };
    date_input.datepicker(options);
})

$(document).ready(function () {
    $('.popup-link').magnificPopup({
        type: 'inline',
        midClick: true
    });
    $(document).on('click', '.popup-ok', function (e) {
        e.preventDefault();
        $.magnificPopup.close();
        document.getElementById('Form').submit();
    });
    $(document).on('click', '.popup-no', function (e) {
        e.preventDefault();
        $.magnificPopup.close();
        document.getElementById('Close').click();
    });
});

$(document).ready(function () {
    setInterval(window.onload = function () {

        const reg = /^[0-9]{12,13}$/,
            input = document.querySelectorAll('.numInput');
        for (var i = 0; i < input.length; i++) {
            input[i].addEventListener('input', function (e) {
                e.target.value = e.target.value.replace(reg, '');
            });
        }
    });
})

