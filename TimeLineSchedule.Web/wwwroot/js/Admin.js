$(document).ready(function () {
    //Jalali date picker
    const dtp1Instance = new mds.MdsPersianDateTimePicker(document.getElementById('dtp1'), {
        targetTextSelector: '[data-name="dtp1-text"]',
    });

    $('.dtp-trigger').each(function () {
        var target = $(this).data('date-target');
        new mds.MdsPersianDateTimePicker(this, {
            targetTextSelector: '[data-name="' + target + '"]',
        });
    });

    //Pick the day of week from Jalali DatePicker
    document.getElementById('scheduledDateInput').addEventListener('change', function () {
        const selectedDate = new Date(this.value);
        const dayOfWeek = selectedDate.toLocaleDateString('en', { weekday: 'long' });

        const dayMap = {
            'Saturday': 'شنبه',
            'Sunday': 'یکشنبه',
            'Monday': 'دوشنبه',
            'Tuesday': 'سه شنبه',
            'Wednesday': 'چهارشنبه',
            'Thursday': 'پنجشنبه',
            'Friday': 'جمعه'
        };

        const translatedDay = dayMap[dayOfWeek];

        const daySelect = document.getElementById('dayOfWeekSelector');
        for (let i = 0; i < daySelect.options.length; i++) {
            if (daySelect.options[i].text === translatedDay) {
                daySelect.selectedIndex = i;
                break;
            }
        }
    });

});