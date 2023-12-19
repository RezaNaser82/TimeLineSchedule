//refresh the page every minute
function reloadPage() {
    setTimeout(function () {
        location.reload();
    }, 60000); 
}


window.onload = reloadPage;

//change location vertically
function moveCardsVertically() {
    var $cards = $('.HomeBox');
    var $firstCard = $cards.first();
    var $secondCard = $cards.eq(1);
    var $lastCard = $cards.last();
    var cardHeight = $firstCard.outerHeight();

    $secondCard.css('top', '-' + cardHeight + 'px')
        .animate({
            top: 0
        }, 1000, function () {
            $firstCard.insertAfter($lastCard).css('top', 0);
        });

    $cards.animate({
        top: '+=' + cardHeight + 'px'
    }, 2500);
}

setInterval(moveCardsVertically, 10000);