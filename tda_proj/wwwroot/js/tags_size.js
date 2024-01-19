var myDiv = document.getElementById('myDiv');

function checkWidth() {
    if (myDiv.offsetWidth < 50 * window.innerWidth / 100) {
        myDiv.classList.add('small');
    } else {
        myDiv.classList.remove('small');
    }

    
}

// Zavolání funkce při načtení stránky a při změně velikosti okna
window.onload = checkWidth;
window.onresize = checkWidth;


