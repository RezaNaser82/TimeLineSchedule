//refresh the page every minute
function reloadPage(interval) {
    setTimeout(function () {
        location.reload();
    }, interval); 
}


window.onload = reloadPage;

//change location vertically

function moveCardsVertically(interval) {
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
            firstCard.style.transform = `translateY(${cardHeight*2}px)`;
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

setInterval(moveCardsVertically, interval);

const refreshInput = document.getElementById('RefreshWebTime');
const cardChangeInput = document.getElementById('BoxChangeTime');


let refreshInterval = 60000;
let cardChangeInterval = 10000;


window.onload = function () {
    reloadPage(refreshInterval);
    moveCardsVertically(cardChangeInterval);
};


refreshInput.addEventListener('change', function () {
    refreshInterval = parseInt(this.value) * 60000; 
    
    reloadPage(refreshInterval);
});


cardChangeInput.addEventListener('change', function () {
    cardChangeInterval = parseInt(this.value) * 1000; 
    moveCardsVertically(cardChangeInterval);
});