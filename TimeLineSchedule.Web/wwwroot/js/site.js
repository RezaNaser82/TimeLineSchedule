//refresh the page every minute
function reloadPage() {
    setTimeout(function () {
        location.reload();
    }, 60000);
}


window.onload = reloadPage;



// Change location vertically
function moveCardsVertically() {
    
    const cards = document.querySelectorAll('.HomeBox');

    
    if (cards.length <= 1) {
        return;
    }

    
    const container = document.querySelector('.HomeContainer');

    
    const cardHeight = cards[0].offsetHeight;

    
    cards.forEach((card, index) => {
        card.style.transition = 'none';
        card.style.transform = 'none';
        card.style.order = index + 1;
    });

    
    setTimeout(() => {
        
        cards.forEach(card => {
            card.style.transition = 'transform 1s ease-in-out';
            card.style.transform = 'translateY(-100%)';
        });

        
        setTimeout(() => {
            
            cards.forEach(card => {
                card.style.transition = 'none';
                card.style.transform = 'none';
            });

            
            const firstCardOrder = parseInt(cards[0].style.order);

           
            cards.forEach(card => {
                let currentOrder = parseInt(card.style.order);
                currentOrder = currentOrder === firstCardOrder ? cards.length : currentOrder - 1;
                card.style.order = currentOrder;
            });

            
            const reorderedCards = Array.from(cards).sort((a, b) => {
                const orderA = parseInt(a.style.order);
                const orderB = parseInt(b.style.order);
                return orderA - orderB;
            });

            
            reorderedCards.forEach(card => {
                container.appendChild(card);
            });
        }, 1000); 
    }, 50); 
}


setInterval(moveCardsVertically, 10000);



