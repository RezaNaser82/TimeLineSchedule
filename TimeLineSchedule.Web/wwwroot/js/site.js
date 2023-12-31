//refresh the page every minute
function reloadPage() {
    setTimeout(function () {
        location.reload();
    }, 60000);
}


window.onload = reloadPage;

//change location vertically

function moveCardsVertically() {
    const cards = document.querySelectorAll('.HomeBox');
    if (cards.length === 0) {
        return;
    }
    const container = document.querySelector('.HomeContainer');
    const cardHeight = cards[0].offsetHeight;
    const firstCard = cards[0];

    firstCard.style.transition = 'none';
    firstCard.style.transform = 'none';


    setTimeout(() => {
        requestAnimationFrame(() => {
            firstCard.style.transition = 'transform 1s ease-in-out';
            firstCard.style.transform = `translateY(${cardHeight * 2}px)`;
        });

        firstCard.addEventListener('transitionend', function handler() {
            firstCard.removeEventListener('transitionend', handler);
            requestAnimationFrame(() => {
                firstCard.style.transition = 'none';
                firstCard.style.transform = 'none';
                container.appendChild(firstCard);
            });
        }, { once: true });
    }, 50);
}

setInterval(moveCardsVertically, 10000);


//old function for getting interval data from inputs in another page

//// Function to reload the page every specified time
//function reloadPage(refreshTime) {
//    setTimeout(function () {
//        location.reload();
//    }, refreshTime * 60000); // Convert minutes to milliseconds
//}

//// Function to move cards vertically every specified time
//function moveCardsVertically(changeBoxTime) {
//    setInterval(function () {
//        const cards = document.querySelectorAll('.HomeBox');
//        if (cards.length === 0) {
//            return;
//        }
//        const container = document.querySelector('.HomeContainer');
//        const cardHeight = cards[0].offsetHeight;
//        const firstCard = cards[0];

//        firstCard.style.transition = 'none';
//        firstCard.style.transform = 'none';


//        setTimeout(() => {
//            requestAnimationFrame(() => {
//                firstCard.style.transition = 'transform 1s ease-in-out';
//                firstCard.style.transform = `translateY(${cardHeight * 2}px)`;
//            });

//            firstCard.addEventListener('transitionend', function handler() {
//                firstCard.removeEventListener('transitionend', handler);
//                requestAnimationFrame(() => {
//                    firstCard.style.transition = 'none';
//                    firstCard.style.transform = 'none';
//                    container.appendChild(firstCard);
//                });
//            }, { once: true });
//        }, 50);        console.log(`Moving cards every ${changeBoxTime} milliseconds`);
//    }, changeBoxTime * 1000); // Convert seconds to milliseconds
//}
//// Function to handle form submission and update settings
//document.getElementById('settingsForm').addEventListener('submit', function (event) {
//    event.preventDefault(); // Prevent form submission

//    // Read values from input fields
//    var refreshTime = document.getElementById('RefreshWebTime').value || 1; // Default 1 minute
//    var changeBoxTime = document.getElementById('BoxChangeTime').value || 10; // Default 10 seconds

//    // Convert values and set intervals with updated values
//    reloadPage(refreshTime);
//    moveCardsVertically(changeBoxTime);

//    // You can remove console.log statements used for testing and replace them with your logic
//    console.log(`Refresh time set to ${refreshTime} minute(s)`);
//    console.log(`Change box time set to ${changeBoxTime} second(s)`);

//    // You might want to trigger these functions onLoad as well
//    reloadPage(refreshTime);
//    moveCardsVertically(changeBoxTime);
//});