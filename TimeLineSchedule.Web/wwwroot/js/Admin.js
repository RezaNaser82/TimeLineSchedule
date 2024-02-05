const { ajax } = require("jquery");

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
    // Add validation for classStart and classEnd: class start should be less than class end Time
    const classStartInputs = document.querySelectorAll(".class-start");
    const classEndInputs = document.querySelectorAll(".class-end");

    classStartInputs.forEach(input => input.addEventListener("change", validateTimes));
    classEndInputs.forEach(input => input.addEventListener("change", validateTimes));

    function validateTimes() {
        debugger
        const classStartTime = new Date(`1970-01-01T${document.querySelector(".class-start").value}:00`);
        const classEndTime = new Date(`1970-01-01T${document.querySelector(".class-end").value}:00`);

        if (classStartTime >= classEndTime) {
            alert("ساعت شروع باید قبل از ساعت پایان باشد");
            document.querySelector(".class-end").value = "";
        }
    }

});
