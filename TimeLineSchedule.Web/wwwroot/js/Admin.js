$(document).ready(function () {
    const dtp1Instance = new mds.MdsPersianDateTimePicker(document.getElementById('dtp1'), {
        targetTextSelector: '[data-name="dtp1-text"]',
    });

    $('.dtp-trigger').each(function () {
        var target = $(this).data('date-target');
        new mds.MdsPersianDateTimePicker(this, {
            targetTextSelector: '[data-name="' + target + '"]',
        });
    });
});